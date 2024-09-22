using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private bool isGrounded;
    private Rigidbody2D rb;
    public float jumpForce = 10f; // Adjust jump height as needed

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1f;
        }

        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y); // Maintain vertical velocity 

        // Jump logic (only jump when grounded)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Reset grounded state on jump
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position + Vector3.down * 0.1f, 0.1f, LayerMask.GetMask("Ground"));
    }
}

