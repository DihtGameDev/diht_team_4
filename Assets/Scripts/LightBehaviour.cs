using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    private int ticks = 0;
    private int prev_sec = 0;

    [SerializeField] public Light lt;
    
    // Start is called before the first frame update
    void Start () {
        Debug.Log("I am light and I am alive!");

    }

    // Update is called once per frame
    void Update()
    {
        ticks += 1;
        int sec = ticks / 200;
        if (sec < 10 && sec > prev_sec)
        {
            prev_sec = sec;
            if (sec % 2 == 0)
            {
                lt.color = Color.magenta;
            }
            else
            {
                lt.color = Color.green;
            }
            
        }
    }
}