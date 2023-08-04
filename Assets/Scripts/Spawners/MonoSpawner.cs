using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedBoxSpawner : MonoBehaviour
{
    public GameEvents OnCollision;
    public GameObject spawnItem;
    public GameObject targetItem;

    public void OnCollisionWithFood(Component sender, object data)
    {
        Debug.Log(data);
        if (data.ToString() == targetItem.name)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        GameObject newSpawnedObject = Instantiate(spawnItem, transform.position, Quaternion.identity);
        newSpawnedObject.transform.parent = transform;
    }

}
