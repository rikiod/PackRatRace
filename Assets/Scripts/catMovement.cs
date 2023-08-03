using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catMovement : MonoBehaviour
{
    [SerializeField] Vector3 startingPoint;
    [SerializeField] Vector3 targetPoint;
    [SerializeField] float speed = 1; 
    [SerializeField] float minWaitTime = 10f;
    [SerializeField] float maxWaitTime = 30f;
    bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
        StartCoroutine(WaitThenChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, startingPoint, Time.deltaTime * speed);
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, Time.deltaTime * speed);
       }
        
    }

    IEnumerator WaitThenChangeDirection() {
        while (true) {
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);

            isMoving = !isMoving;
        }
    }
}


