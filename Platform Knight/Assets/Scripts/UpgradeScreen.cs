using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] private GameObject skillLevel;
    [SerializeField] private GameObject upgradeCost;
    [SerializeField] private AttackTypes attackType;

    void Update()
    {
        ShowInfo();
    }

    private void ShowInfo()
    {
        skillLevel.GetComponent<Text>().text = attackType.CurrentSkillLevel.ToString() + "/" + attackType.MaxSkillLevel.ToString();
        if (IsSkillMaxLevel())
        {
            skillLevel.GetComponent<Text>().text = "MAXED!";
        }
        upgradeCost.GetComponent<Text>().text = attackType.UpgradeCost.ToString();
    }

    private bool IsSkillMaxLevel()
    {
        return attackType.CurrentSkillLevel >= attackType.MaxSkillLevel;
    }

    public void BuySkillButtonPress()
    {
        if (IsSkillMaxLevel())
        {
            return;
        }
        attackType.CurrentSkillLevel += 1;
        attackType.IncreaseAttackDamage();
        attackType.IncreaseUpgradeCost();
    }

}
