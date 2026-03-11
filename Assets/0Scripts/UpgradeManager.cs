using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace CrystalMind
{
    public class UpgradeManager : MonoBehaviour
    {
        public static UpgradeManager instance;

        public List<UpgradeOption> upgradePool = new List<UpgradeOption>();

        public List<UpgradeOption> currentChoices = new List<UpgradeOption>();

        void Awake()
        {
            instance = this;
        }

        public void ShowUpgrade()
        {
            BuildPool();

            List<UpgradeOption> available =
                upgradePool.Where(x => !x.IsMax()).ToList();

            if (available.Count == 0)
                return;

            if (available.Count <= 4)
            {
                currentChoices = available;
            }
            else
            {
                currentChoices =
                    available.OrderBy(x => Random.value).Take(4).ToList();
            }

            Time.timeScale = 0f;

            UIManager._instance.ShowUpgradeUI(currentChoices);
        }

        void BuildPool()
        {
            List<UpgradeOption> previous = new List<UpgradeOption>(upgradePool);

            upgradePool.Clear();

            GameObject leader = GameObject.FindGameObjectWithTag("Player");

            List<GameObject> characters = new List<GameObject>();

            characters.Add(leader);

            GameObject[] allies = GameObject.FindGameObjectsWithTag("Ally");

            characters.AddRange(allies);

            foreach (GameObject c in characters)
            {
                // ATK upgrade
                UpgradeOption atk = new UpgradeOption();

                atk.type = UpgradeType.CharacterATK;

                atk.SetupCharacter(c);

                RestoreLevel(atk, previous);

                upgradePool.Add(atk);

                AbilityController ac = c.GetComponent<AbilityController>();

                if (ac != null)
                {
                    foreach (AutoAbility a in ac.runtimeAbilities)
                    {
                        UpgradeOption ab = new UpgradeOption();

                        ab.type = UpgradeType.Ability;

                        ab.SetupAbility(c, a);

                        RestoreLevel(ab, previous);

                        upgradePool.Add(ab);
                    }
                }
            }
        }

        void RestoreLevel(UpgradeOption option, List<UpgradeOption> previous)
        {
            UpgradeOption old =
                previous.FirstOrDefault(x =>
                    x.characterName == option.characterName &&
                    x.displayName == option.displayName);

            if (old != null)
            {
                option.level = old.level;
            }
        }

        public void SelectUpgrade(int index)
        {
            if (index >= currentChoices.Count)
                return;

            currentChoices[index].Apply();

            UIManager._instance.HideUpgradeUI();

            Time.timeScale = 1f;
        }
    }
}