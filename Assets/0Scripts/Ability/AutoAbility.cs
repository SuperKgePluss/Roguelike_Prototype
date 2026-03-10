using UnityEngine;

public class AutoAbility : Ability
{
    public GameObject abilityPrefab;

    public float range = 8f;

    public int count = 1;

    protected override void Activate()
    {
        if (abilityPrefab == null) return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject closest = null;
        float minDist = range;

        foreach (GameObject e in enemies)
        {
            float d = Vector3.Distance(transform.position, e.transform.position);

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
            GameObject ability = Instantiate(
                abilityPrefab,
                transform.position,
                Quaternion.identity
            );

            ability.SendMessage(
                "SetOwner",
                transform,
                SendMessageOptions.DontRequireReceiver
            );
        }
    }
}