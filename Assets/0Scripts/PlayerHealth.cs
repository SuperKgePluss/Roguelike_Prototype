using UnityEngine;

namespace CrystalMind
{
    public class PlayerHealth : MonoBehaviour
    {
        public int maxHealth = 5;
        private int currentHealth;
        public bool isDead = false;
        [SerializeField] private Animator characterAnimator;

        private int ranDeadAnimIndex = 0;

        void Start()
        {
            currentHealth = maxHealth;
            UIManager._instance.UpdateHP(currentHealth, maxHealth);

            ranDeadAnimIndex = Random.Range(0, 3);
        }

        public void TakeDamage(int damage)
        {
            if (isDead) return;

            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
            Debug.Log("Player HP: " + currentHealth);
            UIManager._instance.UpdateHP(currentHealth, maxHealth);

            if (currentHealth <= 0)
            {
                Debug.Log("GAME OVER");
                isDead = true;

                if (characterAnimator != null)
                {
                    characterAnimator.SetTrigger("isDead");
                }

                GameManager.instance.GameOver();
            }
        }

        public void Heal(int amount)
        {
            if (isDead) return;

            currentHealth += amount;

            if (currentHealth > maxHealth)
                currentHealth = maxHealth;

            UIManager._instance.UpdateHP(currentHealth, maxHealth);
        }
    }
}