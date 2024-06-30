using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlayerUI : MonoBehaviour
{
    private PlayerScoreManager scoreManager;

    [SerializeField]
    private RectTransform mouseUIHorizGroup;
    [SerializeField]
    private RectTransform mouseUIPrefab;
    [SerializeField]
    private RectTransform cheeseCount;
    [SerializeField]
    private RectTransform playerName;

    public void UpdateMice(int newMiceAmount)
    {
        int amount = mouseUIHorizGroup.transform.childCount;
        if (amount < newMiceAmount)
            AddMice(newMiceAmount - amount);
        else if (amount > newMiceAmount)
            RemoveMice(amount - newMiceAmount);
    }
    public void UpdateName(string newName)
    {
        playerName.GetComponent<UnityEngine.UI.Text>().text = newName;
    }
    public void UpdateCheese(int newCheeseAmount)
    {
        string newCheese = newCheeseAmount.ToString();
        cheeseCount.GetComponent<UnityEngine.UI.Text>().text = "# " + newCheese;
    }
    void AddMice(int amount)
    {
        for (int x=0; x<amount; x++)
        {
            RectTransform tempMouse = Instantiate(mouseUIPrefab);
            tempMouse.transform.SetParent(mouseUIHorizGroup, false);
        }
    }
    void RemoveMice(int amount)
    {
        for (int x=0; x<amount; x++)
        {
            Destroy(mouseUIHorizGroup.GetChild(x).gameObject);
        }
    }
}
