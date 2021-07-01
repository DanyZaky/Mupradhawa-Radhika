﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
    public Slider timerSlider;
    public float gameTime;

    private BattleController bc;
    private bool stopTimer = true;
    private bool isEnemyAttack = false;

    private void Awake()
    {
        bc = GetComponent<BattleController>();
    }

    public void InitiateCooldownBar()
    {
        stopTimer = false;
        isEnemyAttack = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    public void StartEnemyAttack()
    {
        StartCoroutine(bc.EnemyAttack());
    }

    void Update()
    {
        if (stopTimer == false)
        {
            timerSlider.value -= Time.deltaTime;
        }

        if (timerSlider.value <= 0)
        {
            stopTimer = true;

            if (!isEnemyAttack)
            {
                isEnemyAttack = true;
                StartEnemyAttack();
            }
        }        
    }
}
