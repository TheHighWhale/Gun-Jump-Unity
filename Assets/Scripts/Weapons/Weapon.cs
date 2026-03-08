using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int maxAmmo;
    public int currentAmmo;
    public float fireRate;
    public float reloadTime;
    public float reloadSpeed;

    public GameObject projectile;
    public float projectileSpeed;
    public Transform projectileSpawnLocation;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (gameObject.transform.rotation.x < 0)
        {
            //SpriteRenderer.Flip.x == true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            FireWeapon();
        }
    }

    void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        Debug.DrawLine(transform.position, transform.position + (Vector3)direction.normalized * 2f, Color.red, 0.5f);
    }

    void FireWeapon()
    {
        GameObject firedProjectile = Instantiate(projectile, projectileSpawnLocation.position, projectileSpawnLocation.rotation);

        Rigidbody2D rb = firedProjectile.GetComponent<Rigidbody2D>();

        rb.velocity =

        rb.velocity = projectileSpawnLocation.right * projectileSpeed * Time.deltaTime;
    }
}
