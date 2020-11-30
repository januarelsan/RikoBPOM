using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgeManager : MonoBehaviour
{
    [SerializeField] private Transform[] badges;
    // Start is called before the first frame update
    void Start()
    {
        badges[0].GetChild(0).GetComponent<Image>().enabled = GameData.Instance.Badge0 == 0;
        badges[1].GetChild(0).GetComponent<Image>().enabled = GameData.Instance.Badge1 == 0;
        badges[2].GetChild(0).GetComponent<Image>().enabled = GameData.Instance.Badge2 == 0;
        badges[3].GetChild(0).GetComponent<Image>().enabled = GameData.Instance.Badge3 == 0;
        badges[4].GetChild(0).GetComponent<Image>().enabled = GameData.Instance.Badge4 == 0;

        if(GameData.Instance.Badge0 == 1)
            badges[0].GetComponent<Image>().color = Color.white;

        if(GameData.Instance.Badge1 == 1)
            badges[1].GetComponent<Image>().color = Color.white;

        if(GameData.Instance.Badge2 == 1)
            badges[2].GetComponent<Image>().color = Color.white;

        if(GameData.Instance.Badge3 == 1)
            badges[3].GetComponent<Image>().color = Color.white;

        if(GameData.Instance.Badge4 == 1)
            badges[4].GetComponent<Image>().color = Color.white;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
