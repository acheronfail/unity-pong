using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    private Vector2 initialPosition;

    private float speed = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetBall() {
        speed = 5;
        rb.position = initialPosition;
        float randomX = Random.value < 0.5f ? -1f : 1f;
        float randomY = Random.value < 0.5f ? -1f : 1f;
        rb.linearVelocity = new Vector2(speed * randomX, speed * randomY);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player1Goal"))
        {
            FindAnyObjectByType<GameController>().Player2Scored();
            rb.linearVelocity = Vector2.zero;
        }
        else if (other.CompareTag("Player2Goal"))
        {
            FindAnyObjectByType<GameController>().Player1Scored();
            rb.linearVelocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player"))
        {
            speed += 1;
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }
    }
}
