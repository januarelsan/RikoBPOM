using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData> {

	[SerializeField]
	private bool resetData = new bool();

	// Use this for initialization
	void Start () {
		if(resetData)
			ResetData();
	}

	void ResetData(){
		if(resetData)
			PlayerPrefs.DeleteAll();
	}

	public int AudioOn
	{
		get { return PlayerPrefs.GetInt("AudioOn",1);}
		set { PlayerPrefs.SetInt("AudioOn",value);}
	}

	public int PlayerCoin
	{
		get { return PlayerPrefs.GetInt("PlayerCoin",1);}
		set { PlayerPrefs.SetInt("PlayerCoin",value);}
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

	

		
	
}
