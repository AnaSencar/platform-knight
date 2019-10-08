﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackType", menuName = "Make New Attack Type", order = 0)]
public class AttackTypes : ScriptableObject
{
    [SerializeField] private int attackDamage;
    [SerializeField] private int healAmount;
    [SerializeField] private int manaCostUsage;
    [SerializeField] private bool isAttackAvailable;
    [SerializeField] private string attackName;

    public int AttackDamage
    {
        get
        {
            return attackDamage;
        }
        set
        {
            attackDamage = value;
        }
    }

    public int ManaCostUsage
    {
        get
        {
            return manaCostUsage;
        }
    }

    public bool IsAttackAvailable
    {
        get
        {
            return isAttackAvailable;
        }
        set
        {
            isAttackAvailable = value;
        }
    }

    public string AttackName
    {
        get
        {
            return attackName;
        }
    }

    public int HealAmount
    {
        get
        {
            return healAmount;
        }
    }

}
