using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;

    float ms;

    void Start()
    {
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

    public void animasiBasicAttack()
    {
        anim.SetBool("isAttackPlayer", true);
    }
}
