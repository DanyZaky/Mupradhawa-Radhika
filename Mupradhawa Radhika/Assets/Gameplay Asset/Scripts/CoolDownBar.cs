using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
    public Slider timerSlider;
    public int IndexCdCurrentEnemy;
    public float[] CdEnemy;

    private BattleController bc;
    private bool stopTimer = true;
    private bool isEnemyAttack = false;

    private void Awake()
    {
        bc = GetComponent<BattleController>();
    }

    void Update()
    {
        if (stopTimer == false && bc.isEnemyAttackPaused == false)
        {
            timerSlider.value -= Time.deltaTime;
        }

        if (timerSlider.value <= 0)
        {
            stopTimer = true;

            if (!isEnemyAttack)
            {
                isEnemyAttack = true;
                bc.StartEnemyAttack();
            }
        }
    }

    public void InitiateCooldownBar()
    {
        stopTimer = false;
        isEnemyAttack = false;
        timerSlider.maxValue = CdEnemy[IndexCdCurrentEnemy];
        timerSlider.value = CdEnemy[IndexCdCurrentEnemy];
    }   
}
