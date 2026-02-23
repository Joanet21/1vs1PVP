using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    float speed;

    public float speedX;
    public float jumpSpeedY;

    bool jumping = false;
    bool facingRight = true;
    public GameObject RightBullet;
    public GameObject LeftBullet;
    Transform FirePos;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        FirePos = transform.Find("FirePos");
    }

    void Update()
    {
        MovePlayer(speed);

        Flip();

        // --- INPUTS ---

        if (Input.GetKeyDown(KeyCode.J))
        {
            speed = -speedX;
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            speed = speedX;
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            speed = 0;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.I) && !jumping)
        {
            jumping = true;
            // En Unity 6 se usa linearVelocity, en versiones anteriores usa rb.velocity
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpSpeedY));
        }

        // --- GESTIÓN DE ANIMACIONES (Por Prioridad) ---

        // Aseguramos que "Status" esté entre comillas dobles
        if (jumping)
        {
            anim.SetInteger("Status", 2);
        }
        else if (speed != 0)
        {
            anim.SetInteger("Status", 1);
        }
        else
        {
            anim.SetInteger("Status", 0);
        }
    }

    void MovePlayer(float playerSpeed)
    {
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "GROUND")
        {
            jumping = false;
            anim.SetInteger("Status", 0);
        }
    }

    void Flip()
    {
        // code for change direction of the player
        if (speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }
    void Fire()
    {
        if (facingRight)
        {
            Instantiate(RightBullet, FirePos.position, Quaternion.identity);
        }
        if (!facingRight)
        {
            Instantiate(LeftBullet, FirePos.position, Quaternion.identity);
        }
    }
}