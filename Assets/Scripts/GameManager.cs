using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player NameSpace
public enum PlayerTurn
{
    One,
    Two,
    Three,
    Four,
    Amount
}

public class GameManager : MonoBehaviour
{
    //Players
    PlayerScoreManager scoreManager; //Script within the same object
    [SerializeField]
    PlayerTurn currentTurn = PlayerTurn.One;
    public PlayerTurn CurrentTurn { get { return currentTurn; } }
    public PlayerScoreManager ScoreManager { get { return scoreManager; } }


    //ObjectSpawns
    [SerializeField]
    GameObject mouse;
    [SerializeField]
    GameObject baseCard;

    //Managers
    [SerializeField]
    UIManager ui;
    [SerializeField]
    ScoreUI updateScore;

    //Delegates
    public delegate void ManagerEvent();
    ManagerEvent _startOfTurn;
    public ManagerEvent StartTurnEvent{ get { return _startOfTurn; }  set { _startOfTurn = value; } }

    void Start()
    {
        //Initializers
        scoreManager = this.gameObject.GetComponent<PlayerScoreManager>();
        currentTurn = PlayerTurn.One;

        //Setup Start of Game Info For Players
        SetupPlayers();
        updateScore.SetPlayerUIinfo();

        //Begin Turn
        StartOfPlayerTurn();

        //Setup Phase Events
        StartOfGamePhase();


        GivePlayerCards(); //TEST METHOD, using this to test giving players cards
    }
    void GivePlayerCards() //Will Demo Players Drawing Cards
    {
        //Player given an ID, this is the ID of the card they would Draw
        int id = 0;
        //ADD Card to Player at Current Turn from the database at ID of Card They Drew
        Card card1 = CardDataBase.instance.CardList[id];
        Card card2 = CardDataBase.instance.CardList[1];
        Card card3 = CardDataBase.instance.CardList[2];
        Card card4 = CardDataBase.instance.CardList[3];
        //Player1 at start
        scoreManager.PlayerInfo[(int)currentTurn].PlayerCards.Add(card1);
        scoreManager.PlayerInfo[(int)currentTurn].PlayerCards.Add(card2);
        scoreManager.PlayerInfo[(int)currentTurn].PlayerCards.Add(card3);
        scoreManager.PlayerInfo[(int)currentTurn].PlayerCards.Add(card4);
        //Player2
        scoreManager.PlayerInfo[(int)PlayerTurn.Two].PlayerCards.Add(card2);
        scoreManager.PlayerInfo[(int)PlayerTurn.Two].PlayerCards.Add(card2);
        //Player3
        //Player4
        scoreManager.PlayerInfo[(int)PlayerTurn.Four].PlayerCards.Add(card2);
        scoreManager.PlayerInfo[(int)PlayerTurn.Four].PlayerCards.Add(card4);
        scoreManager.PlayerInfo[(int)PlayerTurn.Four].PlayerCards.Add(card4);
    }

    public void NextTurn() //this method iterates through the players in PlayerTurn.Amount
    {
        currentTurn++;
        PlayerTurn current = (PlayerTurn)currentTurn;
        if ((PlayerTurn)currentTurn == PlayerTurn.Amount)
            currentTurn = 0;

        //Initiate Start of Player Turn Things
        StartOfPlayerTurn();
    }
    public void GetPlayerCards() //this method gets the curren't players turn's Cards
    {
        //Turn Card UI On and ActionPanel UI Off
        ui.PanelAppear(ui.PlayerCardsPanel, true);
        ui.PanelAppear(ui.TurnActionPanel, false);

        //Should Empty Cards List on Scene
        foreach (RectTransform card in ui.CurrentCardsPanel)
            Destroy(card.gameObject);

        //////Populate Cards with this Players Turn's Cards
        //How many cards does current player have
        int cardCount = scoreManager.PlayerInfo[(int)currentTurn].PlayerCards.Count;

        for (int x=0; x<cardCount; x++)
        {
            //Instantiate a base card and assign parent
            GameObject cardObj = Instantiate(baseCard);
            cardObj.transform.SetParent(ui.CurrentCardsPanel);
            //Get card index of current player's card, on this slot
            int cardIndex = scoreManager.PlayerInfo[(int)currentTurn].PlayerCards[x].cardID;
            //set instantiated card's index to the index of player's current card from database
            cardObj.GetComponent<ThisCard>().thisID = cardIndex;

            //Add this card's destroy method onto the objects event script
            UseCard usage = cardObj.GetComponent<UseCard>();
            usage.thisCardWasDeleted += RemoveThisCard;
            usage.playerNum = (int)currentTurn;
            usage.cardNum = x;
        }
    }
    void RemoveThisCard(int thisPlayer, int cardAtThisSlot)
    {
        scoreManager.PlayerInfo[thisPlayer].PlayerCards.RemoveAt(cardAtThisSlot);
    }
    public void Move()
    {
        //Turn ActionPanel UI Off
        ui.PanelAppear(ui.TurnActionPanel, false);
        ui.PanelAppear(ui.MoveActionPanel, true);
        //Perhaps include UI to direct player on what they do

        //Allow Player to click on Mouse and Space

    }
    public void EndMove()
    {
        //Will Probably be made private and not called through a Button
        //Is called through a button for now
        ui.PanelAppear(ui.TurnActionPanel, true);
        ui.PanelAppear(ui.MoveActionPanel, false);
    }
    void StartOfPlayerTurn()
    {
        //Invoke Start of Turn Event
        if (_startOfTurn != null)
            _startOfTurn.Invoke();

        //Make start of player turn UI visible for 1 second
        float delay = 1f;
        StartCoroutine(ui.TimedPanelAppear(ui.PlayerTurnPanel, delay, true));
        StartCoroutine(ui.TimedPanelAppear(ui.TurnActionPanel, delay, false));
    }
    //-----------Setup Methods
    void SetupPlayers()
    {
        //Iterate through players
        for (int x = 0; x < (int)PlayerTurn.Amount; x++)
        {
            InitializePlayerScore(x);
            AddMouseToPlayer(x);
        }
    }
    void AddMouseToPlayer(int PlayerNum)
    {
        //Assign a new mouse prefab
        GameObject newMouse = mouse;
        //Assign mouse to PlayerNumber
        newMouse.GetComponent<Cat>().PlayerNumber = (PlayerTurn)PlayerNum;

        //Adds 1 mouse token onto this players mouse list
        scoreManager.PlayerInfo[PlayerNum].PlayerMice.Add(newMouse);
    }
    void InitializePlayerScore(int PlayerNum)
    {
        scoreManager.PlayerInfo[PlayerNum].ResetScore();
    }

    //-----------Setup Phase
    void StartOfGamePhase()
    {
        //Players should take turns placing their mice on the board
            //We need grid
        //Then Cat should be placed on the Board
    }
}
