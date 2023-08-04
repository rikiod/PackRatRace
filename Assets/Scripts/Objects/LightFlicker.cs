using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lamp;
    [SerializeField] float minFlickerTime;
    [SerializeField] float maxFlickerTime;
    [SerializeField] float minDimDuration;
    [SerializeField] float maxDimDuration;
    [SerializeField] float minOffDuration;
    [SerializeField] float maxOffDuration;
    [SerializeField] float onLevel;
    [SerializeField] float dimLevel;
    [SerializeField] float offLevel;


    // Start is called before the first frame update
    void Start()
    {
        lamp.intensity = onLevel;
        StartCoroutine(FlickerStart());
    }

    IEnumerator FlickerStart() {
        while (true) {
            
            float waitTime = Random.Range(minFlickerTime, maxFlickerTime);
            yield return new WaitForSeconds(waitTime);

            bool randomBool = Random.value > 0.5f;
            if (randomBool) {
                StartCoroutine(Dim());
            }
            else {
                StartCoroutine(Off());
            }

        }
    }
    IEnumerator Dim() {
        lamp.intensity = dimLevel;
        float waitTime = Random.Range(minDimDuration, maxDimDuration);
        yield return new WaitForSeconds(waitTime);
        lamp.intensity = onLevel;
    }
    IEnumerator Off() {
        lamp.intensity = offLevel;
        float waitTime = Random.Range(minOffDuration, maxOffDuration);
        yield return new WaitForSeconds(waitTime);
        lamp.intensity = onLevel;
    }
}
