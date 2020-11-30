using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private PauseController pauseController;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    private bool isPlaying = true;


    

    // Start is called before the first frame update
    void Start()
    {
        
        // WinGame();   
        // GameData.Instance.SetLevelOpenedEnemy(GameData.Instance.SelectedLevel,1);
        // GameData.Instance.SetLevelOpenedFriend(GameData.Instance.SelectedLevel,1);
        // GameData.Instance.SetLevelOpenedCoin(GameData.Instance.SelectedLevel,1);

        //reset on mask every level
        GameData.Instance.OnMask = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(!isPlaying && player.GetComponent<PlayerState>().GetState().ToString() != "Idle"){
        //     player.GetComponent<PlayerState>().SwitchState("Idle"); 
        //     player.GetComponent<BoxCollider2D>().enabled = false;
        // }

    }

    public void WinGame(){
        // Debug.Log("Win Game GameManager");
        winPanel.SetActive(true);
        player.GetComponent<PlayerState>().SwitchState("Idle"); 
        player.GetComponent<BoxCollider2D>().isTrigger = false;

        if(isPlaying){
            GameData.Instance.SetLevelOpened(GameData.Instance.SelectedLevel + 1, 1);               
            isPlaying = false;
        }
        
        
        //set badge
        if(IsDivisible(MissionManager.Instance.GetSelectedMission().level + 1, 5)){

            int episode = MissionManager.Instance.GetSelectedMission().episode;
            switch (episode)
            {
                case 0:
                    GameData.Instance.Badge0 = 1;
                    break;
                case 1:
                    GameData.Instance.Badge1 = 1;
                    break;
                case 2:
                    GameData.Instance.Badge2 = 1;
                    break;
                case 3:
                    GameData.Instance.Badge3 = 1;
                    break;
                case 4:
                    GameData.Instance.Badge4 = 1;
                    break;
                default:
                    GameData.Instance.Badge0 = 1;
                    break;
            }

        }

        

        // GameData.Instance.LevelOpenedEnemy = 0;
        // GameData.Instance.LevelOpenedFriend = 0;
        // GameData.Instance.LevelOpenedCoin = 0;
        
        ShowResultStory(1);

        StartCoroutine(PauseGame());
        
        
    }

    public void GameOver(){
        isPlaying = false;
        gameOverPanel.SetActive(true);
        SpawnerManager.Instance.StopSpawn();
        player.GetComponent<PlayerState>().SwitchState("Die"); 
        player.GetComponent<BoxCollider2D>().isTrigger = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        ShowResultStory(0);

        StartCoroutine(PauseGame());
                        
    }

    IEnumerator PauseGame(){
        yield return new WaitForSeconds(2);
        pauseController.SetPauseGame(true);
    }




    void ShowResultStory(int result){
        StartCoroutine(_ShowResultStory(result));
    }

    IEnumerator _ShowResultStory(int result){
        yield return new WaitForSeconds(1.5f);
        if(IsDivisible(MissionManager.Instance.GetSelectedMission().level + 1, 5)){
            GameData.Instance.ResultStoryType = result;
            GameData.Instance.ResultStoryIndex = MissionManager.Instance.GetSelectedMission().level + 1;
            SceneController.Instance.GoToScene("ResultStory");
        }
    }



    public bool IsDivisible(int x, int n)
    {
        return (x % n) == 0;
    }

    public bool GetIsPlaying(){
        return isPlaying;
    }

    public void SetIsPlaying(bool value){
        isPlaying = value;
    }

}
