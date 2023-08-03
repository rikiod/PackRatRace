using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{

    // make sure sprite is clickable / has collider 
    [SerializeField] string sceneName = "Level1";

    private void OnTriggerEnter(Collider other) {
        LoadScene();
    }
    // private void OnMouseDown() {
    //     print("hi");
    //     LoadScene();
    // }

    private void LoadScene() {
        SceneManager.LoadScene(sceneName);
    }

    // Start is called before the first frame update
    void Start()
    {
        print("start");
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
