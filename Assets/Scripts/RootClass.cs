using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RootClass : MonoBehaviour
{
    private int ticks = 0;
    private int prev_sec = 0;
    private int gold = 0;
	public int farmsCount = 1;
	public CanvasFields UIcanvas;
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
            gold += rootSettings.FarmsIncome[0] * farmsCount;
            Debug.Log("I am root and for " + sec + " seconds i got " + gold + " food from " + farmsCount + " farms of 1st level");
			UIcanvas.GoldText.text = ("current gold: " + gold);
			Debug.Log("current gold: " + gold);
            prev_sec = sec;
        }
    }
}    
