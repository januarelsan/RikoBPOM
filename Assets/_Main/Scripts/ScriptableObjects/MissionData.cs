using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionData", menuName = "ScriptableObjects/Mission Data")]
public class MissionData : ScriptableObject
{
    public StoryData happyStoryData;
    public StoryData sadStoryData;
    public int episode;
    public int level;
    public string description = "Jaga ibu agar terhindar dari rokok & lancar dalam persalinan bayinya.";
    public int enemyM;
    public int friendM;
    public int coinM;

    public Sprite[] backgrounds;
    public Sprite[] walls;

    public int smokers;
    public int mafia;
    public int spg;
    public int obstacles;
    public int dashItems;
    public int buildings;
    public int items;
    public int professors;
    
}
