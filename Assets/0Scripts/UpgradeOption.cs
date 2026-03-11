using UnityEngine;

namespace CrystalMind
{
    public enum UpgradeType
    {
        CharacterATK,
        Ability
    }

    [System.Serializable]
    public class UpgradeOption
    {
        public string characterName;

        public string displayName;

        public UpgradeType type;

        public GameObject owner;

        public Ability ability;

        public int level = 1;

        public int maxLevel = 4;

        public int currentValue;

        public int nextValue;

        public bool IsMax()
        {
            return level >= maxLevel;
        }

        public void SetupCharacter(GameObject character)
        {
            owner = character;

            characterName = character.name.Replace("(Clone)", "");

            displayName = "ATK";

            AutoShoot shoot = owner.GetComponent<AutoShoot>();

            if (shoot != null)
            {
                currentValue = shoot.attack;

                nextValue = shoot.attack + 2;
            }
        }

        public void SetupAbility(GameObject character, Ability ab)
        {
            owner = character;

            ability = ab;

            characterName = character.name.Replace("(Clone)", "");

            displayName = ab.name;

            level = ab.level;

            AutoAbility auto = ab.GetComponent<AutoAbility>();

            if (auto != null)
            {
                currentValue = auto.damage;
                nextValue = auto.damage + 10;
            }
        }

        public void Apply()
        {
            if (type == UpgradeType.CharacterATK)
            {
                AutoShoot shoot = owner.GetComponent<AutoShoot>();

                if (shoot != null)
                {
                    shoot.attack += 2;
                }

                level++;
            }

            if (ability != null)
            {
                AutoAbility auto = ability.GetComponent<AutoAbility>();

                if (auto != null)
                {
                    auto.LevelUp();

                    level = auto.level;
                }
            }
        }
    }
}