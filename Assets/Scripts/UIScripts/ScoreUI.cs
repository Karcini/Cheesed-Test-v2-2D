using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private PlayerScoreManager scoreManager;
    private ScorePlayerUI scorePUI;

    [SerializeField]
    private GameObject[] players;

    private List<GameObject> mice; 
    void Start()
    {
        mice = new List<GameObject>();
    }

    //Call this method to update only score info of players
    public void UpdateScores()
    {
        scoreManager = FindObjectOfType<PlayerScoreManager>();
        GetScoreData();
    }
    //Call this method to update all player info of players
    public void SetPlayerUIinfo()
    {
        scoreManager = FindObjectOfType<PlayerScoreManager>();

        for (int x = 0; x < scoreManager.PlayerInfo.Count; x++)
        {
            string name = scoreManager.PlayerInfo[x].PlayerName;
            scorePUI = players[x].GetComponent<ScorePlayerUI>();

            scorePUI.UpdateName(name);
        }
        UpdateScores();
    }
    void GetScoreData()
    {
        //Iterate through every players PlayerScore
        for (int x = 0; x < scoreManager.PlayerInfo.Count; x++)
        {
            int mouse = scoreManager.PlayerInfo[x].MiceAmount;
            int cheese = scoreManager.PlayerInfo[x].CheeseAmount;
            scorePUI = players[x].GetComponent<ScorePlayerUI>();

            scorePUI.UpdateMice(mouse);
            scorePUI.UpdateCheese(cheese);
        }
    }
}
