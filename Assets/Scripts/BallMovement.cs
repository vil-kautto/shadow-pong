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

    /**
     * Start method is run on the start og the scene
     * This starts the primary gameplay loop
     */
    void Start()
    {
        startPosition = new Vector3(0, 0, 0);
        Debug.Log("Ball movement script loaded");
        BallReset();
    }
    
    public TextMeshProUGUI TimerText;
    private int playerScore = 0;
    private int opponentScore = 0;
    
    /**
     * Update continiously updates the values for ingame variables 
     */
    void Update()
    {
        lastVelocity = ball.velocity;  
    }

    public int resetDelay;
    private float timer;

    /**
     * BallReset controls the game flow
     * This method resets the ball position between rounds and manages the delay for the round start
     */
    void BallReset()
    {
        ball.velocity = new Vector3(0, 0, 0);
        ball.transform.position = startPosition;
        Debug.Log(resetDelay);
        timer = resetDelay;
        TimerText.text = timer.ToString();
        for(int i = 1; i<resetDelay; i++)
        {
            Invoke("UpdateTimer", (float)(timer - i));
        }
        
        Invoke("StartGame", (float)resetDelay);
    }

    void UpdateTimer()
    {
        timer--;
        Debug.Log("Updated timer with value: " + timer);
        TimerText.text = timer.ToString();
        
    }

    void StartGame()
    {
        ball.AddForce(new Vector2(moveSpeed, 1));
        TimerText.text = "";
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
                FindObjectOfType<GameController>().EndRound( "opponent", opponentScore);

                BallReset();
            }
            if (collidedObject.gameObject.name == "OpponentWall")
            {
                playerScore++;
                FindObjectOfType<GameController>().EndRound("player", playerScore);
                BallReset();
            }
        }
    }
}


