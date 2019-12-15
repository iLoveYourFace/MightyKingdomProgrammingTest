using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used to control the character and its animations
public class PlayerMovement : MonoBehaviour
{
    //Jump settings
    [SerializeField] private float jumpVelocity = 5f;
    [SerializeField] private float fallSpeed = 2f;
    [SerializeField] private float smallJumpVelocity = 2f;
    [SerializeField] private float defaultGravityScale = 2f;
    
    private bool tryJump;
    private bool isGrounded;

    private Rigidbody2D playerRigidbody2D;
    public Animator _animator;
    
    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        //Read inputs to see if user wants to jump
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
        //If the user is trying to jump and player is on the ground then the player will jump
        if (tryJump && isGrounded)
        {
            Jump();
            tryJump = false;
        }

        //If the player's velocity is negative then they are falling
        if (playerRigidbody2D.velocity.y < 0f)
        {
            FallAnimtion();
            playerRigidbody2D.gravityScale = fallSpeed;
        }
        #if UNITY_EDITOR
        else if (playerRigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerRigidbody2D.gravityScale = smallJumpVelocity;
            JumpAnimation();
        }
        #elif UNITY_ANDROID
        else if (rb.velocity.y > 0 && Input.touchCount <= 0)
        {
            rb.gravityScale = smallJumpVelocity;
            JumpAnimation();
        }
        #endif
        else
        {
            playerRigidbody2D.gravityScale = defaultGravityScale;
        }
    }
    private void Jump()
    {
        JumpAnimation();
        playerRigidbody2D.AddForce(Vector2.up * jumpVelocity , ForceMode2D.Impulse);
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
