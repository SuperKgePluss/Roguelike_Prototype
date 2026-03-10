using UnityEngine;

public class AOEAbility : MonoBehaviour
{
    public float radius = 5f;
    public int damage = 5;

    void Start()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            radius
        );

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.GetComponent<Enemy>().TakeDamage(damage);
            }
        }

        Destroy(gameObject, 0.2f);
    }
}