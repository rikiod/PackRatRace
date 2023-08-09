using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CheckCollision : MonoBehaviour //needs to implement listener for onCall
{
    [Header("Events and Objects to Detect")]
    public List<string> objectToDetect = new List<string>();
    public List<GameEvents> gameEvents = new List<GameEvents>();
    public Dictionary<string, GameEvents> objectToDetectAndBroadcast = new Dictionary<string, GameEvents>();

    [Header("Events")]
    public GameEvents scanCompleted;

    private bool toBroadcast = false;
    private Dictionary<string, int> counter = new Dictionary<string, int>();
    private bool runCollision = true;

    [SerializeField]
    private List<GameObject> detectedItems = new List<GameObject>();
    
    private void Start()
    {
        for (int i = 0; i < objectToDetect.Count; i++)
        {
            objectToDetectAndBroadcast[objectToDetect[i]] = gameEvents[i];
            counter[objectToDetect[i]] = 0;
        }
    }

    private void Update()
    {
        if (toBroadcast)
        {
            Broadcast();
            toBroadcast = false;
            resetCounter();
            scanCompleted.Raise(this, true);
        }
    }
    void resetCounter()
    {
        for (int i = 0; i < objectToDetect.Count; i++)
        {
            counter[objectToDetect[i]] = 0;
        }
    }

    public void Broadcast()
    {
        foreach (KeyValuePair<string, GameEvents> entry in objectToDetectAndBroadcast)
        {
            entry.Value.Raise(this, counter[entry.Key]);
        }
    }
    public void onCall(Component sender, object data)
    {
        if (data is bool)
        {
            runCollision = false;
            bool value = (bool)data;
            if (!value)
            {
                Debug.Log("Broadcasting");
                runCollision = true;
                toBroadcast = true;
            }
            else
            {
                for (int i = detectedItems.Count - 1; i >= 0; i--)
                {
/*                    Debug.Log(detectedItems[i]);*/
                    if (detectedItems[i] != null)
                    {
                        if (objectToDetect.Contains(detectedItems[i].name))
                        {
                            counter[detectedItems[i].gameObject.name]++;
                        }
                    }
                }
                    
            }
            for (int i = detectedItems.Count - 1; i >= 0; i--)
            {
/*                    Debug.Log(detectedItems[i]);*/
                if (detectedItems[i] != null)
                {
                    if (objectToDetect.Contains(detectedItems[i].name) || detectedItems[i].name == "BoxOpen")
                    {
                        Destroy(detectedItems[i].gameObject);
                    }
                }
            }
            detectedItems.Clear();
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (runCollision)
        {
            detectedItems.Add(other.gameObject);
        }
    }
}
