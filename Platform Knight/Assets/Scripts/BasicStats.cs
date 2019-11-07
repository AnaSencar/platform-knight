using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStats : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxMana;
    [SerializeField] private int currentMana = 0;
    [SerializeField] private int totalCoins = 0;
    [SerializeField] private int manaToGiveAfterKilled = 0;
    [SerializeField] private int coinsToGiveAfterKilled = 0;

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }

    public int MaxMana
    {
        get
        {
            return maxMana;
        }
    }

    public int CurrentMana
    {
        get
        {
            return currentMana;
        }
        set
        {
            currentMana = value;
        }
    }

    public int TotalCoins
    {
        get
        {
            return totalCoins;
        }
    }

    public int ManaToGiveAfterKilled
    {
        get
        {
            return manaToGiveAfterKilled;
        }
    }

    public int CoinsToGiveAfterKilled
    {
        get
        {
            return coinsToGiveAfterKilled;
        }
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void RegainMana(int manaToGain)
    {
        currentMana = Mathf.Clamp(currentMana + manaToGain, 0, maxMana);
    }

    public void GetCoins(int coinsToGain)
    {
        totalCoins += coinsToGain;
    }

}
