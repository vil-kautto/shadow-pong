using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public Rigidbody2D ball;
    public float moveSpeed = 5f;
    Vector3 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        ball.AddForce(new Vector2(moveSpeed, 1));
        Debug.Log("Ball movement script loaded");
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = ball.velocity;
    }

    void fixedUpdateUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collidedObject)
    {
        Debug.Log("Collision happened with" + collidedObject.collider.tag);

        /* if (collidedObject.gameObject.CompareTag("Wall"))
        {
            movement.y = movement.y * -1;
        }
        if (collidedObject.gameObject.CompareTag("Player"))
        {
            movement.y = movement.y * -1;
            movement.x = movement.x * -1;
        }
        */
        if (!collidedObject.gameObject.CompareTag("finish"))
        {
            Debug.Log("The ball hit the " + collidedObject.collider.tag);
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collidedObject.contacts[0].normal);
            ball.velocity = direction * Mathf.Max(speed, 0f);
        }
        else if (collidedObject.gameObject.CompareTag("finish"))
        {
            Debug.Log("The ball hit the " + collidedObject.collider.tag);
        }
    }

}
