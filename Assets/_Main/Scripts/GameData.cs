using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData> {

	[SerializeField]
	private bool resetData;

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

	

		
	
}
