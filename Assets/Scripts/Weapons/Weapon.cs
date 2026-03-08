using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int maxAmmo;
    public int currentAmmo;
    public float fireRate;
    public float reloadTime;
    public float reloadSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.transform.rotation.x < 0)
        {
            SpriteRenderer.Flip.x == true;
        }
    }
}
