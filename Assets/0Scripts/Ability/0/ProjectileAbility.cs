using UnityEngine;

public class ProjectileAbility : MonoBehaviour
{
    public float speed = 15f;
    public int damage = 5;

    Transform owner;

    public void SetOwner(Transform t)
    {
        owner = t;

        transform.position =
            owner.position + owner.forward * 1.2f;

        transform.rotation = owner.rotation;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}