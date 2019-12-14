using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpVelocity = 5f;
    [SerializeField] private float fallSpeed = 2f;
    [SerializeField] private float smallJumpVelocity = 2f;
    [SerializeField] private float defaultGravityScale = 2f;
    
    private bool tryJump;
    private Rigidbody2D rb;
    private bool isGrounded;

    public Animator _animator;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetButtonDown("Jump"))
        {
            tryJump = true;
        }
#endif

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                tryJump = true;
            }
        }

        if (isGrounded)
        {
            _animator.SetBool("Fall", false);
            _animator.SetBool("Jump", false);
        }
    }
    private void FixedUpdate()
    {
        if (tryJump && isGrounded)
        {
            Jump();
            tryJump = false;
        }

        if (rb.velocity.y < -1f)
        {
            FallAnimtion();
        }
        
        if (rb.velocity.y < 0f)
        {
            rb.gravityScale = fallSpeed;
        }
        else if (rb.velocity.y > 0 &&  Input.touchCount <= 0) //!Input.GetButton("Jump") 
        {
            rb.gravityScale = smallJumpVelocity;
            JumpAnimation();
        }
        else
        {
            rb.gravityScale = defaultGravityScale;
        }
    }
    private void Jump()
    {
        JumpAnimation();
        rb.AddForce(Vector2.up * jumpVelocity , ForceMode2D.Impulse);
    }

    void JumpAnimation()
    {
        _animator.SetBool("Fall", false);
        _animator.SetBool("Jump", true);
    }

    void FallAnimtion()
    {
        _animator.SetBool("Fall", true);
        _animator.SetBool("Jump", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
