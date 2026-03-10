using UnityEngine;

public class MagnetOrb : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ExpOrb[] orbs = FindObjectsOfType<ExpOrb>();

            foreach (ExpOrb orb in orbs)
            {
                orb.magnetized = true;
            }

            Destroy(gameObject);
        }
    }
}