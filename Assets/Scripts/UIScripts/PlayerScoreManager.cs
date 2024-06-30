using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    [SerializeField]
    private List<PlayerInformation> _playerScore;


    public List<PlayerInformation> PlayerInfo
    {
        get { return _playerScore; }
        set { _playerScore = value; }
    }
}
