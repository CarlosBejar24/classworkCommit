using System.Collections;
using UnityEngine;

public class CharacterRuiz : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [Header("Special Power: Dash Boost")]
    public float dashSpeed = 18f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    private bool isDashing = false;
    private bool canDash = true;
    private Vector2 lastDirection = Vector2.right;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing) return;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;

        if (moveInput != Vector2.zero)
        {
            lastDirection = moveInput;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(UsePowerDash());
        }
    }

    void FixedUpdate()
    {
        if (isDashing) return;

        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    IEnumerator UsePowerDash()
    {
        canDash = false;
        isDashing = true;

        Vector2 dashDir = moveInput != Vector2.zero ? moveInput : lastDirection;
        rb.linearVelocity = dashDir * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        rb.linearVelocity = Vector2.zero;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}