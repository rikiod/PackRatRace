using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class grinderButtonScript : MonoBehaviour
{
    public UnityEvent onRelease;
    private GameObject pusher;
    private bool isPressed;
    private bool wasPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        wasPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        pusher = other.gameObject;
        isPressed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (pusher == other.gameObject)
        {
            if (!wasPressed)
            {
                StartCoroutine(buttonPressed());
                onRelease.Invoke();
                isPressed = false;
                wasPressed = true;
            }
        }
    }

    private IEnumerator buttonPressed()
    {
        yield return new WaitForSeconds(6);
        wasPressed = false;
    }
}
