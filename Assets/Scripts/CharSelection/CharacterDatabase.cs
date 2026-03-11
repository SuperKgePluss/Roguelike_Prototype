using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class CharacterData
{
    public int id;
    public string characterName;
    public string description;
    public Sprite portrait;
    public int level;
    public string role;
    public bool isLocked = false;

    [System.Serializable]
    public class Stats
    {
        public List<Sprite> weapons = new List<Sprite>();
        public List<Sprite> abilities = new List<Sprite>();
        public List<Sprite> synergies = new List<Sprite>();
    }

    public Stats stats = new Stats();
}

[CreateAssetMenu(fileName = "CharacterDatabase", menuName = "ScriptableObject/CharacterDatabase")]
public class CharacterDatabase : ScriptableObject
{
    public List<CharacterData> characters = new List<CharacterData>();
}