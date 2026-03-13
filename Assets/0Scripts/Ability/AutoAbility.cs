using UnityEngine;

public class AutoAbility : Ability
{
    public GameObject abilityPrefab;

    public int damage = 1;

    public float range = 8f;

    public int count = 1;

    public Transform ownerTransform;

    public bool placeAtEnemy = false;

    [Header("Arc Projectile Feature")]
    public bool useArcProjectile = false;

    public float projectileHeight = 3f;

    public float projectileDuration = 0.6f;

    public float projectileScale = 0.3f;

    protected override void Activate()
    {
        if (abilityPrefab == null) return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject closest = null;
        float minDist = range;

        foreach (GameObject e in enemies)
        {
            float d = Vector3.Distance(ownerTransform.position, e.transform.position);

            if (d < minDist)
            {
                minDist = d;
                closest = e;
            }
        }

        if (closest == null) return;

        int spawnCount = count + (level - 1);

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 targetPos = placeAtEnemy
                ? closest.transform.position
                : ownerTransform.position;

            if (useArcProjectile)
            {
                SpawnArcProjectile(targetPos);
            }
            else
            {
                SpawnAbility(targetPos);
            }
        }
    }

    void SpawnAbility(Vector3 pos)
    {
        GameObject ability = Instantiate(
            abilityPrefab,
            pos,
            Quaternion.identity
        );

        var ab = ability.GetComponent<AbilityPosition>();

        if (ab != null)
            ab.SetOwner(ownerTransform);
    }

    void SpawnArcProjectile(Vector3 targetPos)
    {
        GameObject proj = new GameObject("AbilityProjectile");

        proj.transform.position = ownerTransform.position;

        GameObject mesh = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mesh.transform.SetParent(proj.transform);
        mesh.transform.localPosition = Vector3.zero;
        mesh.transform.localScale = Vector3.one * projectileScale;

        Destroy(mesh.GetComponent<Collider>());

        ArcProjectile mover = proj.AddComponent<ArcProjectile>();

        mover.Init(
            ownerTransform.position,
            targetPos,
            projectileHeight,
            projectileDuration,
            () =>
            {
                SpawnAbility(targetPos);
            }
        );
    }
}

public class ArcProjectile : MonoBehaviour
{
    Vector3 start;
    Vector3 target;

    float height;
    float duration;

    float timer;

    System.Action onReach;

    public void Init(Vector3 startPos, Vector3 targetPos, float arcHeight, float time, System.Action callback)
    {
        start = startPos;
        target = targetPos;
        height = arcHeight;
        duration = time;
        onReach = callback;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float t = timer / duration;

        if (t >= 1f)
        {
            transform.position = target;

            onReach?.Invoke();

            Destroy(gameObject);

            return;
        }

        Vector3 pos = Vector3.Lerp(start, target, t);

        pos.y += Mathf.Sin(t * Mathf.PI) * height;

        transform.position = pos;
    }
}