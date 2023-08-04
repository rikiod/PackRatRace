using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grinderScript : MonoBehaviour
{
    [SerializeField]
    float canSpeed;
    public GameObject can;
    public GameObject openGrinder;
    public GameObject closedGrinder;
    public GameObject canSpawn;
    private GameObject grinder;
    private int counter;
    private bool closed;
    private GameObject newCan;

    // Start is called before the first frame update
    void Start()
    {
        grinder = Instantiate(openGrinder, transform.position, Quaternion.Euler(0, 180, 0));
        closed = false;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (closed)
        {
            //run the grinding and spitting out of the can
            if (0 <= counter && counter <= 199)
            {
                counter += 1;
            }
            else
            {
                newCan = Instantiate(can, canSpawn.transform.position, Quaternion.identity);
                newCan.GetComponent<Rigidbody>().velocity = transform.up * canSpeed;
                newCan.transform.parent = canSpawn.transform;
                Destroy(grinder);
                grinder = Instantiate(openGrinder, transform.position, Quaternion.Euler(0, 180, 0));
                counter = 0;
                closed = false;
            }

        }
    }

    public void closeGrinder()
    {
        Destroy(grinder);
        grinder = Instantiate(closedGrinder, transform.position, Quaternion.Euler(0, 180, 0));
        closed = true;
    }
}
