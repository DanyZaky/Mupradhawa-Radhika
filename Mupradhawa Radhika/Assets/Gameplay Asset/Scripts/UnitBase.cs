using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
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
        print("P" + currentHP);
        minDMG = baseDMG - (baseDMG * (1 / 5));
        maxDMG = baseDMG + (baseDMG * (1 / 5));
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
