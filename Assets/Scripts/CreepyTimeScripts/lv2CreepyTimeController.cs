using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv2CreepyTimeController : MonoBehaviour
{
    public AudioController musicPlayer;
    public ScoreController scoreController;
    //public TVController tV;
    //public ItemSpawner spawner;
    //public Conveyor conveyor;
    public CatMovementLevelTwo catBoss;
    [SerializeField] int boxesUntilCreepyTime = 4;
    public ScreenController screenController;
    int completedBoxes = 0;

    // Start is called before the first frame update
    // void Start()
    // {
    //     StartCoroutine(Testingg());
    // }

    // IEnumerator Testingg() {
    //     yield return new WaitForSeconds(5);
    //     CreepyTime();
    // }

    public void BoxUpdate(bool completed) {
        if (completed) {
            scoreController.BoxComplete();
            //increase conveyor speed

            completedBoxes += 1;
            if (completedBoxes == boxesUntilCreepyTime) {
                CreepyTime();
            }
        }
        else {
            scoreController.BoxFail();
            // redo the same box
        }
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
