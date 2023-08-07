using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //Level Controller stores and broadcast the orders
    private System.Random random = new System.Random();
    public List<string> objects = new List<string>();
    public int noOfBoxes = new int();
    public int inputNumber = new int();
    public GameEvents Food1OrderUpdate;
    public GameEvents Food2OrderUpdate;
    public GameEvents Food3OrderUpdate;
    public GameEvents Food4OrderUpdate;

    [SerializeField]
    private List<Dictionary<string, int>> listOfLevelRequirements = new List<Dictionary<string, int>>();
    [SerializeField]
    private int levelCounter = 0;

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
                Debug.Log(objects[i] + " : "+splitNumbers[i].ToString());
                levelObjectives[objects[i]] = splitNumbers[i];
            }
            listOfLevelRequirements.Add(levelObjectives);
        }
        broadcastBoxOrder(listOfLevelRequirements, levelCounter);
        levelCounter++;
    }

    public void BoxPacked(Component sender, object data)
    {
        broadcastBoxOrder(listOfLevelRequirements, levelCounter);
        levelCounter++;
    }

    void broadcastBoxOrder(List<Dictionary<string, int>> listOfLevelRequirements, int levelCounter)
    {
        Food1OrderUpdate.Raise(this, listOfLevelRequirements[levelCounter]["Food1"].ToString());
        Food2OrderUpdate.Raise(this, listOfLevelRequirements[levelCounter]["Food2"].ToString());
        Food3OrderUpdate.Raise(this, listOfLevelRequirements[levelCounter]["Food3"].ToString());
        Food4OrderUpdate.Raise(this, listOfLevelRequirements[levelCounter]["Food4"].ToString());
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
