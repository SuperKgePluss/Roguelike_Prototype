using UnityEngine;

public class AbilityPosition : MonoBehaviour
{
    Transform owner;

    public bool followOwner = false;

    public void SetOwner(Transform t)
    {
        owner = t;
    }

    private void Update()
    {
        if (owner == null) return;

        if (followOwner)
        {
            transform.position = owner.position;

            //transform.position =
            //owner.position + owner.forward * 1.2f;

            transform.rotation = owner.rotation;
        }
    }
}
