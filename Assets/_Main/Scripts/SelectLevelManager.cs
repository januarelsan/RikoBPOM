using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next(){
        
        if(index < 2){
            index++;
            ChangeLevel();
        }

    }

    public void Prev(){
        
        if(index > 0){
            index--;
            ChangeLevel();
        }

    }

    private void ChangeLevel(){
        foreach (GameObject level in levels)
        {
            level.SetActive(false);
        }
        switch (index)
        {
            case 0:
                levels[0].SetActive(true);
                levels[1].SetActive(true);
                break;
            case 1:
                levels[2].SetActive(true);
                levels[3].SetActive(true);
                break;
            case 2:
                levels[4].SetActive(true);                
                break;
            default:
                levels[0].SetActive(true);
                levels[1].SetActive(true);
                break;
        }
    }
}
