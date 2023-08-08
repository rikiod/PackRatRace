using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class grinderScript : MonoBehaviour
{
    [SerializeField]
    float canSpeed;
    [SerializeField]
    float waitTime;
    public GameObject can;
    public GameObject openGrinder;
    public GameObject closedGrinder;
    public GameObject canSpawn;
    private GameObject grinder;
    private GameObject newCan;
    private GameObject detector;

    private Dictionary<string, int> inGrinder = new Dictionary<string, int>();

    public static event Action<Dictionary<string, int>> OnCanning;

    // Start is called before the first frame update
    void Start()
    {
        grinder = Instantiate(openGrinder, transform.position, Quaternion.Euler(0, 180, 0));
        detector = grinder.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void closeGrinder()
    {
        StartCoroutine(cycleGrinder());
    }

    IEnumerator cycleGrinder()
    {
        //count up and broadcast the items in the grinder
        OnCanning?.Invoke(inGrinder);
        //start the production of a can
        Destroy(grinder);
        grinder = Instantiate(closedGrinder, transform.position, Quaternion.Euler(0, 180, 0));
        yield return new WaitForSeconds(waitTime);
        newCan = Instantiate(can, canSpawn.transform.position, Quaternion.identity);
        newCan.GetComponent<Rigidbody>().velocity = transform.up * canSpeed;
        newCan.transform.parent = canSpawn.transform;
        Destroy(grinder);
        grinder = Instantiate(openGrinder, transform.position, Quaternion.Euler(0, 180, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (inGrinder.ContainsKey(other.gameObject.name))
        {
            int amount = inGrinder[other.gameObject.name];
            inGrinder[other.gameObject.name] = amount + 1;
        }
        inGrinder.Add(other.gameObject.name, 1);
    }

    private void OnTriggerExit(Collider other)
    {
        int amount = inGrinder[other.gameObject.name];
        inGrinder[other.gameObject.name] = amount - 1;
    }
}
