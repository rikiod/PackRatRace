using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour
{

    public float waitTime;

    private void Awake ()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(waitTime);
        Object.Destroy(this.gameObject);
    }

}
