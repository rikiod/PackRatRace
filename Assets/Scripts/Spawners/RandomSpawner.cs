using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public List<GameObject> spawnItemList = new List<GameObject>();

    public float frequency;
    public float initialSpeed;

    float lastSpawnedTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawnedTime + frequency)
        {
            GameObject spawnItem = spawnItemList[GetRandomNumber(0, spawnItemList.Count)];
            Spawn(spawnItem);
            lastSpawnedTime = Time.time;
        }
    }

    public void Spawn(GameObject spawnItem)
    {
        GameObject newSpawnedObject = Instantiate(spawnItem, transform.position + new Vector3(0,1,0), Quaternion.identity);
        newSpawnedObject.GetComponent<Rigidbody>().velocity = transform.forward * initialSpeed;
        newSpawnedObject.transform.parent = transform;
        newSpawnedObject.GetComponent<Rigidbody>().position = transform.position;
    }

    int GetRandomNumber(int minValue, int maxValue)
    {
        return Random.Range(minValue, maxValue);
    }
}