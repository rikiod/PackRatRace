using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public List<string> objectToDetect = new List<string>();
    [Header("Events")]
    public GameEvents OnCollision;
    public void OnTriggerEnter(Collider other)
    {
        if (objectToDetect.Contains(other.gameObject.name))
        {
/*            Debug.Log(other.gameObject.name);*/
            OnCollision.Raise(this, other.gameObject.name);
            Destroy(other.gameObject);
        }

    }

}
