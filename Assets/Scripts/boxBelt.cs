using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxBelt : MonoBehaviour
{
    [SerializeField]
    int duration;
    [SerializeField]
    float speed;
    private Material texture;
    private bool move;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        move = false;
        texture = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move)
        {
            if (0 <= counter && counter <= 129){
                counter += 1;
                //wait
            }
            else if (130 <= counter && counter <= (130 + duration)){
                texture.mainTextureOffset -= new Vector2(0,1) * speed * Time.fixedDeltaTime;
                counter += 1;
            }
            else {
                counter = 0;
                move = false;
            } 
        }
    }

    public void moveBelt()
    {
        move = true;
    }
}
