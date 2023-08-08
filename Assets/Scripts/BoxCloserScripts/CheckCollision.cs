using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CheckCollision : MonoBehaviour
{
    [Header("Events and Objects to Detect")]
    public List<string> objectToDetect = new List<string>();
    public List<GameEvents> gameEvents = new List<GameEvents>();
    public Dictionary<string, GameEvents> objectToDetectAndBroadcast = new Dictionary<string, GameEvents>();

    [Header("Events")]
    public GameEvents scanCompleted;

    private bool isActive = false;
    private bool toBroadcast = false;
    private Dictionary<string, int> counter = new Dictionary<string, int>();
    
    private void Start()
    {
        for (int i = 0; i < objectToDetect.Count; i++)
        {
            objectToDetectAndBroadcast[objectToDetect[i]] = gameEvents[i];
        }
        resetCounter();
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
        foreach (KeyValuePair<string, int> entry in counter)
        {
            counter[entry.Key] = 0;
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
            bool value = (bool)data;
            isActive = value;
            if (!value)
            {
                toBroadcast = true;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (objectToDetectAndBroadcast.ContainsKey(other.gameObject.name) && isActive)
        {
/*            Debug.Log(other.gameObject.name);*/
            counter[other.gameObject.name]++;
            Destroy(other.gameObject);
        }
    }
}
