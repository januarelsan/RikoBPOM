using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItemPopup : MonoBehaviour
{

    public int order;
    void OnEnable(){
        for (int i = 0; i < 5; i++)
        {
            transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
        }
        StartCoroutine(PopUp(0.15f));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PopUp(float delay)
    {
        if(order > 0)
            yield return new WaitForSeconds(1);
        for (int i = 0; i < 5; i++)
        {
            transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(delay);
        }
    }
}
