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

    public delegate void updateScreen();

    public static event Action<Dictionary<string, int>> OnCanning;


    //for the logic
    [SerializeField]
    public List<GameObject> meats = new List<GameObject>();


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

    private void doSomething(){
        //generate orders
        

        //send orders to screen

        //compare to what is given

        //update the screen 

        //order the can accordingly

        //receive good/bad completion from bin

        //update the screen
    }

    public List<int> RandomDistribution(int originalNumber, int arraySize)
    {
        List<int> resultArray = new List<int>();

        System.Random random = new System.Random();
        int maxValue = originalNumber / arraySize;

        for (int i = 0; i < arraySize - 1; i++)
        {
            int randomValue = random.Next(0, maxValue + 1);
            resultArray.Add(randomValue);
            originalNumber -= randomValue;
        }

        resultArray.Add(originalNumber);

        // Shuffle the list to make the distribution random
        for (int i = 0; i < resultArray.Count; i++)
        {
            int temp = resultArray[i];
            int randomIndex = random.Next(i, resultArray.Count);
            resultArray[i] = resultArray[randomIndex];
            resultArray[randomIndex] = temp;
        }

        return resultArray;
    }
}
