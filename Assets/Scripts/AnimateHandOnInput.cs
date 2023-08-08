using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty closeAnimationAction;
    private bool currentPressState;
    private bool lastPressState = false;
    public GameObject closedModel;
    public GameObject originalModel;
    private Transform currentTransform;

    // Update is called once per frame
    void Update()
    {
        currentPressState = closeAnimationAction.action.IsPressed();
        if (currentPressState != lastPressState)
        {
            currentTransform = this.transform.GetChild(0).transform;
            if (currentPressState == true)
            {
                Object.Destroy(this.transform.GetChild(0).gameObject);
                GameObject newHand = Instantiate(closedModel, currentTransform.position, currentTransform.rotation);
                newHand.transform.parent = this.transform;
            }

            else
            {
                Object.Destroy(this.transform.GetChild(0).gameObject);
                GameObject newHand = Instantiate(originalModel, currentTransform.position, currentTransform.rotation);
                newHand.transform.parent = this.transform;
            }
        }
        lastPressState = currentPressState;
    }

}
