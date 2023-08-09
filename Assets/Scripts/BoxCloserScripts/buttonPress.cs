using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class buttonPress : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject pusher;
    bool isPressed;
    public AudioSource audioSource;
    private bool wasPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        wasPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.position -= button.transform.right * 1/50;
            pusher = other.gameObject;
            onPress.Invoke();
            isPressed = true;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (pusher == other.gameObject)
        {
            button.transform.position += button.transform.right * 1/50;
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
