using UnityEngine;

public class playermove : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveDirection = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }
        else if (moveDirection > 0)
        {
            transform.localScale = new Vector3(4, 4, 4);
        }


        if (Mathf.Abs(rb.velocity.x) < 0.5f)
        {
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("run", true);
        }
    }
}
