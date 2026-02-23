using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;
    public float delay = 3f;
    private ScoreManager scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = new Vector2(speed, 0);

        Destroy(gameObject, delay);

        scoreManager = Object.FindAnyObjectByType<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player3"))
        {
            scoreManager.AddScore1();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player1"))
        {
            scoreManager.AddScore2();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("GROUND"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy (collision.gameObject);
            Destroy(gameObject);
        }
    }
}