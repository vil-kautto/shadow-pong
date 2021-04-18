using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{

    public Rigidbody2D ball;
    public float moveSpeed = 5f;
    private Vector3 lastVelocity;
    private int playerScore = 0;
    private int opponentScore = 0;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI opponentScoreText;

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
        playerScoreText.text = $"Player's Score: {playerScore}";
        opponentScoreText.text = $"Opponent's Score: {opponentScore}";
    }

    void fixedUpdateUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collidedObject)
    {
        Debug.Log("Collision happened with" + collidedObject.collider.tag);
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collidedObject.contacts[0].normal);
        ball.velocity = direction * Mathf.Max(speed, 0f);
        if (collidedObject.gameObject.CompareTag("Score"))
        {
            Debug.Log("The ball hit the " + collidedObject.collider.tag);
            if (collidedObject.gameObject.name == "PlayerWall")
            {
                opponentScore++;
                Debug.Log("Opponent's score: " + opponentScore.ToString());
            }
            if (collidedObject.gameObject.name == "OpponentWall")
            {
                playerScore++;
                Debug.Log("Player's score: " + playerScore.ToString());
            }

        }
    }

}
