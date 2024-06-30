using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDataBase : MonoSingleton<CardDataBase>
{
    //Card Database, should ONLY EVER GET this information
    List<Card> _cardList;
    public List<Card> CardList
    {
        get { return _cardList; }
    }

    public override void Init()
    {
        _cardList = new List<Card>();
        CardData();
    }
    void CardData()
    {
        CardList.Add(new Card(0, "Template", "Card Effect.", Resources.Load<Sprite>("Mouse"), Resources.Load<Image>("BGImage")));
        CardList.Add(new Card(1, "Fluke", fluke, Resources.Load <Sprite>("FlukeImage"), Resources.Load <Image>("BGImage")));
        CardList.Add(new Card(2, "Fake Door", fakeDoor, Resources.Load<Sprite>("StickyNoteImage"), Resources.Load<Image>("BGImage")));
        CardList.Add(new Card(3, "Toy Mouse", toyMouse, Resources.Load<Sprite>("ToyMouseImage"), Resources.Load<Image>("BGImage")));
    }

    //Effect Strings
    string fluke = "No Effect.";
    string fakeDoor = "Place a sticky note over a mouse hole to prevent any mice from using it.";
    string toyMouse = "Place a toy mouse in a room.  A cat encountering a room with a toy mouse will distract it from real mice.";
}
