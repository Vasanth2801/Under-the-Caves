using UnityEngine;
public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int facingDirection = 1;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform firePointTransform;

    [Header("Input Settings")]
    [SerializeField] private float movement;

    [Header("Jump Settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded;

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        if (movement > 0 && transform.localScale.x < 0  || movement < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        Jump();

        HandleAnimations();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(movement * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void HandleAnimations()
    {
        bool isMoving = Mathf.Abs(movement) > 0.01f && isGrounded;

        animator.SetBool("isIdling", !isMoving && isGrounded);
        animator.SetBool("isRunning", isMoving && isGrounded);
        animator.SetBool("isJumping", rb.linearVelocity.y > 0);
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        firePointTransform.Rotate(0f, 180f, 0f);
    }
}