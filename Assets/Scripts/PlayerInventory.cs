using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerInventory : MonoBehaviour
{
    public int CoinScore { get; private set;}
    [SerializeField] private UnityEvent<PlayerInventory> onCollectedCoin;
    public void CollectCoin()
    {
        CoinScore++;
        onCollectedCoin.Invoke(this);
    }
}
