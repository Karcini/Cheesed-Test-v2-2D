using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Card
{
    //class of information denoting what a card is
    public int cardID;
    public string cardName;
    public string cardDescription;

    public Sprite thisImage;
    public Image thisBG;

    public Card() { } //Default Constructor;

    //Overloaded Constructor
    public Card(int id, string name, string description, Sprite image, Image bg)
    {
        cardID = id;
        cardName = name;
        cardDescription = description;
        thisImage = image;
        thisBG = bg;
    }
}
