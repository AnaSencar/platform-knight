using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
    private Text coinsText;

    private void Awake()
    {
        coinsText = GetComponent<Text>();
    }

    private void Update()
    {
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        coinsText.text = FindObjectOfType<PlayerAttack>().GetComponent<BasicStats>().TotalCoins.ToString();
    }

}
