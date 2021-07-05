using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : UnitBase
{
    Animator anim;

    void Awake()
    {
        Initiate();
        anim = GetComponent<Animator>();
    }

    public void animasiBasicAttack(bool value)
    {
        
    }

    public IEnumerator EnemyBasicAttack()
    {
        yield return new WaitUntil(() => bc.battleState == "Idle");

        bc.battleState = "Enemy";

        anim.SetBool("isAttackEnemy1", true);

        yield return new WaitForSeconds(1.6f);

        bc.take_BasicAttackDamage_Player(baseDMG);
        bc.camShakeAnim.SetTrigger("shake");

        yield return new WaitForSeconds(1f);

        anim.SetBool("isAttackEnemy1", false);

        bc.battleState = "Idle";
        bc.cdBar.InitiateCooldownBar();
    }
}
