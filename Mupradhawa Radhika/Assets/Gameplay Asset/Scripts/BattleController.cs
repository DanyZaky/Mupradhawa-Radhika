using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public PuzzleController puzzleController;
    public Animator camShakeAnim;
    public PlayerHelathBar playerHealthBar;
    public EnemyHelathBar enemyHealthBar;
    public PlayerController player;
    public Enemy1Controller currentEnemy;
    public Enemy1Controller[] enemyList;

    [HideInInspector] public CoolDownBar cdBar;

    public bool isEnemyAttackPaused = false;
    public bool isBattleStart = false;
    public string battleState = "Idle";

    public void Awake()
    {
        cdBar = GetComponent<CoolDownBar>();
    }

    public void Start()
    {
        enemyHealthBar.setMaxHealth(currentEnemy.maxHP);
        playerHealthBar.setMaxHealth(player.maxHP);
    }

    private void Update()
    {
        
    }

    public void StartPlayerAttack()
    {
        if (cdBar.timerSlider.value >= cdBar.timerSlider.maxValue / 2)
        {
            StartCoroutine(player.PlayerSpecialAttack(player.maxDMG));
        }
        else
        {
            StartCoroutine(player.PlayerBasicAttack());
        }        
    }

    public void StartEnemyAttack()
    {
        StartCoroutine(currentEnemy.EnemyBasicAttack());
    }

    public void take_BasicAttackDamage_Enemy1(float damage)
    {
        currentEnemy.DealDamage(damage);

        updateHealthBar();
    }

    public void take_BasicAttackDamage_Player(float damage)
    {
        player.DealDamage(damage);

        updateHealthBar();
    }

    public void updateHealthBar()
    {
        enemyHealthBar.setHealth(currentEnemy.currentHP);
        playerHealthBar.setHealth(player.currentHP);
    }

    public void BattleStart()
    {
        isBattleStart = true;
        cdBar.InitiateCooldownBar();
    }
}
