using UnityEngine;

namespace CrystalMind
{
    public class PlayerLevel : MonoBehaviour
    {
        public int level = 1;

        public int currentExp = 0;

        public int expToNext = 10;

        [Header("Follower")]
        public int SquadSpawnLevel2nd = 3;
        public int SquadSpawnLevel3rd = 5;
        public int SquadSpawnLevel4th = 7;

        public void AddExp(int amount)
        {
            currentExp += amount;

            UpdateEXP(currentExp);

            if (currentExp >= expToNext)
            {
                LevelUp();

                if (level == SquadSpawnLevel2nd)
                {
                    FindObjectOfType<SquadManager>().SpawnMember(new Vector3(2, 0, 0));
                }

                if (level == SquadSpawnLevel3rd)
                {
                    FindObjectOfType<SquadManager>().SpawnMember(new Vector3(-2, 0, 0));
                }

                if (level == SquadSpawnLevel4th)
                {
                    FindObjectOfType<SquadManager>().SpawnMember(new Vector3(0, 0, 2));
                }
            }
        }

        void LevelUp()
        {
            level++;

            UIManager._instance.UpdateLV(level);

            currentExp = 0;

            UpdateEXP(currentExp);

            expToNext += 5;

            Debug.Log("LEVEL UP : " + level);

            UpgradeManager.instance.ShowUpgrade();
        }

        void UpdateEXP(int currentEXP)
        {
            UIManager._instance.UpdateEXP(currentEXP);
        }
    }
}