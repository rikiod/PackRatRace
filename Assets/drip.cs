using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drip : MonoBehaviour
{
    [SerializeField]
    public GameObject blood;
    private bool spawned;
    private GameObject bloodDrop;
    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawned)
        {
            spawned = true;
            StartCoroutine(dripBlood());
        }
    }

    IEnumerator dripBlood()
    {
        yield return new WaitForSeconds(1);
        bloodDrop = Instantiate(blood, transform.position, Quaternion.identity);
        spawned = false;
    }
}
