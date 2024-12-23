using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float jumpForce = 10f;
    public bool isGrounded;
    private Rigidbody2D rb;
    public Weapon equippedWeapon;  // Directly reference the weapon
    public Transform weaponTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (equippedWeapon != null)
        {
            RotateGun();
        }

        // Get horizontal input from the "Movement" axis
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(horizontalInput, 0f);

        // Set the player's velocity based on input
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        // Jump when grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // Rotate gun
        RotateGun();

        // Shoot weapon directly
        if (Input.GetButton("Fire1") && equippedWeapon != null)
        {
            equippedWeapon.Shoot();
        }
    }

    void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - weaponTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weaponTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position + Vector3.down * 0.1f, 0.1f, LayerMask.GetMask("Ground"));
    }
}
