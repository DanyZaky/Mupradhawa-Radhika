﻿using System.Collections;
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

    public void animasiBasicAttack(bool value)
    {
        anim.SetBool("isAttackPlayer", value);
    }
}
