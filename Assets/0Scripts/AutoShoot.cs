using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform firePoint;

    public float fireRange = 10f;
    public float fireRate = 1f;
    public float rotateSpeed = 8f;
    public float shootAngleThreshold = 10f;

    public AudioSource audioSource;
    public AudioClip shootSFX;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject closest = null;
        float minDist = fireRange;

        foreach (GameObject e in enemies)
        {
            float d = Vector3.Distance(transform.position, e.transform.position);

            if (d < minDist)
            {
                minDist = d;
                closest = e;
            }
        }

        if (closest != null)
        {
            Vector3 dir = closest.transform.position - transform.position;
            dir.y = 0f;

            Quaternion targetRotation = Quaternion.LookRotation(dir);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );

            float angle = Vector3.Angle(transform.forward, dir);

            if (angle < shootAngleThreshold && timer >= fireRate)
            {
                timer = 0;

                if (shootSFX != null)
                {
                    audioSource.PlayOneShot(shootSFX);
                }

                Instantiate(
                    bulletPrefab,
                    firePoint.position,
                    firePoint.rotation
                );
            }
        }
    }
}