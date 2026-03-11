using UnityEngine;

namespace CrystalMind
{
    public class AOEAbility : MonoBehaviour
    {
        public float radius = 5f;
        public int damage = 5;

        public float lifeTime = 5f;

        void Start()
        {
            Collider[] hits = Physics.OverlapSphere(
                transform.position,
                radius
            );

            foreach (var hit in hits)
            {
                if (hit.CompareTag("Enemy"))
                {
                    hit.GetComponent<Enemy>().TakeDamage(damage);
                }
            }

            Destroy(gameObject, lifeTime);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}