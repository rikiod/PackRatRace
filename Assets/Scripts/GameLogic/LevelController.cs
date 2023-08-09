using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

//no need to implement listener for onBoxPacked. It is automatically called at the end of scan completed
//need to implement listener for detectScanCompleted which causes controller to broadcast which objectives are correct and then cycle to onBoxPacked
//need to implement 4 listeners for getting the input of the objects added
public class LevelController : MonoBehaviour 
{
    //Level Controller stores and broadcast the orders
    private System.Random random = new System.Random();
    public List<string> objects = new List<string>();
    public int noOfBoxes = new int();
    public int inputNumber = new int();

    [Header("Events")] //these gameEvents are for broadcasting the current order
    public GameEvents Food1OrderUpdate;
    public GameEvents Food2OrderUpdate;
    public GameEvents Food3OrderUpdate;
    public GameEvents Food4OrderUpdate;
    public GameEvents currentBox; // implement this broadcast
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
        for (int boxNo = 0; boxNo < noOfBoxes; boxNo++)
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
        currentBox.Raise(this, levelCounter);
    }

    void broadcastBoxOrder()
    {
        Food1OrderUpdate.Raise(this, listOfLevelRequirements[levelCounter]["Food1"].ToString());
        Food2OrderUpdate.Raise(this, listOfLevelRequirements[levelCounter]["Food2"].ToString());
        Food3OrderUpdate.Raise(this, listOfLevelRequirements[levelCounter]["Food3"].ToString());
        Food4OrderUpdate.Raise(this, listOfLevelRequirements[levelCounter]["Food4"].ToString());
        currentBox.Raise(this, levelCounter);
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

    public void Food1Detected(Component sender, object data)
    {
        input["Food1"] = int.Parse(data.ToString());
    }
    public void Food2Detected(Component sender, object data)
    {
        input["Food2"] = int.Parse(data.ToString());
    }
    public void Food3Detected(Component sender, object data)
    {
        input["Food3"] = int.Parse(data.ToString());
    }
    public void Food4Detected(Component sender, object data)
    {
        input["Food4"] = int.Parse(data.ToString());
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
        if (levelCounter <= noOfBoxes)
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