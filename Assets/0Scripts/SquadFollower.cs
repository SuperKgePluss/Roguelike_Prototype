using UnityEngine;

public class SquadFollower : MonoBehaviour
{
    public Transform leader;
    public Vector3 offset;
    public float followSpeed = 5f;

    void Update()
    {
        if (leader == null) return;

        Vector3 targetPos = leader.position + offset;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            followSpeed * Time.deltaTime
        );
    }
}