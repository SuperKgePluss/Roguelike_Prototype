using Unity.VisualScripting;
using UnityEngine;

namespace CrystalMind
{
    public class TrapAbility : MonoBehaviour
    {
        public int damage = 5;
        public bool isStun = false;

        public float lifeTime = 3f;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<Enemy>();
                enemy.TakeDamage(damage);
                if (isStun)
                {
                    enemy.Stun(1.5f);
                }

                Destroy(gameObject);
            }
        }
    }
}