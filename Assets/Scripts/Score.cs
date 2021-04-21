using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI opponentScoreText;
    public int playerScore;
    public int opponentScore;

    void Update()
    {
        playerScoreText.text = $"{playerScore}";
        opponentScoreText.text = $"{opponentScore}";
    }
}
