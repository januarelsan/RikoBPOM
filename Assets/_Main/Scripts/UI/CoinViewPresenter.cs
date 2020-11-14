using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinViewPresenter : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private MissionData currentData;
    [SerializeField] private CoinData coinData;

    // Update is called once per frame
    void Update()
    {
        if(!coinData)
            coinText.text = currentData.coinM.ToString();
        else
        {
            coinText.text = coinData.value.ToString();
        }
    }
}
