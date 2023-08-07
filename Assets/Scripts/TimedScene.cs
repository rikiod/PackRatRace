using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedScene : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 50f;
    public SceneTransitionManager sceneTransitionManager;
    private float timeElapsed;

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > delayBeforeLoading)

        {
            sceneTransitionManager.GoToScene(2);
        }


    }
}