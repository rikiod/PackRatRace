using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTheConveyor : MonoBehaviour
{
    //public beltScript belt;
    

    public void CreepyTime()
    {
        StartCoroutine(Waitt());
    }

    IEnumerator Waitt() {
        yield return new WaitForSeconds(3.5f);
        this.GetComponent<beltScript>().enabled = false;
    }
}