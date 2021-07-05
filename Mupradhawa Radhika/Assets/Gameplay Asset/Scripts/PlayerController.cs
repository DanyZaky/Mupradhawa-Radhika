using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitBase
{
    Animator anim;

    void Awake()
    {
        Initiate();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void animasiJalan()
    {
        anim.SetBool("isWalkingPlayer", true);
    }

    public void animasiIdle()
    {
        anim.SetBool("isWalkingPlayer", false);
        anim.SetBool("isAttackPlayer", false);
    }

    public IEnumerator PlayerBasicAttack()
    {
        yield return new WaitUntil(() => bc.battleState == "Idle");

        bc.isEnemyAttackPaused = true;

        bc.battleState = "Player";

        anim.SetBool("isAttackPlayer", true);

        yield return new WaitForSeconds(1.6f);

        bc.take_BasicAttackDamage_Enemy1(baseDMG);
        bc.camShakeAnim.SetTrigger("shake");

        yield return new WaitForSeconds(1f);

        anim.SetBool("isAttackPlayer", false);

        bc.isEnemyAttackPaused = false;
        bc.battleState = "Idle";
        StartCoroutine(bc.puzzleController.RespawnKartu());
    }

    public IEnumerator PlayerSpecialAttack(float dmg)
    {
        yield return new WaitUntil(() => bc.battleState == "Idle");

        bc.isEnemyAttackPaused = true;

        bc.battleState = "Player";

        anim.SetBool("isAttackPlayer", true);

        yield return new WaitForSeconds(1.6f);

        bc.take_BasicAttackDamage_Enemy1(dmg);
        bc.camShakeAnim.SetTrigger("shake");

        yield return new WaitForSeconds(1f);

        anim.SetBool("isAttackPlayer", false);

        bc.isEnemyAttackPaused = false;
        bc.battleState = "Idle";
        StartCoroutine(bc.puzzleController.RespawnKartu());
    }
}
