using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
    public float moveSpeed = 3f;
    public int health = 1;
    public GameObject expPrefab;
    public GameObject healPrefab;
    public GameObject magnetPrefab;

    public bool isBoss = false;
    public GameObject bossBullet;
    public float shootCooldown = 2f;

    public AudioClip deathSFX;

    private Transform player;
    float shootTimer;

    public enum EnemyType
    {
        Basic,
        Runner,
        Spitter,
        Elite
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        SetupEnemy();
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0;

            transform.rotation = Quaternion.LookRotation(direction);

            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        }

        if (isBoss)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= shootCooldown)
            {
                shootTimer = 0;
                ShootRadial();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        float r = UnityEngine.Random.value;

        if (health <= 0)
        {
            if (r < 0.7f)
            {
                Instantiate(expPrefab, transform.position, Quaternion.identity);
            }
            else if (r < 0.9f)
            {
                Instantiate(healPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(magnetPrefab, transform.position, Quaternion.identity);
            }

            if (deathSFX != null)
            {
                AudioSource.PlayClipAtPoint(
                deathSFX,
                transform.position
                );
            }

            GameManager.instance.AddScore(1);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }

    void SetupEnemy()
    {
        switch (enemyType)
        {
        case EnemyType.Basic:
        moveSpeed = 3f;
        health = 3;
        break;

        case EnemyType.Runner:
        moveSpeed = 6f;
        health = 1;
        break;

        case EnemyType.Spitter:
        moveSpeed = 2f;
        health = 3;
        break;

        case EnemyType.Elite:
        moveSpeed = 2f;
        health = 10;
        break;
        }
    }

    void ShootRadial()
    {
        for (int i = 0; i < 8; i++)
        {
            float angle = i * 45f;

            Vector3 dir = Quaternion.Euler(0, angle, 0) * Vector3.forward;

            Instantiate(
                bossBullet,
                transform.position,
                Quaternion.LookRotation(dir)
            );
        }
    }
}