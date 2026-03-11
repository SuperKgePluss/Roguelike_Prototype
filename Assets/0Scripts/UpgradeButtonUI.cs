using TMPro;
using UnityEngine;

namespace CrystalMind
{
    public class UpgradeButtonUI : MonoBehaviour
    {
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI levelText;
        public TextMeshProUGUI valueText;

        int index;

        public void Setup(UpgradeOption option, int i)
        {
            index = i;

            string abilityName = option.displayName.Replace("(Clone)", "");

            titleText.text =
                option.characterName + " - " + abilityName;

            string nextLevel =
                option.level + 1 >= option.maxLevel ? "MAX" : (option.level + 1).ToString();

            levelText.text =
                "Skill Level " + option.level + " → " + nextLevel;

            valueText.text =
                option.currentValue + " → " + option.nextValue;
        }

        public void OnClick()
        {
            UpgradeManager.instance.SelectUpgrade(index);
        }
    }
}