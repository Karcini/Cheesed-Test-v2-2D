using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInformation
{
    //Namespace in GameManager
    [SerializeField]
    private PlayerTurn _playerNumber;

    //PlayerScore
    [SerializeField]
    private string _playerName;
    [SerializeField]
    private int _miceAmount;
    [SerializeField]
    private int _cheeseAmount;

    //PlayerAssets
    //[SerializeField]
    //private List<int> _playerCardIDs = new List<int>();
    [SerializeField]
    private List<Card> _playerCards = new List<Card>();
    [SerializeField]
    private List<GameObject> _playerMice = new List<GameObject>();

    public PlayerTurn Player
    {
        get { return _playerNumber;}
    }

    public string PlayerName
    {
        get { return _playerName; }
        set { _playerName = value; }
    }

    public int MiceAmount
    {
        get { return _miceAmount; }
        set { _miceAmount = value; }
    }
    public List<GameObject> PlayerMice
    {
        get { return _playerMice; }
        set { _playerMice = value; }
    }

    public int CheeseAmount
    {
        get { return _cheeseAmount; }
        set { _cheeseAmount = value; }
    }

    public List<Card> PlayerCards
    {
        get { return _playerCards; }
        set { _playerCards = value; }
    }
    public void ResetScore()
    {
        _cheeseAmount = 0;
        _miceAmount = 5;
    }
}
