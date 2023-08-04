using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutScene : MonoBehaviour
{
    // make sure sprite is clickable / has collider 
    [SerializeField] string sceneName = "about"; // this scene doesn't exist ... 

    public void LoadScene() {
        print("loading about scene");
        SceneManager.LoadScene(sceneName);
    }

}
