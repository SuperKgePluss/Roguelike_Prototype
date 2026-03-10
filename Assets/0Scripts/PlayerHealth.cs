using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    public bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        Debug.Log("Player HP: " + currentHealth);
        UIManager._instance.UpdateHP(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("GAME OVER");
            isDead = true;
            GameManager.instance.GameOver();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UIManager._instance.UpdateHP(currentHealth);
    }
}