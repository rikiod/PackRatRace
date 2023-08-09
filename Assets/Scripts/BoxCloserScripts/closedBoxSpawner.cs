using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closedBoxSpawner : MonoBehaviour
{
    private bool sendBox;
    private int counter;
    private GameObject newBox;

    [SerializeField]
    public float speed;
    [SerializeField]
    public int duration;

    public GameObject spawnItem;
    public void spawnBox(Component sender, object data)
    {
        Spawn();
    }

    void Start()
    {
        sendBox = false;
        counter = 0;
    }

    void FixedUpdate()
    {
        if (sendBox)
        {
            if (0 <= counter && counter <= 35)
            {
                counter += 1;
                //wait
            }
            else if (36 <= counter && counter <= (66 + duration))
            {
                newBox.transform.position -= transform.forward * speed * Time.fixedDeltaTime;
                counter += 1;
            }
            else
            {
                counter = 0;
                sendBox = false;
                Destroy(newBox);
            }
        }
    }

    public void Spawn()
    {
        newBox = Instantiate(spawnItem, transform.position, Quaternion.Euler(0, 90, 0));
        sendBox = true;
    }
}
