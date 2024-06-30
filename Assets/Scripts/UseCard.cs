using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCard : MonoBehaviour
{
    [SerializeField]
    Animator cardAnim;

    public delegate void Delete(int a, int b);
    public Delete thisCardWasDeleted;
    public int playerNum;
    public int cardNum;

    public void TriggerCard()
    {
        //Some Kind of Animation to Center Card on Center of Screen?

        //Trigger Card Animation
        cardAnim.SetTrigger("CardUsed");
        //Trigger Card Effect
        CardEffect();

        //Get Rid of Card from player's data and UI
        if(thisCardWasDeleted != null) thisCardWasDeleted.Invoke(playerNum, cardNum);
        Destroy(this.gameObject, cardAnim.GetCurrentAnimatorStateInfo(0).length);

    }
    void CardEffect() //probably needs some card info as params
    {
        //Effect should probably not take effect here as this script will break 
        Debug.Log("Card Effect!");
    }
}
