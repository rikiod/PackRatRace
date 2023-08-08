using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void quit() {
        Application.Quit();
    }
}

// public class QuitGame : MonoBehaviour
// {
//     public FadeScreen fadeScreen;

//     public void quit() {
//         StartCoroutine(quitGame());
//     }
    
//     IEnumerator quitGame()
//     {
//         fadeScreen.FadeOut();
//         yield return new WaitForSeconds(fadeScreen.fadeDuration);

//         Application.Quit();
//     }
// }
