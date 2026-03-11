using UnityEngine;

namespace CrystalMind
{
    public class CharacterLoader : MonoBehaviour
    {
        void Start()
        {
            CharacterData data = CharacterManager.instance.selectedCharacter;

            if (data == null) return;

            GetComponent<PlayerMovement>().moveSpeed = data.moveSpeed;
            GetComponent<PlayerHealth>().maxHealth = data.maxHP;
            GetComponent<AutoShoot>().fireRate = data.fireRate;

            GetComponent<Renderer>().material.color = data.characterColor;
        }
    }
}