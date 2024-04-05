using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Speed at which the player moves forward
    public float jumpForce = 5f;
    public float sideSpeed = 3.0f; // Speed at which the player moves sideways
    private Rigidbody rb;
    private Animator animator;
    private Vector2 touchStartPos;
    public float swipeThreshold = 50f; // Minimum length of swipe for it to count
    private bool isRunning = true; // true for now but only run after start of the game

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Space) && !animator.GetBool("isJumping"))
        {
            Jump();
        }

        // Handle mobile input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Detect swipe for jump
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 touchEndPos = touch.position;
                float swipeVertical = touchEndPos.y - touchStartPos.y;

                if (swipeVertical > swipeThreshold && !animator.GetBool("isJumping"))
                {
                    Jump();
                }
            }

            // Touch controls for left/right movement are handled in FixedUpdate for smoother physics updates
        }

    }

    void FixedUpdate()
    {
        
            // Apply a continuous forward force
            rb.MovePosition(rb.position + transform.forward * speed * Time.fixedDeltaTime);

            // Mobile sideways movement based on touch position
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
                {
                    MoveLeft();
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    MoveRight();
                }
            }

            // Keyboard controls for left/right movement for testing purposes
            float sideMove = Input.GetAxis("Horizontal") * sideSpeed;
            Vector3 sideMovement = new Vector3(sideMove, 0, 0) * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + sideMovement);
        
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        animator.SetBool("isJumping", true);
    }

    void MoveLeft()
    {
        rb.MovePosition(rb.position - transform.right * sideSpeed * Time.fixedDeltaTime);
    }

    void MoveRight()
    {
        rb.MovePosition(rb.position + transform.right * sideSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
        }
    }

     public void StartRunning() // Add this method
    {
        isRunning = true;
    }
}
