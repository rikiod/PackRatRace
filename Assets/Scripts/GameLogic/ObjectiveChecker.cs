using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectiveChecker : MonoBehaviour
{
    private Dictionary<string, int> record = new Dictionary<string, int>();
    private Dictionary<string, int> input = new Dictionary<string, int>();

    [Header("Events")]
    public List<string> objectToDetect = new List<string>();
    public List<GameEvents> gameEvents = new List<GameEvents>();
    public Dictionary<string, GameEvents> objectToDetectAndBroadcast = new Dictionary<string, GameEvents>();

    [SerializeField]
    private bool correctOrder = true;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objectToDetect.Count; i++)
        {
            objectToDetectAndBroadcast[objectToDetect[i]] = gameEvents[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Food1Order(Component sender, object data)
    {
        record["Food1"] = int.Parse(data.ToString());
    }
    public void Food2Order(Component sender, object data)
    {
        record["Food2"] = int.Parse(data.ToString());
    }
    public void Food3Order(Component sender, object data)
    {
        record["Food3"] = int.Parse(data.ToString());
    }
    public void Food4Order(Component sender, object data)
    {
        record["Food4"] = int.Parse(data.ToString());
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

    public void scanCompleted(Component sender, object data)
    {
        foreach (KeyValuePair<string, int> kvp in record)
        {
            if (kvp.Value == input[kvp.Key] || kvp.Value == 0)
            {
                objectToDetectAndBroadcast[kvp.Key].Raise(this, true);
            }
            else
            {
                objectToDetectAndBroadcast[kvp.Key].Raise(this, false);
            }
        }
    }
}
