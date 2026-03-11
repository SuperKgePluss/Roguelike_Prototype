using UnityEngine;

namespace CrystalMind
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Game/Character")]
    public class CharacterData : ScriptableObject
    {
        public string characterName;

        public float moveSpeed;

        public int maxHP;

        public float fireRate;

        public Color characterColor;
    }
}