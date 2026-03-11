using UnityEngine;

namespace CrystalMind
{
    public class AutoShoot : MonoBehaviour
    {
        public GameObject bulletPrefab;

        public Transform firePoint;

        public float fireRate = 1f;

        public float range = 15f;

        public int attack = 10;

        float timer;

        void Update()
        {
            GameObject target = FindNearestEnemy();

            if (target != null)
            {
                Vector3 dir = target.transform.position - transform.position;

                dir.y = 0;

                if (dir != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(dir);
                }

                timer += Time.deltaTime;

                if (timer >= fireRate)
                {
                    Shoot();
                    timer = 0f;
                }
            }
        }

        void Shoot()
        {
            if (bulletPrefab == null || firePoint == null)
                return;

            GameObject bulletObj = Instantiate(
                bulletPrefab,
                firePoint.position,
                firePoint.rotation
            );

            Bullet bullet = bulletObj.GetComponent<Bullet>();

            if (bullet != null)
            {
                bullet.SetDamage(attack);
            }
        }

        GameObject FindNearestEnemy()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            float minDist = range;

            GameObject nearest = null;

            foreach (GameObject e in enemies)
            {
                float dist = Vector3.Distance(transform.position, e.transform.position);

                if (dist < minDist)
                {
                    minDist = dist;
                    nearest = e;
                }
            }

            return nearest;
        }
    }
}