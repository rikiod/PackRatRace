using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class grinderButtonScript : MonoBehaviour
{
    public UnityEvent onRelease;
    private GameObject pusher;
    private bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
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
            onRelease.Invoke();
            isPressed = false;
        }
    }
}
