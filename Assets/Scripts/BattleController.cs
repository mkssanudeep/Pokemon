using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public int roundTime = 99;
    private float lastTimeUpdate = 0;

    private bool battleStarted= false; 
    public BannerController banner;

    public Fighter player1;
    public Fighter player2; 


    void Start()
    {
        banner.showFight();
    }

    void Update()
    {
        if(!battleStarted && !banner.animating)
        {
            battleStarted = true;

            player1.enable = true;
            player2.enable = true;
        }
        if(roundTime > 0 && Time.time - lastTimeUpdate > 1)
        {
            roundTime--;
            lastTimeUpdate = Time.time;
        }
    }
}
