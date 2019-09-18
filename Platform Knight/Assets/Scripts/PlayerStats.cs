using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int attackDamange = 10;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxMana = 20;
    [SerializeField] private int currentMana;

    public int CurrentMana
    {
        get
        {
            return currentMana;
        }
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
