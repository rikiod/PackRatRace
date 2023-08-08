using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCloser : MonoBehaviour
{
    [SerializeField]
    private int speed;

    private bool moveMachine;
    private int counter;
    // Start is called before the first frame update

    [Header("Events")]
    public GameEvents startScanning;
    void Start()
    {
        moveMachine = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveMachine)
        {
            if (0 <= counter && counter <= 59)
            {
                transform.position -= transform.up * speed * Time.fixedDeltaTime /100;
                counter += 1;
            }
            else if (60 <= counter && counter <= 69)
            {
                startScanning.Raise(this, true); // calls collision box to check for collisions
                counter += 1;
            }
            else if (70 <= counter && counter <= 129)
            {
                startScanning.Raise(this, false); // calls collision box to stop checking for collisions
                transform.position += transform.up * speed * Time.fixedDeltaTime /100;
                counter += 1;
            }
            else if (counter >=130)
            {
                moveMachine = false;
                counter = 0;
            }
        }
    }

    public void cycleMachine()
    {
        moveMachine = true;
    }
}
