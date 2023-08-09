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
    [SerializeField]
    private bool canCorrect;

    public GameEvents grinderComplete;
    public List<GameEvents> listOfInputMeatBroadcast = new List<GameEvents>();
    public List<string> objectsToDetect = new List<string>();

    private Dictionary<string, GameEvents> broadcastDictionary = new Dictionary<string, GameEvents>();
    private Dictionary<string, int> inGrinder = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        grinder = Instantiate(openGrinder, transform.position, Quaternion.Euler(0, 180, 0));
        detector = grinder.transform.GetChild(0).gameObject;
        for (int i = 0; i < listOfInputMeatBroadcast.Count; i++)
        {
            broadcastDictionary[objectsToDetect[i]] = listOfInputMeatBroadcast[i];
        }
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
        bool meatPresent = false;
        //count up and broadcast the items in the grinder
        foreach(KeyValuePair<string, int> kvp in inGrinder)
        {
            if(objectsToDetect.Contains(kvp.Key))
            {
                broadcastDictionary[kvp.Key].Raise(this, kvp.Value);
                meatPresent = true;
            }
        }
        //start the production of a can
        if (meatPresent)
        {
            grinderComplete.Raise(this, meatPresent);
        }
        yield return new WaitForSeconds(waitTime);
        Destroy(grinder);
        grinder = Instantiate(closedGrinder, transform.position, Quaternion.Euler(0, 180, 0));
    }

    public void canCheck(Component sender, object Data)
    {
        if (Data is bool)
        {
            newCan = Instantiate(can, canSpawn.transform.position, Quaternion.identity);
            newCan.GetComponent<Rigidbody>().velocity = transform.up * canSpeed;
            newCan.transform.parent = canSpawn.transform;
            Destroy(grinder);
            grinder = Instantiate(openGrinder, transform.position, Quaternion.Euler(0, 180, 0));
            newCan.name = Data.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (inGrinder.ContainsKey(other.gameObject.name))
        {
            int amount = inGrinder[other.gameObject.name];
            inGrinder[other.gameObject.name] = amount + 1;
        }
        else
        {
            inGrinder.Add(other.gameObject.name, 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        int amount = inGrinder[other.gameObject.name];
        inGrinder[other.gameObject.name] = amount - 1;
    }
}
