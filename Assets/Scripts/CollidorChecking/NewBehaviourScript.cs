using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameEvents OnCollision;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionWithFood(Component sender, object data)
    {
        if (data == "Food1")
        {
            Destroy(this);
            Debug.Log("Food 1 detected");
        }
        else
        {
            Debug.Log(data + " detected");
        }
    }
}
