using UnityEngine;
using System.Collections;

namespace CrystalMind
{
    public class AutoShoot : MonoBehaviour
    {
        public enum ShootMode
        {
            Default,
            RapidFire,
            Shotgun,
            Laser
        }

        public ShootMode shootMode = ShootMode.Default;

        public GameObject bulletPrefab;

        public Transform firePoint;

        public float fireRate = 1f;

        public float range = 15f;

        public int attack = 10;

        [SerializeField] private Animator characterAnimator;

        [Header("Rapid Fire")]
        public int rapidFireShots = 3;
        public float rapidFireDelay = 0.12f;

        [Header("Shotgun")]
        public int shotgunPellets = 5;
        public float shotgunSpreadAngle = 40f;

        [Header("Laser")]
        public LineRenderer laserLine;
        public float laserTickRate = 1f;
        public Vector3 laserOffset = Vector3.zero;

        float timer;
        float laserTimer;

        bool isBursting = false;

        void Update()
        {
            if (GameManager.instance.isGameOver) return;

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

                if (shootMode != ShootMode.Laser)
                {
                    if (timer >= fireRate)
                    {
                        Shoot(target);
                        timer = 0f;
                    }
                }
                else
                {
                    HandleLaser(target);
                }
            }
            else
            {
                if (laserLine != null)
                    laserLine.enabled = false;
            }
        }

        void Shoot(GameObject target)
        {
            if (bulletPrefab == null || firePoint == null)
                return;

            switch (shootMode)
            {
            case ShootMode.Default:
            SpawnBullet(firePoint.rotation);
            break;

            case ShootMode.RapidFire:
            if (!isBursting)
                StartCoroutine(RapidFireRoutine());
            break;

            case ShootMode.Shotgun:
            ShootShotgun();
            break;
            }
        }

        IEnumerator RapidFireRoutine()
        {
            isBursting = true;

            if (characterAnimator != null)
            {
                characterAnimator.SetTrigger("isShoot");
            }

            for (int i = 0; i < rapidFireShots; i++)
            {
                SpawnBullet(firePoint.rotation);

                if (i < rapidFireShots - 1)
                    yield return new WaitForSeconds(rapidFireDelay);
            }
            isBursting = false;
        }

        void SpawnBullet(Quaternion rot)
        {
            GameObject bulletObj = Instantiate(
                bulletPrefab,
                firePoint.position,
                rot
            );

            Bullet bullet = bulletObj.GetComponent<Bullet>();

            if (bullet != null)
            {
                bullet.SetDamage(attack);
            }
        }

        void ShootShotgun()
        {
            int pellets = Mathf.Max(1, shotgunPellets);

            float startAngle = -shotgunSpreadAngle * 0.5f;
            float angleStep = pellets > 1 ? shotgunSpreadAngle / (pellets - 1) : 0;

            for (int i = 0; i < pellets; i++)
            {
                float angle = startAngle + angleStep * i;

                Quaternion rot =
                    firePoint.rotation *
                    Quaternion.Euler(0, angle, 0);

                SpawnBullet(rot);
            }
        }

        void HandleLaser(GameObject target)
        {
            if (laserLine == null)
                return;

            laserLine.enabled = true;

            laserLine.SetPosition(0, firePoint.position);
            laserLine.SetPosition(1, target.transform.position + laserOffset);

            laserTimer += Time.deltaTime;

            if (laserTimer >= laserTickRate)
            {
                Enemy enemy = target.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(attack);
                }

                laserTimer = 0f;
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