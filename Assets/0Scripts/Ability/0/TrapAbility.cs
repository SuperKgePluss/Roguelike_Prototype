using UnityEngine;

public class TrapAbility : MonoBehaviour
{
    public int damage = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}