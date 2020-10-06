using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinViewPresenter : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private CoinData coinData;

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinData.value.ToString();
    }
}
