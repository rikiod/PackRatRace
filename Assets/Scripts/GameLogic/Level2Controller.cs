using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

//no need to implement listener for onBoxPacked. It is automatically called at the end of scan completed
//need to implement listener for detectScanCompleted which causes controller to broadcast which objectives are correct and then cycle to onBoxPacked
//need to implement 4 listeners for getting the input of the objects added
public class Level2Controller : MonoBehaviour
{
    //Level Controller stores and broadcast the orders
    private System.Random random = new System.Random();
    public List<string> objects = new List<string>();
    public int noOfCans = new int();
    public int inputNumber = new int();

    [Header("Events")] //these gameEvents are for broadcasting the current order
    public GameEvents Meat1OrderUpdate;
    public GameEvents Meat2OrderUpdate;
    public GameEvents Meat3OrderUpdate;
    public GameEvents Meat4OrderUpdate;
    public GameEvents currentCan; // implement this broadcast
    public GameEvents resetScreen;

    [Header("EventsList")]
    public List<GameEvents> gameEvents = new List<GameEvents>(); //List of gameEvents in same sequence as the objects list
    public Dictionary<string, GameEvents> objectToDetectAndBroadcast = new Dictionary<string, GameEvents>(); //Creates a dictionary with gameEvents and objects list

    private List<Dictionary<string, int>> listOfLevelRequirements = new List<Dictionary<string, int>>();
    private Dictionary<string, int> input = new Dictionary<string, int>();

    private bool beginFinalCountdown = false;
    private int counter = 0;

    [SerializeField]
    private int levelCounter = 0;
    [SerializeField]
    private bool correctOrder;
    [SerializeField]
    private bool scanCompletedBool = false;
    public GameEvents orderCorrect; // broadcast if input for orders are correct

    // Start is called before the first frame update
    void Start()
    {
        int noOfObjects = objects.Count;
        for (int boxNo = 0; boxNo < noOfCans; boxNo++)
        {
            Dictionary<string, int> levelObjectives = new Dictionary<string, int>();
            List<int> splitNumbers = RandomDistribution(inputNumber, noOfObjects);
            for (int i = 0; i < noOfObjects; i++)
            {
                Debug.Log(objects[i] + " : " + splitNumbers[i].ToString());
                levelObjectives[objects[i]] = splitNumbers[i];
            }
            listOfLevelRequirements.Add(levelObjectives);
        }

        for (int i = 0; i < objects.Count; i++)
        {
            objectToDetectAndBroadcast[objects[i]] = gameEvents[i];
        }
        onBoxPacked();
    }

    public void onBoxPacked()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            input[objects[i]] = 0;
        }
        broadcastBoxOrder();
        currentCan.Raise(this, levelCounter);
    }

    void broadcastBoxOrder()
    {
        Meat1OrderUpdate.Raise(this, listOfLevelRequirements[levelCounter]["Meat1"].ToString());
        Meat2OrderUpdate.Raise(this, listOfLevelRequirements[levelCounter]["Meat2"].ToString());
        Meat3OrderUpdate.Raise(this, listOfLevelRequirements[levelCounter]["Meat3"].ToString());
        Meat4OrderUpdate.Raise(this, listOfLevelRequirements[levelCounter]["Meat4"].ToString());
        currentCan.Raise(this, levelCounter);
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

    public void Meat1Detected(Component sender, object data)
    {
        input["Meat1"] = int.Parse(data.ToString());
    }
    public void Meat2Detected(Component sender, object data)
    {
        input["Meat2"] = int.Parse(data.ToString());
    }
    public void Meat3Detected(Component sender, object data)
    {
        input["Meat3"] = int.Parse(data.ToString());
    }
    public void Meat4Detected(Component sender, object data)
    {
        input["Meat4"] = int.Parse(data.ToString());
    }

    private void FixedUpdate()
    {
        if (beginFinalCountdown)
        {
            counter++;
            if (counter == 100)
            {
                resetScreen.Raise(this, true);
            }
            else if (counter == 101)
            {
                counter = 0;
                beginFinalCountdown = false;
                levelCounter++;
                onBoxPacked();
            }
        }
    }
    public void detectScanCompleted(Component sender, object data)
    {
        /*        foreach (KeyValuePair<string, int> kvp in input)
                {
                    Debug.Log(kvp.Key + ": " + kvp.Value);
                }*/
        if (data is bool)
        {
            if (levelCounter <= noOfCans && (bool)data)
            {
                correctOrder = true;
                foreach (KeyValuePair<string, int> kvp in listOfLevelRequirements[levelCounter])
                {
                    if (kvp.Value == input[kvp.Key])
                    {
                        objectToDetectAndBroadcast[kvp.Key].Raise(this, true);
                    }
                    else
                    {
                        objectToDetectAndBroadcast[kvp.Key].Raise(this, false);
                        correctOrder = false;
                    }
                }
                orderCorrect.Raise(this, correctOrder);
            }
            beginFinalCountdown = true;
        }
    }
}
