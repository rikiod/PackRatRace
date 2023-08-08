using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Cat lv2 hallway movement
// call StopMoving(); to stop at the end of the game, when spooky scene


public class CatMovementLevelTwo : MonoBehaviour
{
    [SerializeField] Vector3 hidingPoint;
    [SerializeField] Vector3 inHall;
    [SerializeField] float farthestx;
    [SerializeField] float closestx;
    [SerializeField] float minActionTime = 10f;
    [SerializeField] float maxActionTime = 30f;
    [SerializeField] float minWaitTime = 6f;
    [SerializeField] float maxWaitTime = 12f;
    bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = hidingPoint;
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport() {
        while (isMoving) {
            float waitTime = Random.Range(minActionTime, maxActionTime);
            yield return new WaitForSeconds(waitTime);

            float newx = Random.Range(farthestx, closestx);
            transform.position = new Vector3(newx, inHall.y, inHall.z);

            float waitTime2 = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime2);

            transform.position = hidingPoint;
        }
    }

    public void CreepyTime() {

        isMoving = false;

    }
}


