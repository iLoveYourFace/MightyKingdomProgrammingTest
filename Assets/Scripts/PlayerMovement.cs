using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpVelocity = 5f;
    [SerializeField] private float fallSpeed = 2f;
    [SerializeField] private float smallJumpVelocity = 2f;
    [SerializeField] private float defaultGravityScale = 2f;
    
    private bool tryJump;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            tryJump = true;
        }
    }
    private void FixedUpdate()
    {
        if (tryJump)
        {
            Jump();
            tryJump = false;
        }

        if (rb.velocity.y < 0f)
        {
            rb.gravityScale = fallSpeed;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = smallJumpVelocity;
        }
        else
        {
            rb.gravityScale = defaultGravityScale;
        }
    }
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpVelocity , ForceMode2D.Impulse);
    }
}
