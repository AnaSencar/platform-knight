using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    private Image manaBar;

    private void Awake()
    {
        manaBar = GetComponent<Image>();
    }

    void Update()
    {
        BasicStats mana = FindObjectOfType<PlayerAttack>().GetComponent<BasicStats>();
        manaBar.fillAmount = mana.CurrentMana / mana.MaxMana;
    }
}
