using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private bool facingRight = true;
    private float gravityScale = 3f;
    private float moveSpeed = 8f;
    private float jumpForce = 12f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.8f);
        }

        Flip();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        if (facingRight && horizontal < 0 || !facingRight && horizontal > 0)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;    
        }
    }
}
