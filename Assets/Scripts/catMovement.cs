using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catMovement : MonoBehaviour
{
    [SerializeField] Vector3 startingPoint;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
    }

    [SerializeField] Vector3 targetPoint = new Vector3(-0.25, 0, -2);
    [SerializeField] float speed = 1; 
    int direction = 0; 

    // Update is called once per frame
    void Update()
    {
        if (transform.position == targetPoint) {
            direction = 0; 
        } else if (transform.position == startingPoint) {
            direction = 1;
        }

        if (direction == 0) {
            transform.position = Vector3.MoveTowards(transform.position, startingPoint, Time.deltaTime * speed);
        }
       if (direction == 1) {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, Time.deltaTime * speed);
       }
        
    }
}


