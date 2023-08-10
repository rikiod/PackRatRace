using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanRecepticle : MonoBehaviour
{
    // public BoxCollider canCollider;
    public GameObject correctCan;
    public GameObject incorrectCan;
    // public GameObject specialCan;
    public GameEvents canDeposited;

    private void OnTriggerEnter(Collider other) {
        // print("collision !!!");
        // Debug.Log(other.gameObject);

        if (other.gameObject == correctCan) {
            canDeposited.Raise(this, true);
        }
        else if (other.gameObject == incorrectCan)
        {
            canDeposited.Raise(this, false);
        }
        StartCoroutine(destroyCan(other.gameObject));
    }

    private IEnumerator destroyCan(GameObject can)
    {
        yield return new WaitForSeconds(10);
        Destroy(can);
    }

}
