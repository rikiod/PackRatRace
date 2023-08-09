using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightDialogue : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource ratDie;

    public AudioClip catMeow;
    public AudioClip catHiss;

    public TextMeshPro textRat;
    public TextMeshPro textCat;
    
    void Start()
    {
        GameObject CatBox = transform.Find("CatBox").gameObject;
        GameObject RatBox = transform.Find("RatBox").gameObject;
        CatBox.SetActive(false);       
        RatBox.SetActive(false);


        
    }

    public void CreepyTime() {
        StartCoroutine(Dialogue());

    }

    IEnumerator Dialogue() {
        GameObject CatBox = transform.Find("CatBox").gameObject;
        GameObject RatBox = transform.Find("RatBox").gameObject;

        yield return new WaitForSeconds(8);

        textCat.text = "A pet? You dare to call me a pet, you sniveling fool?";
        CatBox.SetActive(true);

        audioSource.clip = catMeow;
        audioSource.Play();

        yield return new WaitForSeconds(2);

        textRat.text = "The Manager P-Pat, sir- I said P-";
        RatBox.SetActive(true);

        yield return new WaitForSeconds(1);

        CatBox.SetActive(false);

        yield return new WaitForSeconds(1);

        RatBox.SetActive(false);

        audioSource.clip = catHiss;
        audioSource.Play();

        yield return new WaitForSeconds(1);

        ratDie.Play();

        yield return new WaitForSeconds(4);

        textCat.text = "I'll just say they were organizing a union.";
        CatBox.SetActive(true);

        audioSource.clip = catMeow;
        audioSource.Play();

        yield return new WaitForSeconds(4);

        CatBox.SetActive(false);
    }
}
