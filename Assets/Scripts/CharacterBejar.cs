using UnityEngine;

public class CharacterBejar : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [Header("Poder Especial: Lanzar Objeto")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    private Vector2 lastDirection = Vector2.right;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;

        if (moveInput != Vector2.zero)
        {
            lastDirection = moveInput;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UsePower();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    void UsePower()
    {
        if (bulletPrefab != null)
        {
            Vector3 spawnPosition = firePoint != null ? firePoint.position : transform.position;
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            if (bulletRb != null)
            {
                bulletRb.linearVelocity = lastDirection * bulletSpeed;
            }

            Destroy(bullet, 3f);
        }
    }
}