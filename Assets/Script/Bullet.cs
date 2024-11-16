using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifespan = 5f; // Time in seconds before the bullet is destroyed

    void Start()
    {
        // Destroy the bullet after the specified lifespan
        Destroy(gameObject, lifespan);
    }

    // Optional: Add collision logic if needed
    private void OnCollisionEnter(Collision collision)
    {
        // Destroy bullet on collision
        Destroy(gameObject);
    }
}