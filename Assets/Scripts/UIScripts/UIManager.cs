using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //GameManager
    [SerializeField]
    GameManager manager;

    //Main UI Panels
    [SerializeField]
    RectTransform _playersPanel;
    [SerializeField]
    RectTransform _turnActionsPanel;
    public RectTransform TurnActionPanel { get { return _turnActionsPanel; } }
    [SerializeField]
    RectTransform _moveActionsPanel;
    public RectTransform MoveActionPanel { get { return _moveActionsPanel; } }
    [SerializeField]
    RectTransform _playerCardsPanel;
    public RectTransform PlayerCardsPanel { get { return _playerCardsPanel; } }
    [SerializeField]
    RectTransform _currentCardsPanel;
    public RectTransform CurrentCardsPanel { get { return _currentCardsPanel; } }
    [SerializeField]
    RectTransform _playerTurnPanel;
    public RectTransform PlayerTurnPanel { get { return _playerTurnPanel; } }

    //UI Fields
    [SerializeField]
    Text playerTurnPanelText;

    void Start()
    {
        manager.StartTurnEvent += ChangePlayerTurnText;
        ChangePlayerTurnText(); //Calling Text Here to Make Sure Text Changes
    }
    void ChangePlayerTurnText()
    {
        PlayerTurn turn = manager.CurrentTurn;
        string playerName = manager.ScoreManager.PlayerInfo[(int)turn].PlayerName;

        playerTurnPanelText.text = playerName + "'s Turn";
    }
    public void ReturnFromPlayerCards()
    {
        //Turn Card UI On and ActionPanel UI Off
        PanelAppear(PlayerCardsPanel, false);
        PanelAppear(TurnActionPanel, true);
    }
    public IEnumerator TimedPanelAppear(RectTransform panel, float amountOfTime, bool appear)
    {
        panel.gameObject.SetActive(appear);
        float timer = 0;
        while (timer < amountOfTime)
        {
            timer += Time.deltaTime;
            yield return 0;
        }
        panel.gameObject.SetActive(!appear);
    }
    
    public void PanelAppear(RectTransform panel, bool appear)
    {
        panel.gameObject.SetActive(appear);
    }
}
