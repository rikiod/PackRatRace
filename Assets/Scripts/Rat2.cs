using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//special event, after can pops out, call D1 (waits 5 seconds)


public class Rat2 : MonoBehaviour
{
    public AudioSource audioSource;
    public TextMeshPro Text;
    [SerializeField] Vector3 hidingPoint;
    [SerializeField] Vector3 point1;
    //[SerializeField] Vector3 point2;
    [SerializeField] float speed = 1f; 
    //[SerializeField] float dialogue1Time = 12f;
    //[SerializeField] float dialogue2Time = 12f;
    [SerializeField] float textWaitTime = 4f;
    float isMoving = 0;
    //bool directionn = true; // true = walk towards door. false = walk away from door
    //bool goPlease = true;
    SceneTransitionManager sceneTransitionManager;

    

    // Start is called before the first frame update
    void Start()
    {
        //Text = FindObjectOfType<TextMeshProUGUI>();

        GameObject textBox = transform.Find("TextBox").gameObject;
        textBox.SetActive(false);

        transform.position = hidingPoint;

        //D1();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Text.text = "Miau miau miau miau miau (etc. etc.)";


        // if (isMoving == 1) { //Move to hiding point
        //     transform.position = Vector3.MoveTowards(transform.position, hidingPoint, Time.deltaTime * speed);
        //     if (transform.position == hidingPoint) {
        //         isMoving = 0;
        //     }
        // }

        if (isMoving == 2) { // move towards door
            transform.position = Vector3.MoveTowards(transform.position, point1, Time.deltaTime * speed);
            if (transform.position == point1) {
                StartCoroutine(Dialogue());
                isMoving = 0;
            }
        }
        
    }

    IEnumerator Dialogue() {
        yield return new WaitForSeconds(0.5f);
        
        GameObject textBox = transform.Find("TextBox").gameObject;
        textBox.SetActive(true);

        Text.text = "That was your friend, right?";
        audioSource.Play();
        yield return new WaitForSeconds(textWaitTime);

        Text.text = "You get used to it.";

        yield return new WaitForSeconds(5);

        //Fade out, take player back to main menu
        sceneTransitionManager.GoToScene(0);
        
    }
    IEnumerator Wait() {
        yield return new WaitForSeconds(5);
        isMoving = 2;
    }

    public void D1() {
        StartCoroutine(Wait());
    }


}



