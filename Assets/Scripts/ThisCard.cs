using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThisCard : MonoBehaviour
{
    //Script for Card to Call its Information
    public Card thisCard = new Card(); //possibly don't need this to be a list
    public int thisID;

    public int cardID;
    public string cardName;
    public string cardDescription;

    public Text textID;
    public Text textName;
    public Text textDescription;

    public Image cardSprite;
    public Image cardBG;

    void Start()
    {
        thisCard = CardDataBase.instance.CardList[thisID]; //if list, refer to thisCard[0]
    }

    void Update()
    {
        //On Update for the sake of Testing
            //Functional, it's just not too efficient
        CardInfo();
    }

    void CardInfo()
    {
        cardID = thisCard.cardID;
        cardName = thisCard.cardName;
        cardDescription = thisCard.cardDescription;
        cardSprite.sprite = thisCard.thisImage;
        cardBG = thisCard.thisBG;

        textID.text = cardID.ToString();
        textName.text = cardName;
        textDescription.text = cardDescription;
    }
}
