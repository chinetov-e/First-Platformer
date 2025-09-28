using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float enemyDamage = 30;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("collision happened");
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
                playerHealth.TakeDamage(enemyDamage);
        }
    }
}
