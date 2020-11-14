using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : Singleton<BackgroundManager>
{
    [SerializeField] private GameObject[] bgItems;


    // Start is called before the first frame update
    public void SetBackground()
    {
        
        for (int i = 0; i < bgItems.Length; i++)
        {
            
            bgItems[i].GetComponent<SpriteRenderer>().sprite = MissionManager.Instance.GetSelectedMission().backgrounds[i];
            bgItems[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = MissionManager.Instance.GetSelectedMission().walls[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
