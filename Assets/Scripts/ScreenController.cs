using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public SpriteRenderer check1;
    public SpriteRenderer check2;
    public SpriteRenderer check3;
    public SpriteRenderer check4;
    public SpriteRenderer num1;
    public SpriteRenderer num2;
    public SpriteRenderer num3;
    public SpriteRenderer num4;
    public SpriteRenderer x1;
    public SpriteRenderer x2;
    public SpriteRenderer x3;
    public SpriteRenderer x4;
    public SpriteRenderer item1;
    public SpriteRenderer item2;
    public SpriteRenderer item3;
    public SpriteRenderer item4;
    public SpriteRenderer bigThing;

    public Sprite bullet;
    public Sprite bulletCheck;
    public Sprite sp_one;
    public Sprite sp_two;
    public Sprite sp_three;
    public Sprite sp_four;
    public Sprite sp_five;
    public Sprite bigCheck;
    public Sprite bigX;



    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reset() {
        bigThing.enabled = false;
        
        check1.enabled = true;
        check2.enabled = true;
        check3.enabled = true;
        check4.enabled = true;

        check1.sprite = bullet;
        check2.sprite = bullet;
        check3.sprite = bullet;
        check4.sprite = bullet;

        num1.enabled = false;
        num2.enabled = false;
        num3.enabled = false;
        num4.enabled = false;
        x1.enabled = false;
        x2.enabled = false;
        x3.enabled = false;
        x4.enabled = false;
        item1.enabled = false;
        item2.enabled = false;
        item3.enabled = false;
        item4.enabled = false;

    }
    void Food1Order(float quantity) {
        // GameObject check = transform.Find("Check1").gameObject;
        // GameObject num = transform.Find("Num1").gameObject;
        // GameObject times = transform.Find("x1").gameObject;
        // GameObject item = transform.Find("Item1").gameObject;
        
        if (quantity != 0) {

            num1.enabled = true;
            x1.enabled = true;
            item1.enabled = true;
            
            if (quantity == 1) {
                num1.sprite = sp_one;
            }
            else if (quantity == 2) {
                num1.sprite = sp_two;
            }
            else if (quantity == 3) {
                num1.sprite = sp_three;
            }
            else if (quantity == 4) {
                num1.sprite = sp_four;
            }
            else if (quantity == 5) {
                num1.sprite = sp_five;
            }
        }
    }

    void Food2Order(float quantity) {
        
        if (quantity != 0) {

            num2.enabled = true;
            x2.enabled = true;
            item2.enabled = true;
            
            if (quantity == 1) {
                num2.sprite = sp_one;
            }
            else if (quantity == 2) {
                num2.sprite = sp_two;
            }
            else if (quantity == 3) {
                num2.sprite = sp_three;
            }
            else if (quantity == 4) {
                num2.sprite = sp_four;
            }
            else if (quantity == 5) {
                num2.sprite = sp_five;
            }
        }
    }

    void Food3Order(float quantity) {
        
        if (quantity != 0) {

            num3.enabled = true;
            x3.enabled = true;
            item3.enabled = true;
            
            if (quantity == 1) {
                num3.sprite = sp_one;
            }
            else if (quantity == 2) {
                num3.sprite = sp_two;
            }
            else if (quantity == 3) {
                num3.sprite = sp_three;
            }
            else if (quantity == 4) {
                num3.sprite = sp_four;
            }
            else if (quantity == 5) {
                num3.sprite = sp_five;
            }
        }
    }

    void Food4Order(float quantity) {
        
        if (quantity != 0) {

            num4.enabled = true;
            x4.enabled = true;
            item4.enabled = true;
            
            if (quantity == 1) {
                num4.sprite = sp_one;
            }
            else if (quantity == 2) {
                num4.sprite = sp_two;
            }
            else if (quantity == 3) {
                num4.sprite = sp_three;
            }
            else if (quantity == 4) {
                num4.sprite = sp_four;
            }
            else if (quantity == 5) {
                num4.sprite = sp_five;
            }
        }
    }
    
    void ItemComplete(int itemNumber) {
        if (itemNumber == 1) {
            check1.sprite = bulletCheck;
        }
        else if (itemNumber == 2) {
            check2.sprite = bulletCheck;
        }
        else if (itemNumber == 3) {
            check3.sprite = bulletCheck;
        }
        else if (itemNumber == 4) {
            check4.sprite = bulletCheck;
        }
    }

    void OrderComplete () {
        bigThing.sprite = bigCheck;
        bigThing.enabled = true;
    }

    void OrderFailed () {
        bigThing.sprite = bigX;
        bigThing.enabled = true;
    }
}
