using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public Rigidbody2D body;
    public float moveSpeed = 50f;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        movement.x = 1;
        Debug.Log("Ball movement script loaded");
    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(movement * moveSpeed * Time.deltaTime, 0);
    }

    void fixedUpdateUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collidedObject)
    {
        Debug.Log("Collision happened with" + collidedObject.collider.tag);
        if (collidedObject.collider.tag == "Wall")
        {
            movement.y = movement.y * -1;
        }
        else if (collidedObject.collider.tag == "Player")
        {
            movement.x = movement.x * -1;
        }
        else if (collidedObject.collider.tag == "Finish")
        {

            Debug.Log("The ball hit the " + collidedObject.collider.tag);
        }
    }

}
