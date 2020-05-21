using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int ticks = 0;
    private int prev_sec = 0;
    // Start is called before the first frame update
    void Start () {
        Debug.Log("I am sphere and I am alive!");
    }

    // Update is called once per frame
    void Update()
    {
        ticks += 1;
        int sec = ticks / 200;
        if (sec < 10 && sec > prev_sec)
        {
            //Debug.Log("I am alive for " + sec + " seconds");
            prev_sec = sec;
        }
    }
}
