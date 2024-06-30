using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePosition : MonoBehaviour
{
    Animator animator;
    public enum HourPositions
    {
        Twelve_Oclock   ,
        One_Oclock      ,
        Two_Oclock      ,
        Three_Oclock    ,
        Four_Oclock     ,
        Five_Oclock     ,
        Six_Oclock      ,
        Seven_Oclock    ,
        Eight_Oclock    ,
        Nine_Oclock     ,
        Ten_Oclock      ,
        Eleven_Oclock   
    }
    public int[] HourValues = { 90, 60, 30, 0, -30, -60, -90, -120, -150, -180, -210, -240 };
    public int timePos = 0;
    public RectTransform hourHand;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ChangeSpecificTime(RectTransform timeHand, HourPositions time)
    {
        timePos = HourValues[(int)time];

        timeHand.rotation = Quaternion.Euler(timeHand.rotation.x, timeHand.rotation.y, timePos);
    }
    public void ChangeRandomTime(RectTransform timeHand)
    {
        int randomIndex = (int)Random.Range(0, 12);
        timePos = HourValues[randomIndex];
        Debug.Log("index is "+randomIndex+"  time is "+ timePos);

        animator.SetInteger("TimePos", randomIndex);

        //Removing this method and changing animation instead
        //timeHand.rotation = Quaternion.Euler(timeHand.rotation.x, timeHand.rotation.y, timePos);
    }

    public void SpinToggle()
    {
        if (animator.GetBool("ClockSpinning"))
        {
            animator.SetBool("ClockSpinning", false);
        }
        else
        {
            animator.SetBool("ClockSpinning", true);
            ChangeRandomTime(hourHand);
        }
    }
}
