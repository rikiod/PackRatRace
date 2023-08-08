using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AnimateHandOnInput : MonoBehaviour
{
    public ActionBasedController actionBasedController;
    public InputActionProperty closeAnimationAction;

    public GameObject closedModel;
    private Transform originalModel;

    // Start is called before the first frame update
    void Start()
    {
        //originalModel = actionBasedController.model;
    }

    // Update is called once per frame
    void Update()
    {
        if (closeAnimationAction.action.IsPressed())
        {
            Object.Destroy(this.transform.GetChild(0).gameObject);
            GameObject newHand = Instantiate(closedModel, transform.position, Quaternion.identity);
            newHand.transform.parent = this.transform;
            //actionBasedController.model = closedModel;
        }
        /*
                else
                    actionBasedController.model = originalModel;*/
       
    }

/*    public void changeHand()
    {
        Object.Destroy(this.gameObject);
    }*/
}
