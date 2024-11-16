using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;           // Speed of the enemy
    public float detectionRange = 10f;      // Range to detect the player
    public int health = 100;                 // Health of the enemy
    public int maxHits = 3;                  // Maximum number of hits before the enemy dies
    private int currentHits = 0;             // Current hit count
    public Transform player;                 // Reference to the player transform

    private void Update()
    {
        // Check distance to the player
        if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calculate direction to the player
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Ensure the enemy moves on the X-Z plane

        // Move the enemy
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    // Method to handle damage
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(10f); // Example damage amount
            Destroy(other.gameObject); // Destroy the bullet
        }
    }

    void TakeDamage(float damage)
    {
        currentHits++; // Increment the hit counter
        Debug.Log($"Hit taken: {currentHits}/{maxHits}"); // Log the hits

        if (currentHits >= maxHits)
        {
            Debug.Log("Enemy destroyed!"); // Log when the enemy is destroyed
            Die(); // If maximum hits are reached, call Die()
        }
        else
        {
            health -= (int)damage; // Reduce health if needed
        }
    }

    void Die()
    {
        // Logic for enemy death (e.g., play animation, drop loot)
        Destroy(gameObject);
    }
}