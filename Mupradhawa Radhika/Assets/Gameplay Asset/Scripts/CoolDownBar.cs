using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
    public Slider timerSlider;
    public float gameTime;

    private bool stopTimer;

    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    void Update()
    {
        float time = gameTime - Time.time;

        if(time <= 0)
        {
            stopTimer = true;
        }
        if(stopTimer == false)
        {
            timerSlider.value = time;
        }
        
    }
}
