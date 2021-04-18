using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI opponentScoreText;
    public int playerScore = 0;
    public int opponentScore = 0;

    void Update()
    {
        playerScoreText.text = $"Player's Score {playerScore}";
        opponentScoreText.text = $"Player's Score {opponentScore}";
    }
}
