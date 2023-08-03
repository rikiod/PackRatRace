using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ratMovement : MonoBehaviour
{
    public TextMeshPro Text;
    [SerializeField] Vector3 hidingPoint;
    [SerializeField] Vector3 point1;
    [SerializeField] Vector3 point2;
    [SerializeField] float speed = 1; 
    [SerializeField] float dialogue1Time = 12f;
    //[SerializeField] float dialogue2Time = 12f;
    [SerializeField] float textWaitTime = 3;
    float isMoving = 0;
    bool directionn = true; // true = walk towards door. false = walk away from door
    bool goPlease = true;
    

    // Start is called before the first frame update
    void Start()
    {
        //Text = FindObjectOfType<TextMeshProUGUI>();

        GameObject textBox = transform.Find("TextBox").gameObject;
        textBox.SetActive(false);

        StartCoroutine(WaitThenChangeDirection());
        transform.position = hidingPoint;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Text.text = "Miau miau miau miau miau (etc. etc.)";


        if (isMoving == 1) {
            transform.position = Vector3.MoveTowards(transform.position, hidingPoint, Time.deltaTime * speed);
            if (transform.position == hidingPoint && directionn) {
                isMoving = 2;
            }
            else if (transform.position == hidingPoint && !directionn) {
                isMoving = 0;
                directionn = true;
                goPlease = true;
            }
        }

        else if (isMoving == 2) {
            // move towards pt 1
            transform.position = Vector3.MoveTowards(transform.position, point1, Time.deltaTime * speed);
            if (transform.position == point1 && directionn) {
                isMoving = 3;
            }
            else if (transform.position == point1 && !directionn) {
                isMoving = 1;
            }
        }

        else if (isMoving == 3){
            transform.position = Vector3.MoveTowards(transform.position, point2, Time.deltaTime * speed);
            if (transform.position == point2) {
                StartCoroutine(Dialogue());
                isMoving = 4;
            }
        }
        
    }

    IEnumerator WaitThenChangeDirection() {
        if (goPlease){
           yield return new WaitForSeconds(dialogue1Time);
            isMoving = 1;
            directionn = true;
            goPlease = false;

            //yield return new WaitForSeconds(dialogue1Time);
            //isMoving = 1; 
        }

    }
        IEnumerator Dialogue() {
            yield return new WaitForSeconds(2);
            
            GameObject textBox = transform.Find("TextBox").gameObject;
            Text.text = "Miau miau miau miau miau (etc etc)";
            textBox.SetActive(true);
            yield return new WaitForSeconds(textWaitTime);

            Text.text = "Miau Miau, i have more things to say miau";
            yield return new WaitForSeconds(textWaitTime);

            textBox.SetActive(false);
            yield return new WaitForSeconds(1);
            directionn = false;
            isMoving = 2;            
        
    }
}



