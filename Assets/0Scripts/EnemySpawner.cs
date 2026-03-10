using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject bossPrefab;

    public int wave = 4;
    public int enemiesPerWave = 5;

    public float timeBetweenSpawns = 1f;
    public float timeBetweenWaves = 5f;

    void Start()
    {
        UIManager._instance.UpdateWave(wave);
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            Debug.Log("Wave : " + wave);

            if (wave % 5 == 0)
            {
                SpawnBoss();
            }

            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(timeBetweenSpawns);
            }

            yield return new WaitUntil(() =>
                GameObject.FindGameObjectsWithTag("Enemy").Length == 0
            );

            UIManager._instance.ShowWaveComplete(wave);

            yield return new WaitForSeconds(2f);

            wave++;

            if (wave % 5 == 0)
            {
                UIManager._instance.ShowBossWarning(true);
            }
            else
            {
                UIManager._instance.ShowBossWarning(false);
            }

            ScaleDifficulty();

            UIManager._instance.UpdateWave(wave);

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        PlayerHealth player = FindObjectOfType<PlayerHealth>();

        if (player != null && player.isDead)
            return;

        Transform playerTransform = player.transform;

        float spawnRadius = 10f;
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

        float x = playerTransform.position.x + Mathf.Cos(angle) * spawnRadius;
        float z = playerTransform.position.z + Mathf.Sin(angle) * spawnRadius;

        Vector3 spawnPos = new Vector3(x, 0.5f, z);

        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }

    void ScaleDifficulty()
    {
        enemiesPerWave += 1;

        if (timeBetweenSpawns > 0.3f)
        {
            timeBetweenSpawns -= 0.05f;
        }
    }

    void SpawnBoss()
    {
        PlayerHealth player = FindObjectOfType<PlayerHealth>();

        Vector3 pos = player.transform.position + new Vector3(10, 0, 0);

        Instantiate(bossPrefab, pos, Quaternion.identity);

        FindObjectOfType<UIManager>().ShowBossWarning(false);
    }
}