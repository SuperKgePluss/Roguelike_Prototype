using UnityEngine;

namespace CrystalMind
{
    public class BossBullet : MonoBehaviour
    {
        public float speed = 6f;
        public float lifeTime = 5f;
        public int damage = 1;

        PlayerHealth leaderHP;

        void Start()
        {
            leaderHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

            Destroy(gameObject, lifeTime);
        }

        void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Ally"))
            {
                //PlayerHealth ph = other.GetComponent<PlayerHealth>();

                if (leaderHP != null)
                {
                    leaderHP.TakeDamage(damage);
                }

                Destroy(gameObject);
            }
        }
    }
}