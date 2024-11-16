using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // Assign your bullet prefab in the inspector
    public Transform shootingPoint;   // Point from where the bullet will be instantiated
    public float bulletSpeed = 20f;   // Speed of the bullet

    void Update()
    {
        // Check if the player presses the fire button (left mouse button)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 shootDirection;

        if (Physics.Raycast(ray, out hit))
        {
            shootDirection = (hit.point - shootingPoint.position).normalized;
        }
        else
        {
            shootDirection = shootingPoint.forward;
        }

        shootDirection.y = 0;
        shootDirection.Normalize(); 

       
        rb.velocity = shootDirection * bulletSpeed;
    }
}