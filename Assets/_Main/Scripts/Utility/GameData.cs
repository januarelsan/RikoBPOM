using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData> {

	private bool resetData = false;

	// Use this for initialization
	void Start () {
		if(resetData)
			ResetData();
	}

	void ResetData(){
		if(resetData)
			PlayerPrefs.DeleteAll();
		Debug.Log("Reset GameData Prefs");
	}

	// public int LevelOpened
	// {
	// 	get { return PlayerPrefs.GetInt("LevelOpened",0);}
	// 	set { PlayerPrefs.SetInt("LevelOpened",value);}
	// }

	// public int LevelOpenedEnemy
	// {
	// 	get { return PlayerPrefs.GetInt("LevelOpenedEnemy",0);}
	// 	set { PlayerPrefs.SetInt("LevelOpenedEnemy",value);}
	// }

	// public int LevelOpenedFriend
	// {
	// 	get { return PlayerPrefs.GetInt("LevelOpenedFriend",0);}
	// 	set { PlayerPrefs.SetInt("LevelOpenedFriend",value);}
	// }

	// public int LevelOpenedCoin
	// {
	// 	get { return PlayerPrefs.GetInt("LevelOpenedCoin",0);}
	// 	set { PlayerPrefs.SetInt("LevelOpenedCoin",value);}
	// }

	public int ResultStoryType
	{
		get { return PlayerPrefs.GetInt("ResultStoryType",0);}
		set { PlayerPrefs.SetInt("ResultStoryType",value);}
	}

	public int ResultStoryIndex
	{
		get { return PlayerPrefs.GetInt("ResultStoryIndex",0);}
		set { PlayerPrefs.SetInt("ResultStoryIndex",value);}
	}

	public int StoryType
	{
		get { return PlayerPrefs.GetInt("StoryType",0);}
		set { PlayerPrefs.SetInt("StoryType",value);}
	}

	public int ShowTutorial
	{
		get { return PlayerPrefs.GetInt("ShowTutorial",0);}
		set { PlayerPrefs.SetInt("ShowTutorial",value);}
	}
	
	public int OnMask
	{
		get { return PlayerPrefs.GetInt("OnMask",0);}
		set { PlayerPrefs.SetInt("OnMask",value);}
	}

	public int MaskAmount
	{
		get { return PlayerPrefs.GetInt("MaskAmount",0);}
		set { PlayerPrefs.SetInt("MaskAmount",value);}
	}

	public int SuperhealingAmount
	{
		get { return PlayerPrefs.GetInt("SuperhealingAmount",0);}
		set { PlayerPrefs.SetInt("SuperhealingAmount",value);}
	}

	public int AudioOn
	{
		get { return PlayerPrefs.GetInt("AudioOn",1);}
		set { PlayerPrefs.SetInt("AudioOn",value);}
	}
	
	public int SelectedEpisode
	{
		get { return PlayerPrefs.GetInt("SelectedEpisode",1);}
		set { PlayerPrefs.SetInt("SelectedEpisode",value);}
	}

	public int SelectedLevel
	{
		get { return PlayerPrefs.GetInt("SelectedLevel",1);}
		set { PlayerPrefs.SetInt("SelectedLevel",value);}
	}

	public int Badge0
	{
		get { return PlayerPrefs.GetInt("Badge0",0);}
		set { PlayerPrefs.SetInt("Badge0",value);}
	}

	public int Badge1
	{
		get { return PlayerPrefs.GetInt("Badge1",0);}
		set { PlayerPrefs.SetInt("Badge1",value);}
	}
	public int Badge2
	{
		get { return PlayerPrefs.GetInt("Badge2",0);}
		set { PlayerPrefs.SetInt("Badge2",value);}
	}
	public int Badge3
	{
		get { return PlayerPrefs.GetInt("Badge3",0);}
		set { PlayerPrefs.SetInt("Badge3",value);}
	}

	public int Badge4
	{
		get { return PlayerPrefs.GetInt("Badge4",0);}
		set { PlayerPrefs.SetInt("Badge4",value);}
	}


	// public int LevelOpened_0
	// {
	// 	get { return PlayerPrefs.GetInt("LevelOpened_0",0);}
	// 	set { PlayerPrefs.SetInt("LevelOpened_0",value);}
	// }

	// public int LevelOpened_1
	// {
	// 	get { return PlayerPrefs.GetInt("LevelOpened_1",0);}
	// 	set { PlayerPrefs.SetInt("LevelOpened_1",value);}
	// }

	// public int LevelOpened_2
	// {
	// 	get { return PlayerPrefs.GetInt("LevelOpened_2",0);}
	// 	set { PlayerPrefs.SetInt("LevelOpened_2",value);}
	// }

	// public int LevelOpened_3
	// {
	// 	get { return PlayerPrefs.GetInt("LevelOpened_3",0);}
	// 	set { PlayerPrefs.SetInt("LevelOpened_3",value);}
	// }

	// public int LevelOpened_4
	// {
	// 	get { return PlayerPrefs.GetInt("LevelOpened_4",0);}
	// 	set { PlayerPrefs.SetInt("LevelOpened_0",value);}
	// }

	public int GetLevelOpened(int level)
	{
		return PlayerPrefs.GetInt("LevelOpened_" + level,0);
		
	}

	public void SetLevelOpened(int level, int value)
	{		
		PlayerPrefs.SetInt("LevelOpened_" + level, value);		
	}

	public int GetLevelOpenedEnemy(int level)
	{
		return PlayerPrefs.GetInt("LevelOpenedEnemy_" + level,0);		
	}

	public void SetLevelOpenedEnemy(int level, int value)
	{		
		PlayerPrefs.SetInt("LevelOpenedEnemy_" + level, value);		
	}

	public int GetLevelOpenedFriend(int level)
	{
		return PlayerPrefs.GetInt("LevelOpenedFriend_" + level,0);		
	}

	public void SetLevelOpenedFriend(int level, int value)
	{		
		PlayerPrefs.SetInt("LevelOpenedFriend_" + level, value);		
	}

	public int GetLevelOpenedCoin(int level)
	{
		return PlayerPrefs.GetInt("LevelOpenedCoin_" + level,0);		
	}

	public void SetLevelOpenedCoin(int level, int value)
	{		
		PlayerPrefs.SetInt("LevelOpenedCoin_" + level, value);		
	}

	

	// public int LevelOpenedEnemy
	// {
	// 	get { return PlayerPrefs.GetInt("LevelOpenedEnemy",0);}
	// 	set { PlayerPrefs.SetInt("LevelOpenedEnemy",value);}
	// }

	// public int LevelOpenedFriend
	// {
	// 	get { return PlayerPrefs.GetInt("LevelOpenedFriend",0);}
	// 	set { PlayerPrefs.SetInt("LevelOpenedFriend",value);}
	// }

	// public int LevelOpenedCoin
	// {
	// 	get { return PlayerPrefs.GetInt("LevelOpenedCoin",0);}
	// 	set { PlayerPrefs.SetInt("LevelOpenedCoin",value);}
	// }



	

		
	
}
