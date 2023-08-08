using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv1Controller : MonoBehaviour
{
    public AudioController musicPlayer;
    public catMovement catBossWindow;
    public catMovement2 catBossHallway;


    public void CreepyTime()
    {
        musicPlayer.CreepyTime(1);
        catBossWindow.StopMovement();
        catBossHallway.D3();
    }
}
