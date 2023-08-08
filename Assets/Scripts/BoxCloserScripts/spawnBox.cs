using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBox : MonoBehaviour
{
    public GameObject boxItem;
    [SerializeField]
    public float speed;
    [SerializeField]
    public int duration;

    private bool sendBox;
    private GameObject newBox;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        sendBox = false;
        counter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sendBox)
        {
            if (0 <= counter && counter <= 129){
                counter += 1;
                //wait
            }
            else if (130 <= counter && counter <= (130 + duration)){
                newBox.transform.position -= transform.forward * speed * Time.fixedDeltaTime;
                counter += 1;
            }
            else {
                counter = 0;
                sendBox = false;
            }
        }
    }

    public void spawnABox()
    {
        newBox = Instantiate(boxItem, transform.position, Quaternion.Euler(0, 90, 0));
        newBox.transform.parent = transform;
        sendBox = true;
    }
}
