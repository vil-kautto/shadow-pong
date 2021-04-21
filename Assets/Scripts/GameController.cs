using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI opponentScoreText;

    public void StartRound()
    {
        Debug.Log("Round Start");
    }

    public void EndRound(string winner, int winnerScore)
    {
        Debug.Log("Round End, winner: " + winner);
        if(winner == "player")
        {
            playerScoreText.text = winnerScore.ToString();
        }
        else if (winner == "opponent")
        {
            opponentScoreText.text = winnerScore.ToString();
        }
        StartRound();
    }
}
