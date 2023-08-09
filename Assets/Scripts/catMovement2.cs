using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//on load: boss at door (done)
//Three boxes compelted: Call D2
//Five boxes completed: Call D3 (script waits 30 seconds before cat moves)



public class catMovement2 : MonoBehaviour
{
    public AudioSource audioSource;
    public catMovement CatBossWindow;
    public TextMeshPro Text;
    [SerializeField] Vector3 hidingPoint;
    [SerializeField] Vector3 point1;
    [SerializeField] Vector3 point2;
    [SerializeField] float speed = 1f; 
    // [SerializeField] float dialogue1Time = 12f;
    // [SerializeField] float dialogue2Time = 12f;
    [SerializeField] float textWaitTime = 4f;
    int isMoving = 0;
    bool directionn = true; // true = walk towards door. false = walk away from door
    int dialogueNum = 1;
    public SceneTransitionManager sceneTransitionManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Text = FindObjectOfType<TextMeshProUGUI>();

        GameObject textBox = transform.Find("TextBox").gameObject;
        textBox.SetActive(false);

        transform.position = point2;
        StartCoroutine(Dialogue(1));
        
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
                CatBossWindow.StartMovement();
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
                StartCoroutine(Dialogue(dialogueNum));
                isMoving = 4;
                
            }
        }
        
    }

    // IEnumerator InitiateMovement() {
    //         yield return new WaitForSeconds(dialogue1Time);
    //         isMoving = 1;
    //         directionn = true;

    // }


    IEnumerator Dialogue(int num) {
        yield return new WaitForSeconds(2);
        
        GameObject textBox = transform.Find("TextBox").gameObject;
        textBox.SetActive(true);

        if (num == 1) {
            
            yield return new WaitForSeconds(3);
            Text.text = "Welcome to the Purrfect Knead factory.";
            audioSource.Play();
            yield return new WaitForSeconds(textWaitTime);

            Text.text = "I'm Patrick, but you should call me The Manager.";
            yield return new WaitForSeconds(textWaitTime);

            Text.text = "Remember new guy, I'm in charge here.";
            audioSource.Play();
            yield return new WaitForSeconds(textWaitTime);
        }

        else if (num == 2) {
            Text.text = "Are you slacking? You'd better get packing.";
            audioSource.Play();
            yield return new WaitForSeconds(textWaitTime);

            Text.text = "If you can't earn your keep, you're not worth anything.";
            yield return new WaitForSeconds(textWaitTime);

            Text.text = "Bad workers are the bane of society. Hurry up!";
            audioSource.Play();
            yield return new WaitForSeconds(textWaitTime);

            Text.text = "I want to see those boxes packed within the next 5 minutes, clear?";
            yield return new WaitForSeconds(textWaitTime);
        }

        else if (num == 3) {
            Text.text = "Just standing there, doing nothing! Useless!";
            audioSource.Play();
            yield return new WaitForSeconds(textWaitTime);

            Text.text = "Tomorrow I want to see you in the preparation department at 6am sharp,";
            audioSource.Play();
            yield return new WaitForSeconds(textWaitTime);

            Text.text = "since you're clearly doing a terrible job here.";
            yield return new WaitForSeconds(textWaitTime);

            Text.text = "Filthy rat, don't make me regret hiring you.";
            audioSource.Play();
            yield return new WaitForSeconds(textWaitTime + 2);


            //end level, go to lv2
            sceneTransitionManager.GoToScene(2);

            yield return new WaitForSeconds(10);


        }
        
        textBox.SetActive(false);
        yield return new WaitForSeconds(1);
        directionn = false;
        isMoving = 2;
    }

    public void D2() {
        CatBossWindow.StopMovement();
        dialogueNum = 2;
        isMoving = 1;
        directionn = true;
    }

    public void D3() {
        CatBossWindow.StopMovement();
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting() {
        yield return new WaitForSeconds(30);
        dialogueNum = 3;
        isMoving = 1;
        directionn = true;
        CatBossWindow.StopMovement();
    }
}


