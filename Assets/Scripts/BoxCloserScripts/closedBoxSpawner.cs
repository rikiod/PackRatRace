using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closedBoxSpawner : MonoBehaviour
{
    public GameObject spawnItem;
    public void spawnBox(Component sender, object data)
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject newSpawnedObject = Instantiate(spawnItem, transform.position, Quaternion.identity);
        newSpawnedObject.transform.parent = transform;
    }
}
