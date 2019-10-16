using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    private BasicStats health;

    private void Awake()
    {
        healthBar = GetComponent<Image>();
        health = GetComponentInParent<BasicStats>();
        if (health == null)
        {
            health = FindObjectOfType<PlayerAttack>().GetComponent<BasicStats>();
        }
    }

    private void Update()
    {
        healthBar.fillAmount = (float)health.CurrentHealth / (float)health.MaxHealth;
    }

}
