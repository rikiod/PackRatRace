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

    private List<GameObject> toDestroy = new List<GameObject>();

    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        grinder = Instantiate(openGrinder, transform.position, Quaternion.Euler(0, 180, 0));
        // detector = grinder.transform.GetChild(0).gameObject;
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
        // Debug.Log("HELLO");
        bool meatPresent = false;
        //count up and broadcast the items in the grinder
        foreach(KeyValuePair<string, int> kvp in inGrinder)
        {
            Debug.Log(kvp.Key);
            if(objectsToDetect.Contains(kvp.Key))
            {
                // Debug.Log("GDI");
                broadcastDictionary[kvp.Key].Raise(this, kvp.Value);
                //clear the counting dictionary
                meatPresent = true;
            }
        }
        //ad-hoc dict reset
        inGrinder = new Dictionary<string, int>();
        //signal the ingredients to be checked
        if (meatPresent)
        {
            // Debug.Log("BITCH PLZ");
            grinderComplete.Raise(this, meatPresent);
        }
        // StartCoroutine(cycleGrinder());
    }

    public void canCheck(Component sender, object Data)
    {
        if (Data is bool)
        {
            coroutine = cycleGrinder(Data);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator cycleGrinder(object Data)
    {
        foreach (GameObject meat in toDestroy)
        {
            Destroy(meat);
        }
        Destroy(grinder);
        grinder = Instantiate(closedGrinder, transform.position, Quaternion.Euler(0, 180, 0));
        yield return new WaitForSeconds(waitTime);
        newCan = Instantiate(can, canSpawn.transform.position, Quaternion.identity);
        newCan.GetComponent<Rigidbody>().velocity = transform.up * canSpeed;
        newCan.transform.parent = canSpawn.transform;
        Destroy(grinder);
        grinder = Instantiate(openGrinder, transform.position, Quaternion.Euler(0, 180, 0));
        newCan.name = Data.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("HELP");
        toDestroy.Add(other.gameObject);
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
        toDestroy.Remove(other.gameObject);
        Debug.Log("MEEE");
        int amount = inGrinder[other.gameObject.name];
        inGrinder[other.gameObject.name] = amount - 1;
    }
}
