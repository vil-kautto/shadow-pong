using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * OpponentrMovement -script handles the movement of the player character
 */
public class OpponentMovement : MonoBehaviour
{

    public Rigidbody2D body;
    public float moveSpeed = 5f;
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
        movement.y = Input.GetAxisRaw("Vertical");
    }

    /**
     * FixedUpdate is used to actually move the character in the game
     */
    void FixedUpdate()
    {
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}