using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Two boxes completed: call D2
//Four boxes completed: call D3


public class ratMovement : MonoBehaviour
{
    public AudioSource audioSource;
    public TextMeshPro Text;
    [SerializeField] Vector3 hidingPoint;
    [SerializeField] Vector3 point1;
    //[SerializeField] Vector3 point2;
    [SerializeField] float speed = 2f; 
    //[SerializeField] float dialogue1Time = 12f;
    //[SerializeField] float dialogue2Time = 12f;
    [SerializeField] float textWaitTime = 4f;
    float isMoving = 0;
    //bool directionn = true; // true = walk towards door. false = walk away from door
    //bool goPlease = true;
    int dialogueNum = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        //Text = FindObjectOfType<TextMeshProUGUI>();

        GameObject textBox = transform.Find("TextBox").gameObject;
        textBox.SetActive(false);

        transform.position = hidingPoint;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Text.text = "Miau miau miau miau miau (etc. etc.)";


        if (isMoving == 1) { //Move to hiding point
            transform.position = Vector3.MoveTowards(transform.position, hidingPoint, Time.deltaTime * speed);
            if (transform.position == hidingPoint) {
                isMoving = 0;
            }
        }

        else if (isMoving == 2) { // move towards door
            transform.position = Vector3.MoveTowards(transform.position, point1, Time.deltaTime * speed);
            if (transform.position == point1) {
                StartCoroutine(Dialogue(dialogueNum));
                isMoving = 0;
            }
        }
        
    }


    IEnumerator Dialogue(int num) {
        yield return new WaitForSeconds(0.5f);
        
        GameObject textBox = transform.Find("TextBox").gameObject;
        textBox.SetActive(true);

        if (num == 1) {
            Text.text = "Hey man! I'm always happy to see new guys around here, a lot of folks don't last very long.";
            audioSource.Play();
            yield return new WaitForSeconds(textWaitTime);

            Text.text = "Feel free to ask me anything if you need it, I'm just next door!";
            audioSource.Play();
            yield return new WaitForSeconds(textWaitTime);

        }

        else if (num == 2) {
            Text.text = "Did The Manager Pat come to talk to you?";
            audioSource.Play();
            yield return new WaitForSeconds(textWaitTime);

            Text.text = "He sounds harsh, but he's all hiss and no bite.";
            yield return new WaitForSeconds(textWaitTime);

            Text.text = "Don't worry about him too much.";
            audioSource.Play();
            yield return new WaitForSeconds(textWaitTime);

        }

        textBox.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        isMoving = 1;            
        
    }

    public void D1() {
        dialogueNum = 1;
        isMoving = 2;
    }

    public void D2() {
        dialogueNum = 2;
        isMoving = 2;
    }
}



