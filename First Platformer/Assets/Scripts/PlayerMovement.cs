using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement Vars")]
    [SerializeField] private float jumpForce = 3;
    [SerializeField] bool isGrounded = false;


    [Header("Settings")]
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private float groundCheckRadius = 0.7f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Animator animator;

    [Header("Attack Settings")]
    [SerializeField] private float attackDamage = 10;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCircleTransform = groundCheckTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCircleTransform, groundCheckRadius, groundMask);
        animator.SetBool("IsJumping", !isGrounded);
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
            Jump();

        if (Math.Abs(direction) > 0.01f)
            HorizontalMovement(direction);

        animator.SetBool("IsRunning", Math.Abs(direction) > 0.01f);
    }

    private void Jump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

    }

    private void HorizontalMovement(float direction)
    {
        rb.linearVelocity = new Vector2(curve.Evaluate(direction), rb.linearVelocity.y);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
                enemyHealth.TakeDamage(attackDamage);
        }
    }

    private void OawGizmos()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
