using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv2Controller : MonoBehaviour
{
    public AudioController musicPlayer;
    //public TVController tV;
    //public ItemSpawner spawner;
    //public Conveyor conveyor;
    public CatMovementLevelTwo catBoss;

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(Testingg());
    }

    public void CreepyTime() {

        musicPlayer.CreepyTime(2);
        //tV.CreepyTime();
        catBoss.CreepyTime();
        
        // grinder already has it by default; whenever rat head, spits out blue can
        //spawner.CreepyTime();
        //conveyor.CreepyTime();

    }

    // IEnumerator Testingg() {
    //     yield return new WaitForSeconds(5);
    //     CreepyTime();
    // }
}
