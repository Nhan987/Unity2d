using UnityEngine;

public class Player_Moverment : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator anim;
    public int facingDirection = 1;
    public Player_Combat player_Combat;

    void Update()
    {
        if (Input.GetButtonDown("Slash"))

        {

            player_Combat.Attack();

        }

    
}

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0 && transform.localScale.x < 0 ||
            horizontal < 0 && transform.localScale.x > 0)
        {
            flip();
        }

        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));

        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
    }

    public void flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}