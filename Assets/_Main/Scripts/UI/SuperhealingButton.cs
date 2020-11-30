using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperhealingButton : MonoBehaviour
{
    
    [SerializeField] private Image amountImage;
    [SerializeField] private Sprite[] amountSprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.Instance.SuperhealingAmount > 0){
            amountImage.transform.parent.GetComponent<Image>().enabled = true;
            amountImage.enabled = true;
            amountImage.sprite = amountSprites[GameData.Instance.SuperhealingAmount -1];
        } else
        {
            amountImage.transform.parent.GetComponent<Image>().enabled = false;
            amountImage.enabled = false;
        }
        
    }
}
