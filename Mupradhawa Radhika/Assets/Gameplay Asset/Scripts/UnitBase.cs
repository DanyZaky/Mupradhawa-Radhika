using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    [SerializeField] protected BattleController bc;

    public string nameUnit;

    public float maxHP = 100;
    public float currentHP;

    public float maxSHD = 100;
    public float currentSHD;

    public float baseDMG = 20;
    public float minDMG;
    public float maxDMG;

    public void Initiate()
    {
        currentHP = maxHP;
        minDMG = (float)(0.5 * baseDMG);
        maxDMG = (float)(2 * baseDMG);
    }

    public void DealDamage(float amount)
    {
        if (currentSHD >= amount)
        {
            currentSHD -= amount;
        }
        else if (amount > currentSHD)
        {
            amount -= currentSHD;
            currentSHD = 0;
            currentHP -= amount;
        }
        else if (currentSHD < 1)
        {
            currentHP -= amount;
        }            
    }
}
