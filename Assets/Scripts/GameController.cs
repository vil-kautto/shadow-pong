using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * Gamecontroller controls the general flow of the game
 */
public class GameController : MonoBehaviour
{
    // GUI elements for score tallying
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI opponentScoreText;

    /**
     * StartRound prepares and starts the game
     */
    private void StartRound()
    {
        Debug.Log("Starting the next round");
        FindObjectOfType<BallMovement>().BallReset();
    }

    /**
     * EndRound updates the scores and calls StartRound -method
     */
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
