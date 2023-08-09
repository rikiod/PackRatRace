using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
   public List<GameObject> spawnItemList = new List<GameObject>();
   public GameObject ratHead;

    public float frequency;
    public float initialSpeed;

    float lastSpawnedTime;
    bool spawnbool = true;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawnedTime + frequency && spawnbool)
        {
            int num = GetRandomNumber(0, spawnItemList.Count);
            GameObject spawnItem = spawnItemList[num];
            Spawn(spawnItem);
            lastSpawnedTime = Time.time;
        }
    }

    public void Spawn(GameObject spawnItem)
    {

        GameObject newSpawnedObject = Instantiate(spawnItem, transform.position, Quaternion.identity);
        newSpawnedObject.GetComponent<Rigidbody>().velocity = transform.forward * initialSpeed;
        newSpawnedObject.transform.parent = transform;
        newSpawnedObject.GetComponent<Rigidbody>().position = transform.position;
        newSpawnedObject.name = spawnItem.name;
    }

    int GetRandomNumber(int minValue, int maxValue)
    {
        return Random.Range(minValue, maxValue);
    }

    public void CreepyTime() {

        spawnbool = false;
        StartCoroutine(Waitt());

    }

    IEnumerator Waitt() {
        yield return new WaitForSeconds(2f);
        Spawn(ratHead);
    }


}