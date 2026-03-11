using UnityEngine;

namespace CrystalMind
{
    public class OrbitAbility : MonoBehaviour
    {
        public float radius = 2f;
        public float rotateSpeed = 180f;
        public int damage = 100;

        public float lifeTime = 5f;

        Transform center;

        void Start()
        {
            center = transform.parent;

            if (center != null)
            {
                transform.position =
                    center.position + transform.right * radius;
            }

            Destroy(gameObject, lifeTime);
        }

        void Update()
        {
            if (center == null) return;

            transform.RotateAround(
                center.position,
                Vector3.up,
                rotateSpeed * Time.deltaTime
            );
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().TakeDamage(damage);
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}