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

    private CoolDownBar cdBar;

    public bool isBattleStart = false;

    public void Awake()
    {
        cdBar = GetComponent<CoolDownBar>();
    }

    public void Start()
    {
        enemyHealthBar.setMaxHealth(currentEnemy.maxHP);
        playerHealthBar.setMaxHealth(player.maxHP);
    }

    public IEnumerator PlayerAttack()
    {
        player.animasiBasicAttack(true);

        yield return new WaitForSeconds(1.6f);

        take_BasicAttackDamage_Enemy1(player.baseDMG);
        camShakeAnim.SetTrigger("shake");

        yield return new WaitForSeconds(1f);

        player.animasiBasicAttack(false);
        
        StartCoroutine(puzzleController.RespawnKartu());
    }

    public IEnumerator EnemyAttack()
    {
        currentEnemy.animasiBasicAttack(true);

        yield return new WaitForSeconds(1.6f);

        take_BasicAttackDamage_Player(currentEnemy.baseDMG);
        camShakeAnim.SetTrigger("shake");

        yield return new WaitForSeconds(1f);

        currentEnemy.animasiBasicAttack(false);
        cdBar.InitiateCooldownBar();
    }

    void take_BasicAttackDamage_Enemy1(float damage)
    {
        currentEnemy.DealDamage(damage);

        updateHealthBar();
    }

    void take_BasicAttackDamage_Player(float damage)
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
