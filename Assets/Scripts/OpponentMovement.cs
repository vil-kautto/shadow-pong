using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * OpponentrMovement -script handles the movement of the player character
 */
public class OpponentMovement : MonoBehaviour
{

    public Rigidbody2D body;
    public float moveSpeed;
    private Vector2 movement;

    // Start is called upon loading the scene
    void Start()
    {
        Debug.Log("PlayerMovement script loaded");
    }

    /**
     * Update handles the control input of the user
     */
    void Update()
    {
        movement.y = DefineMovement();
    }

    /**
     * Define the movement direction based on the position of the ball
     */
    int DefineMovement()
    {
        Vector3 pos = GameObject.Find("Ball").transform.position;
        // Debug.Log(pos.y);
        // Move up if the difference is above the treshold
        if(pos.y - body.position.y > 0.5)
        {
            return 1;
        }
        // Move down if the difference is below the treshold
        else if (pos.y - body.position.y < -0.5)
        {
            return -1;
        }
        // Otherwise, stay still
        else
        {
            return 0;
        }
    }

    /**
     * FixedUpdate is used to actually move the character in the game
     */
    void FixedUpdate()
    {
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}