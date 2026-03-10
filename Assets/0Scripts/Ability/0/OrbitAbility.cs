using UnityEngine;

public class OrbitAbility : MonoBehaviour
{
    Transform owner;

    public float radius = 2f;
    public float speed = 180f;

    float angle;

    public void SetOwner(Transform t)
    {
        owner = t;
    }

    void Update()
    {
        if (owner == null) return;

        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        transform.position =
            owner.position + new Vector3(x, 0, z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(1);
        }
    }
}