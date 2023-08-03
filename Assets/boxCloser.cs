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
            else if (60 <= counter && counter <= 119)
            {
                transform.position += transform.up * speed * Time.fixedDeltaTime /100;
                counter += 1;
            }
            else if (counter >=120)
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
