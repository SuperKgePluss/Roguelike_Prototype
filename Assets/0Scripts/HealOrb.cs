using UnityEngine;

namespace CrystalMind
{
    public class HealOrb : MonoBehaviour
    {
        public int healAmount = 1;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerHealth ph = other.GetComponent<PlayerHealth>();

                if (ph != null)
                {
                    ph.Heal(healAmount);
                }

                Destroy(gameObject);
            }
        }
    }
}