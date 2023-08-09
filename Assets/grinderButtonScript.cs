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

    public AudioSource audioSource;
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
        audioSource.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (pusher == other.gameObject)
        {
            if (!wasPressed)
            {
                onRelease.Invoke();
                startTimer();
            }
            isPressed = false;
        }
    }

    private void startTimer()
    {
        wasPressed = true;
        StartCoroutine(buttonDelay());
    }
    IEnumerator buttonDelay()
    {
        yield return new WaitForSeconds(6);
        wasPressed = false;
    }
}
