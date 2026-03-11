using UnityEngine;

namespace CrystalMind
{
    public class Bullet : MonoBehaviour
    {
        public int damage;

        public float speed = 10f;

        public float lifeTime = 3f;

        void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        public void SetDamage(int value)
        {
            damage = value;
        }

        void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);

                Destroy(gameObject);
            }
        }
    }
}