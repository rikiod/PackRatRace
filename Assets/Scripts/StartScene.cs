using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    // make sure sprite is clickable / has collider 
    [SerializeField] string sceneName = "Level1";

    public void LoadScene() {
        print("loaded level 1 scene");
        SceneManager.LoadScene(sceneName);
    }

}
