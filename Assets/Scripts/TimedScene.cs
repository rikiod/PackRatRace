using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TimedScene : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 50f;
    public SceneTransitionManager sceneTransitionManager;
    private float timeElapsed;
    public InputActionProperty skipSceneAction;

    private void Update()
    {
        if (skipSceneAction.action.IsPressed())
        {
            sceneTransitionManager.GoToScene(2);
        }
        timeElapsed += Time.deltaTime;
        if (timeElapsed > delayBeforeLoading)

        {
            sceneTransitionManager.GoToScene(2);
        }


    }
}