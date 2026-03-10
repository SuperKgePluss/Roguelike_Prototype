using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    public int expValue = 1;
    public bool magnetized = false;

    void Update()
    {
        if (magnetized)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;

            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                10f * Time.deltaTime
            );
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLevel pl = other.GetComponent<PlayerLevel>();

            if (pl != null)
            {
                pl.AddExp(expValue);
            }

            Destroy(gameObject);
        }
    }
}