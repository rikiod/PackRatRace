using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyor_behaviour : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset -= new Vector2(0,1) * speed * Time.deltaTime;
    }

    void FixedUpdate(){
        Vector3 pos = GetComponent<Rigidbody>().position;
        GetComponent<Rigidbody>().position += transform.forward * speed * Time.fixedDeltaTime * 3;
        GetComponent<Rigidbody>().MovePosition(pos);
    }
}
