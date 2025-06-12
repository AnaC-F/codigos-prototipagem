using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))] 
public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI _coinText;
    void Start()
    {
        _coinText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCoinText(PlayerInventory playerInventory)
    {
        _coinText.text = playerInventory.CoinScore.ToString();
    }
}
