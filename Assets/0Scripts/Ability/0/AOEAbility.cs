using System.Collections;
using UnityEngine;

namespace CrystalMind
{
    public class AOEAbility : MonoBehaviour
    {
        public float radius = 5f;
        public int damage = 5;

        public float lifeTime = 5f;
        public float delay = 0.1f;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(delay);
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