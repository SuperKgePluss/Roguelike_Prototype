using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CrystalMind
{
    public class DOTDamage : MonoBehaviour
    {
        public int damage = 5;

        public float tickRate = 1f;

        HashSet<Enemy> enemies = new HashSet<Enemy>();

        public float lifeTime = 5f;

        private void Start()
        {
            Destroy(gameObject, 5f);
        }

        void OnTriggerEnter(Collider other)
        {
            CrystalMind.Enemy enemy = other.GetComponent<CrystalMind.Enemy>();

            if (enemy != null)
            {
                enemies.Add(enemy);
                StartCoroutine(DamageRoutine(enemy));
            }
        }

        void OnTriggerExit(Collider other)
        {
            CrystalMind.Enemy enemy = other.GetComponent<CrystalMind.Enemy>();

            if (enemy != null)
            {
                enemies.Remove(enemy);
            }
        }

        IEnumerator DamageRoutine(Enemy enemy)
        {
            while (enemies.Contains(enemy) && enemy != null)
            {
                enemy.TakeDamage(damage);

                yield return new WaitForSeconds(tickRate);
            }
        }
    }
}