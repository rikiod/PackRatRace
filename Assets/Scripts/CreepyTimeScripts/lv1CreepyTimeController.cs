using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv1Controller : MonoBehaviour
{
    public AudioController musicPlayer;
    public catMovement catBossWindow;
    public catMovement2 catBossHallway;
    public ratMovement ratMovement;
    public ScoreController scoreController;
    public ScreenController screenController;
    public FightDialogue fightDialogue;
    int completedBoxes = 0;

    public void BoxNumberListener(Component sender, object data) { //called by both listeners, they're sending different data types
        
        if (data is bool) {
            BoxUpdate((bool)data);
            //print(data);
        }
        else if (data is int) {
            completedBoxes = (int)data;
            //print(data);
        }
    }

    void BoxUpdate(bool completed) {
        if (completed) {
            scoreController.BoxComplete();
            //increase conveyor speed
        }
        else {
            scoreController.BoxFail();
            // redo the same box
        }

        if (completedBoxes == 1) {
                ratMovement.D1();
            }
            if (completedBoxes == 2) {
                catBossHallway.D2();
            }
            if (completedBoxes == 3) {
                ratMovement.D2();
            }
            if (completedBoxes == 4) {
                CreepyTime();
            }
    }
    
    public void CreepyTime()
    {
        musicPlayer.CreepyTime(1);
        catBossWindow.StopMovement();
        catBossHallway.D3();
        screenController.CreepyTime();
        fightDialogue.CreepyTime();
    }



    // void Start()
    // {
    //     StartCoroutine(Testingg());
    // }

    IEnumerator Testingg() {
        yield return new WaitForSeconds(5);
        CreepyTime();
        print("activating Creepy Time");
    }
}
