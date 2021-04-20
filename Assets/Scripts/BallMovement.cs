using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{

    public Rigidbody2D ball;
    public float moveSpeed = 5f;
    private Vector3 lastVelocity;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = new Vector3(0, 0, 0);
        Debug.Log("Ball movement script loaded");
        BallReset();
    }


    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI opponentScoreText;
    private int playerScore = 0;
    private int opponentScore = 0;

    void Update()
    {
        lastVelocity = ball.velocity;
        playerScoreText.text = $"Player's Score: {playerScore}";
        opponentScoreText.text = $"Opponent's Score: {opponentScore}";
    }

    public float resetDelay;

    void BallReset()
    {
        ball.velocity = new Vector3(0, 0, 0);
        ball.transform.position = startPosition;
        Invoke("StartGame", resetDelay);
    }

    void StartGame()
    {
        ball.AddForce(new Vector2(moveSpeed, 1));
    }

    void OnCollisionEnter2D(Collision2D collidedObject)
    {
        Debug.Log("Collision happened with" + collidedObject.collider.tag);
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collidedObject.contacts[0].normal);
        ball.velocity = direction * Mathf.Max(speed, 0f);
        if (collidedObject.gameObject.CompareTag("Score"))
        {
            if (collidedObject.gameObject.name == "PlayerWall")
            {
                opponentScore++;
                Debug.Log("Opponent's score: " + opponentScore.ToString());
                FindObjectOfType<GameController>().EndRound();

                BallReset();
            }
            if (collidedObject.gameObject.name == "OpponentWall")
            {
                playerScore++;
                Debug.Log("Player's score: " + playerScore.ToString());
                FindObjectOfType<GameController>().EndRound();
                
                BallReset();
            }
        }
    }

    void Wait(float time)
    {
        Debug.Log("the wait starts");
        time -= Time.deltaTime;
        Debug.Log(time);
        //while (time < 0)
        //{
        //}
        Debug.Log("the wait ends");
    }
}


