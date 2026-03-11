using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public Ability[] abilities;

    public Ability[] runtimeAbilities;

    void Start()
    {
        runtimeAbilities = new Ability[abilities.Length];

        for (int i = 0; i < abilities.Length; i++)
        {
            Ability instance = Instantiate(abilities[i], transform);

            runtimeAbilities[i] = instance;

            AutoAbility auto = instance as AutoAbility;

            if (auto != null)
            {
                auto.ownerTransform = transform;
            }
        }
    }

    void Update()
    {
        foreach (var ability in runtimeAbilities)
        {
            ability.Tick();
        }
    }
}