using UnityEngine;
using UnityEngine.UI;

public class PlayerMask : Singleton<PlayerMask> {
    
    [SerializeField] private Image maskerOnHealthImage;
    
    private int maskAmount;
    

    void Update() {
        maskerOnHealthImage.enabled = GameData.Instance.OnMask == 1;        
    }

    public void UseMask(){
        if(GetMaskAmount() > 0 && GameData.Instance.OnMask == 0){
            GameData.Instance.OnMask = 1;
            GameData.Instance.MaskAmount--;
            
        }
    }

    public void RemoveMask(){
        GameData.Instance.OnMask = 0;
    }
        
    

    public int GetMaskAmount(){
        return GameData.Instance.MaskAmount;
    }

    public bool GetOnMask(){
        return GameData.Instance.OnMask == 1;
    }
}