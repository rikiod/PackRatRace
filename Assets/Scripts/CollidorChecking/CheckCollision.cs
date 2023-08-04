using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    [Header("Events")]
    public GameEvents OnCollision;
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        OnCollision.Raise(this, other.gameObject.name);
    }

}
