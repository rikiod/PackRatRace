using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    // make sure sprite is clickable / has collider 
    //[SerializeField] string sceneName = "TextIntro";

    public void LoadScene() {
        print("loaded next scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
