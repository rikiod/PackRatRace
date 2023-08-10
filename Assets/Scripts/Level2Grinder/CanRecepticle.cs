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
    public UnityEvent goodCan;
    public UnityEvent badCan;

    private void OnTriggerEnter(Collider other) {
        // print("collision !!!");
        // Debug.Log(other.gameObject);

        if (other.gameObject == correctCan) {
            goodCan.Invoke();
            print("Can was correct!!!!");
        }
        else if (other.gameObject == incorrectCan) {
            badCan.Invoke();
            print("Can was incorrect!! >:(");
        }
        StartCoroutine(destroyCan(other.gameObject));
    }

    private IEnumerator destroyCan(GameObject can)
    {
        yield return new WaitForSeconds(10);
        Destroy(can);
    }

}
