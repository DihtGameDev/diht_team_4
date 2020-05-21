using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootClass : MonoBehaviour
{
    private int ticks = 0;
    private int prev_sec = 0;
    private int gold;
    void Start()
    {
        //gold = 0;
    }

    [SerializeField]
    private Settings rootSettings;

    void Update()
    {
        ticks += 1;
        int sec = ticks / 200;
        if (sec < 10 && sec > prev_sec)
        {
            gold += rootSettings.FarmsIncome[0];
            Debug.Log("I am root and for " + sec + " seconds i got " + gold + " food from farms of 1st level");
            prev_sec = sec;
        }
    }
}    
