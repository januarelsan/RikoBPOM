using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoryData", menuName = "Story Data")]
public class StoryData : ScriptableObject
{
    public int level;
    public Sprite[] sprites;
    public string[] captions = new string[]{"Lorem Ipsum Dolor Sit Amet"};
    public enum StoryType
    {
        intro,
        sadEnding,  
        happyEnding           
    }
    public StoryType storyType;
}
