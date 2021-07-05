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

    public Gradient gradient;
    public Image fill;

    private void Awake()
    {
        bc = GetComponent<BattleController>();
    }

<<<<<<< HEAD
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

=======
>>>>>>> 83d721d788a266a54989f808b1e1898646290f3f
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
