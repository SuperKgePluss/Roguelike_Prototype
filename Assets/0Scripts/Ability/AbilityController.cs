using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public Ability[] abilities;

    void Update()
    {
        foreach (var ability in abilities)
        {
            ability.Tick();
        }
    }
}