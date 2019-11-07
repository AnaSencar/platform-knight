using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackType", menuName = "Make New Attack Type", order = 0)]
public class AttackTypes : ScriptableObject
{
    [SerializeField] private int attackDamage;
    [SerializeField] private int healAmount;
    [SerializeField] private int manaCostUsage;
    [SerializeField] private bool isAttackAvailable;
    [SerializeField] private int currentSkillLevel = 1;
    [SerializeField] private int maxSkillLevel = 20;
    [SerializeField] private int upgradeCost;
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

    public int CurrentSkillLevel
    {
        get
        {
            return currentSkillLevel;
        }
        set
        {
            currentSkillLevel = value;
        }
    }

    public int MaxSkillLevel
    {
        get
        {
            return maxSkillLevel;
        }
    }

    public int UpgradeCost
    {
        get
        {
            return upgradeCost;
        }
    }

    public void IncreaseUpgradeCost()
    {
        upgradeCost *= 2;
    }

    public void IncreaseAttackDamage()
    {
        attackDamage += 2;
    }

}
