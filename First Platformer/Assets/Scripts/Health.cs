using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maximumHealth;
    private float currentHealth;
    public bool isAlive;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        currentHealth = maximumHealth;
        isAlive = true;
        healthBar.SetMaxHealth(maximumHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currentHealth > 0)
            isAlive = true;
        else
        {
            isAlive = false;
        }

        animator.SetBool("IsDead", !isAlive);
    }
}
