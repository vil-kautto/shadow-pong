using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script handles the movement of the player character
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public float moveSpeed = 5f;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlayerMovement script loaded");
    }

    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(movement.y);
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

