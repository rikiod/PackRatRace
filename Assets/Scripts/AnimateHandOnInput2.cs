using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AnimateHandOnInput2 : MonoBehaviour
{
    public InputActionProperty closeAnimationAction;
    private bool currentPressState;
    private bool lastPressState = false;
    public GameObject closedModel;
    public GameObject originalModel;
    public GameObject closedModel2;
    public GameObject originalModel2;
    private Transform currentTransform;
    [SerializeField]
    private float delayBeforeModelSwitch = 50f;
    private float timeElapsed;
    private bool hasRun = false;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(changeHands());
/*        while (hasRun == false)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed == delayBeforeModelSwitch)
            {
                closedModel = closedModel2;
                originalModel = originalModel2;
                hasRun = true;
            }
        }*/
    }
    private IEnumerator changeHands()
    {
        yield return new WaitForSeconds(10);
        closedModel = closedModel2;
        originalModel = originalModel2;
    }

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
