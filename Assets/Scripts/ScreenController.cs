using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;

// 4 listeners for getting order requirements
// 4 listeners for checking unput requirements
// 1 listener for if box is completely good
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
    // public SpriteRenderer x1;
    // public SpriteRenderer x2;
    // public SpriteRenderer x3;
    // public SpriteRenderer x4;
    public SpriteRenderer item1;
    public SpriteRenderer item2;
    public SpriteRenderer item3;
    public SpriteRenderer item4;
    public SpriteRenderer bigThing;

    public Sprite bullet;
    public Sprite bulletCheck;
    public Sprite sp_zero;
    public Sprite sp_one;
    public Sprite sp_two;
    public Sprite sp_three;
    public Sprite sp_four;
    public Sprite sp_five;
    public Sprite bigCheck;
    public Sprite bigX;
    public Sprite blueCan;

    private bool FoodUpdate = false;
    private int Food1;
    private int Food2;
    private int Food3;
    private int Food4;

    private bool Food1Complete;
    private bool Food2Complete;
    private bool Food3Complete;
    private bool Food4Complete;

    private bool orderCompleted;
    private bool orderCorrect;
    private bool resetScreen;
    
    private bool creepyness = false;

    // Start is called before the first frame update
    void Start()
    {
        Reset();

    }

    void Update()
    {
        if (resetScreen)
        {
            Reset();
            resetScreen = false;
            FoodUpdate = true;
        }
        else if (FoodUpdate)
        {
            Food1Order(Food1);
            Food2Order(Food2);
            Food3Order(Food3);
            Food4Order(Food4);
            if (Food1Complete)
            {
                ItemComplete(1);
            }
            if (Food2Complete)
            {
                ItemComplete(2);
            }
            if (Food3Complete)
            {
                ItemComplete(3);
            }
            if (Food4Complete)
            {
                ItemComplete(4);
            }
            if (orderCompleted)
            {
                if (orderCorrect)
                {
                    OrderComplete();
                }
                else
                {
                    OrderFailed();
                }
            }
            else
            {
                FoodUpdate = false;
            }
            orderCompleted = false;
        }


        if (creepyness) {
            Food5Order();
        }

    }



    //To recieve new order
    public void Food1OrderUpdate(Component sender, object data)
    {
        FoodUpdate = true;
        Food1 = int.Parse(data.ToString());
/*        Debug.Log("Food1: " + data.ToString());*/
    }
    public void Food2OrderUpdate(Component sender, object data)
    {
        FoodUpdate = true;
        Food2 = int.Parse(data.ToString());
/*        Debug.Log("Food2: " + data.ToString());*/
    }
    public void Food3OrderUpdate(Component sender, object data)
    {
        FoodUpdate = true;
        Food3 = int.Parse(data.ToString());
/*        Debug.Log("Food3: " + data.ToString());*/
    }
    public void Food4OrderUpdate(Component sender, object data)
    {
        FoodUpdate = true;
        Food4 = int.Parse(data.ToString());
/*        Debug.Log("Food4: " + data.ToString());*/
    }

    //To check if order is correct
    public void Food1Update(Component sender, object data)
    {
        if (data is bool)
        {
            Food1Complete = (bool)data;
        }
        FoodUpdate = true;
    }
    public void Food2Update(Component sender, object data)
    {
        if (data is bool && (bool)data)
        {
            Food2Complete = (bool)data;
        }
        FoodUpdate = true;
    }
    public void Food3Update(Component sender, object data)
    {
        if (data is bool && (bool)data)
        {
            Food3Complete = (bool)data;
        }
        FoodUpdate = true;
    }
    public void Food4Update(Component sender, object data)
    {
        if (data is bool && (bool)data)
        {
            Food4Complete = (bool)data;
        }
        FoodUpdate = true;
    }

    //Check to reset screen
    public void ResetScreen(Component sender, object data)
    {
        if (data is bool)
        {
            resetScreen = (bool)data;
        }
    }

    void Reset() {
/*        Debug.Log("resetScreen");*/
        bigThing.enabled = false;
        
        // check1.enabled = false;
        // check2.enabled = false;
        // check3.enabled = false;
        // check4.enabled = false;

        check1.sprite = bullet;
        check2.sprite = bullet;
        check3.sprite = bullet;
        check4.sprite = bullet;

        // num1.enabled = false;
        // num2.enabled = false;
        // num3.enabled = false;
        // num4.enabled = false;
        // // x1.enabled = false;
        // // x2.enabled = false;
        // // x3.enabled = false;
        // // x4.enabled = false;
        // item1.enabled = false;
        // item2.enabled = false;
        // item3.enabled = false;
        // item4.enabled = false;

        item1.color = Color.grey;
        item2.color = Color.grey;
        item3.color = Color.grey;
        item4.color = Color.grey;

        num1.sprite = sp_zero;
        num2.sprite = sp_zero;
        num3.sprite = sp_zero;
        num4.sprite = sp_zero;

        Food1Complete = false;
        Food2Complete = false;
        Food3Complete = false;
        Food4Complete = false;

    }
    private void Food1Order(int quantity) {
        /*        GameObject check = transform.Find("Check1").gameObject;
                GameObject num = transform.Find("Num1").gameObject;
                GameObject times = transform.Find("x1").gameObject;
                GameObject item = transform.Find("Item1").gameObject;*/


        //num1.enabled = true;
        //x1.enabled = true;
        //item1.enabled = true;
        //check1.enabled = true;

/*        Debug.Log("Food1ValueUpdated");*/
        check1.sprite = bullet;
        if (quantity == 0)
        {
            num1.sprite = sp_zero;
            item1.color = Color.grey;
        }
        else
        {
            item1.color = Color.white;
            if (quantity == 1)
            {
                num1.sprite = sp_one;
            }
            else if (quantity == 2)
            {
                num1.sprite = sp_two;
            }
            else if (quantity == 3)
            {
                num1.sprite = sp_three;
            }
            else if (quantity == 4)
            {
                num1.sprite = sp_four;
            }
            else if (quantity == 5)
            {
                num1.sprite = sp_five;
            }
        }
    }
    private void Food2Order(int quantity) {

/*        Debug.Log("Food2ValueUpdated");*/
        check2.sprite = bullet;
        if (quantity == 0)
        {
            num2.sprite = sp_zero;
            item2.color = Color.grey;
        }
        else
        {
            item2.color = Color.white;
            if (quantity == 1)
            {
                num2.sprite = sp_one;
            }
            else if (quantity == 2)
            {
                num2.sprite = sp_two;
            }
            else if (quantity == 3)
            {
                num2.sprite = sp_three;
            }
            else if (quantity == 4)
            {
                num2.sprite = sp_four;
            }
            else if (quantity == 5)
            {
                num2.sprite = sp_five;
            }
        }
    }
    private void Food3Order(int quantity) {

/*        Debug.Log("Food3ValueUpdated");*/
        check3.sprite = bullet;
        if (quantity == 0)
        {
            num3.sprite = sp_zero;
            item3.color = Color.grey;
        }
        else
        {
            item3.color = Color.white;
            if (quantity == 1)
            {
                num3.sprite = sp_one;
            }
            else if (quantity == 2)
            {
                num3.sprite = sp_two;
            }
            else if (quantity == 3)
            {
                num3.sprite = sp_three;
            }
            else if (quantity == 4)
            {
                num3.sprite = sp_four;
            }
            else if (quantity == 5)
            {
                num3.sprite = sp_five;
            }
        }

    }
    private void Food4Order(int quantity) {

/*        Debug.Log("Food4ValueUpdated");*/
        check4.sprite = bullet;
        if (quantity == 0)
        {
            num4.sprite = sp_zero;
            item4.color = Color.grey;
        }
        else
        {
            item4.color = Color.white;
            if (quantity == 1)
            {
                num4.sprite = sp_one;
            }
            else if (quantity == 2)
            {
                num4.sprite = sp_two;
            }
            else if (quantity == 3)
            {
                num4.sprite = sp_three;
            }
            else if (quantity == 4)
            {
                num4.sprite = sp_four;
            }
            else if (quantity == 5)
            {
                num4.sprite = sp_five;
            }
        }

    }

    private void Food5Order() {

        Reset();
        check1.sprite = bullet;
        num1.sprite = sp_one;
        item1.sprite = blueCan;
        item1.color = Color.white;

    }

    // input is the number of the food type => Just adds the check marks
    private void ItemComplete(int itemNumber) {
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

    // to check if overall order is correct
    public void onOrderComplete (Component sender, object data)
    {
        if (data is bool)
        {
            FoodUpdate = true;
            orderCorrect = (bool) data;
        }
        orderCompleted = true;
    }
    private void OrderComplete () {
        bigThing.sprite = bigCheck;
        bigThing.enabled = true;
    }
    private void OrderFailed () {
        bigThing.sprite = bigX;
        bigThing.enabled = true;
    }





    public void CreepyTime() {
        creepyness = true;
        print(creepyness);
    }


}
