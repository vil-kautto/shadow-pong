using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * BallMovement class is used to define interactions between ball and other objects
 */
public class BallMovement : MonoBehaviour
{
    // Ball 
    public Rigidbody2D ball;
    // MoveSpeed controls the movement speed of the ball
    public float moveSpeed = 5f;
    // StartPosition defines the starting position of the ball
    private Vector3 startPosition;

    /**
     * Start method is run on the start of the scene
     * This starts the primary gameplay loop
     */
    void Start()
    {
        startPosition = new Vector3(0, 0, 0);
        Debug.Log("Ball movement script loaded");
        BallReset();
    }

    // LastVelocity is used to calculate the ricochet direction of the ball
    private Vector3 lastVelocity;

    /**
     * Update continiously updates the ball's velocity
     */
    void Update()
    {
        lastVelocity = ball.velocity;  
    }

    // resetDelay defines the delay between rounds
    public int resetDelay;
    // Timer counts down to round start
    private float timer;
    // TimerText displays the timer countdown in the UI
    public TextMeshProUGUI TimerText;

    /**
     * BallReset controls the game flow
     * This method resets the ball position between rounds and manages the delay for the round start
     */
    public void BallReset()
    {
        ball.velocity = new Vector3(0, 0, 0);
        ball.transform.position = startPosition;
        timer = resetDelay;
        TimerText.text = timer.ToString();
        for(int i = 0; i<resetDelay; i++)
        {
            Invoke("UpdateTimer", (float)(timer - i));
        }
        Invoke("StartGame", (float)resetDelay);
    }

    /**
     * Updates the timer text when called
     */
    void UpdateTimer()
    {
        timer--;
        Debug.Log("Updated timer with value: " + timer);
        TimerText.text = timer.ToString();
    }

    /**
     * Starts the game when called
     */
    void StartGame()
    {
        ball.AddForce(new Vector2(moveSpeed, 1));
        TimerText.text = "";
    }

    // Variables that tally the scores
    private int playerScore = 0;
    private int opponentScore = 0;

    /** 
     * OnCollisionEnter2D Handles the collisions with the ball
     * The direction of ricochet is depending on the properties of the ball 
     * The score changes if the ball hits the wall behind the players
     */
    void OnCollisionEnter2D(Collision2D collidedObject)
    {
        // Calculating the direction after a collision happens with the ball
        Debug.Log("Collision happened with" + collidedObject.collider.tag);
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collidedObject.contacts[0].normal);
        ball.velocity = direction * Mathf.Max(speed, 0f);
        // Upon hitting a goal, end the round and start a new one
        if (collidedObject.gameObject.CompareTag("Score"))
        {
            if (collidedObject.gameObject.name == "PlayerWall")
            {
                opponentScore++;
                FindObjectOfType<GameController>().EndRound( "opponent", opponentScore);
            }
            if (collidedObject.gameObject.name == "OpponentWall")
            {
                playerScore++;
                FindObjectOfType<GameController>().EndRound("player", playerScore);
            }
        }
    }
}


