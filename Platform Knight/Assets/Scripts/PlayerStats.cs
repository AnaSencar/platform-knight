using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
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
        currentMana = 0;
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
