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

    [SerializeField] Vector3 targetPoint = new Vector3(3, 0, 3);
    [SerializeField] float speed = 1; 
    int direction = 0; 

    // Update is called once per frame
    void Update()
    {
        if (transform.position == targetPoint) {
            Debug.Log("b1");
            direction = 0; 
        } else if (transform.position == startingPoint) {
                        Debug.Log("b2");

            direction = 1;
        }

        if (direction == 0) {
                        Debug.Log("b3");

            transform.position = Vector3.MoveTowards(transform.position, startingPoint, Time.deltaTime * speed);
        }
       if (direction == 1) {
                    Debug.Log("b4");

            transform.position = Vector3.MoveTowards(transform.position, targetPoint, Time.deltaTime * speed);
       }
        
    }
}


