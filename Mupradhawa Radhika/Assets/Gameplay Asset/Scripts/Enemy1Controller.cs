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
        anim.SetBool("isAttackEnemy1", value);
    }
}
