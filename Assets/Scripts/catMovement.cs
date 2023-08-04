using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catMovement : MonoBehaviour
{
    [SerializeField] Vector3 bopStartingPoint;
    [SerializeField] Vector3 walkStartingPoint;
    [SerializeField] Vector3 TargetPoint;
    [SerializeField] float speed = 1; 
    [SerializeField] float minActionTime = 10f;
    [SerializeField] float maxActionTime = 30f;
    [SerializeField] float minWaitTime = 3f;
    [SerializeField] float maxWaitTime = 6f;
    [SerializeField] Vector3 watchingAngle;
    [SerializeField] Vector3 enterAngle;
    [SerializeField] Vector3 returnAngle;
    [SerializeField] float spinSpeed;
    float isMoving = 0;    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = bopStartingPoint;
        transform.eulerAngles = watchingAngle;
        StartCoroutine(ActionInitiation());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == 1) { //move TO TARGET
            transform.position = Vector3.MoveTowards(transform.position, TargetPoint, Time.deltaTime * speed);
            if (transform.position == TargetPoint) {
                if (transform.eulerAngles == watchingAngle) {
                    StartCoroutine(WatchingYou());
                }
                else {
                isMoving = 5;
                StartCoroutine(Spinning());
                }
            }
        }
        
        else if (isMoving == 5) { // TURN 90 
            transform.Rotate(new Vector3(0, spinSpeed, 0) * Time.deltaTime);
        }


        

        else if (isMoving == 2) { // move DOWN
            transform.position = Vector3.MoveTowards(transform.position, bopStartingPoint, Time.deltaTime * speed);
            if (transform.position == bopStartingPoint) {
                StartCoroutine(ActionInitiation());
            }
        }
        

        else if (isMoving == 6) { // TURN 90 v2
            transform.Rotate(new Vector3(0, spinSpeed, 0) * Time.deltaTime);
        }

        else if (isMoving == 4) { // move OUT OF WINDOW
            transform.position = Vector3.MoveTowards(transform.position, walkStartingPoint, Time.deltaTime * speed);
            if (transform.position == walkStartingPoint) {
                transform.eulerAngles = watchingAngle;
                StartCoroutine(ActionInitiation());
            }
        }
    }

    IEnumerator ActionInitiation() {
        isMoving = 0;
        float waitTime = Random.Range(minActionTime, maxActionTime);
        yield return new WaitForSeconds(waitTime);

        bool randomBool = Random.value > 0.5f;
        if (randomBool) {
            transform.position = bopStartingPoint;
            isMoving = 1;
        }
        else {
            transform.position = walkStartingPoint;
            transform.eulerAngles = enterAngle;
            isMoving = 1;
        }        
    }

    IEnumerator WatchingYou(){
        isMoving = 0;
        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(waitTime);

        bool randomBool = Random.value > 0.5f;
        if (randomBool) {
            
            isMoving = 2;
        }
        else {
            
            isMoving = 6;
            StartCoroutine(Spinning());
        }
    }

    IEnumerator Spinning() {
        
        float spinTime = -90 / spinSpeed;
        yield return new WaitForSeconds(spinTime);

        if (isMoving == 5) {
            StartCoroutine(WatchingYou());
        }
        else { // isMoving == 6
            isMoving = 4;
        }
    }
}


