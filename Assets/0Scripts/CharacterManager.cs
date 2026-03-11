using UnityEngine;

namespace CrystalMind
{
    public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager instance;

        public CharacterData selectedCharacter;
        public GameObject selectedCharacterPrefab;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SelectCharacter(GameObject prefab)
        {
            selectedCharacterPrefab = prefab;
        }
    }
}