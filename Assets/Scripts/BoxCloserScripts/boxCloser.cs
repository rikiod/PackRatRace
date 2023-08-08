using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Need one listener for scan complete
public class boxCloser : MonoBehaviour
{
    [SerializeField]
    private int speed;

    private bool moveMachine;
    private int counter;
    // Start is called before the first frame update

    [Header("Events")]
    public GameEvents startScanning;

    private bool isScanning = false;
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
            else if (60 <= counter && counter <= 79)
            {
                startScanner();
                isScanning = true;
                counter += 1;
            }
            else if (80 <= counter && counter <= 139)
            {
                stopScanner();
                isScanning = false;
                transform.position += transform.up * speed * Time.fixedDeltaTime /100;
                counter += 1;
            }
            else if (counter >=140)
            {
                moveMachine = false;
                counter = 0;
            }
        }
    }

    private void startScanner()
    {
        if (!isScanning)
        {
            startScanning.Raise(this, true); // calls collision box to check for collisions
        }

    }
    private void stopScanner()
    {
        if (isScanning)
        {
            startScanning.Raise(this, false); // calls collision box to check for collisions
        }

    }
    public void cycleMachine()
    {
        moveMachine = true;
    }
}
