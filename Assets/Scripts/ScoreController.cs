using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//On box complete, call "BoxComplete()"
//On box failed, call "BoxFail()"



public class ScoreController : MonoBehaviour
{
    public TextMeshPro Text;
    [SerializeField] float Pay = 12.4f;
    [SerializeField] float maxPay = 15f;
    [SerializeField] float minPay = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        Text.text = Pay.ToString("F1");
        // StartCoroutine(Testing());
    }

    // Update is called once per frame

    public void BoxComplete() {
        //increase scrore, then re-display
        Pay += (( Pay + maxPay )/2 - Pay)/3;
        Text.text = Pay.ToString("F1");
    }

    public void BoxFail() {
        //decrease score, then re-display
        Pay = (Pay + minPay)/2;
        Text.text = Pay.ToString("F1");
    }

    // IEnumerator Testing() {
    //     while(true) {
    //         yield return new WaitForSeconds(2f);
    //         BoxFail();
    //     }
    // }
}
