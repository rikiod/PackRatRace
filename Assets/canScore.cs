using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canScore : MonoBehaviour
{
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Food1")
        {
            deleteObject(other.gameObject.transform.parent.gameObject.transform.parent.gameObject);
        }
    }

    private void deleteObject(GameObject food)
    {
        StartCoroutine(waiter(food));
    }

    IEnumerator waiter(GameObject food)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(food);
    }
}
