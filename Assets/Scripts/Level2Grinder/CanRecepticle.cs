using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanRecepticle : MonoBehaviour
{
    // public BoxCollider canCollider;
    public GameObject correctCan;
    public GameObject incorrectCan;
    // public GameObject specialCan;

    private void OnTriggerEnter(Collider other) {
        // print("collision !!!");
        // Debug.Log(other.gameObject);

        if (other.gameObject == correctCan) {
            print("Can was correct!!!!");
        }
        else if (other.gameObject == incorrectCan) {
            print("Can was incorrect!! >:(");
        }

        Destroy(other.gameObject);
    }

}
