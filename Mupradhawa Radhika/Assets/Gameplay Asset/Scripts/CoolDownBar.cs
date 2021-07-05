using System.Collections;
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

    public Gradient gradient;
    public Image fill;

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

        fill.color = gradient.Evaluate(1f);
    }

    public void StartEnemyAttack()
    {
        StartCoroutine(bc.EnemyAttack());
        fill.color = gradient.Evaluate(timerSlider.normalizedValue);
    }

    void Update()
    {
        if (stopTimer == false && bc.isEnemyAttackPaused == false)
        {
            timerSlider.value -= Time.deltaTime;
        }
        else
        {
            print(stopTimer);
            print(bc.isEnemyAttackPaused);
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
