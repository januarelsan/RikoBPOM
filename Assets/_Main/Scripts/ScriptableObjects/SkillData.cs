using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "ScriptableObjects/Player Skill Data")]
public class SkillData : ScriptableObject
{
    public int maskAmount;
    public int superHealingAmount;

    public void AddMask(){
        maskAmount++;
    }

    public void AddHealing(){
        superHealingAmount++;
    }
    
}