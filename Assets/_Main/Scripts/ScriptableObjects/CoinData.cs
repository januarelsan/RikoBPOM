using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinData", menuName = "ScriptableObjects/Player Coin Data")]
public class CoinData : ScriptableObject
{
    public int value;

    public void AddCoin(int value){
        value += value;
    }
}
