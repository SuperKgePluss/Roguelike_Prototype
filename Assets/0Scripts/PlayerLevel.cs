using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;

    public int currentExp = 0;
    public int expToNext = 10;

    public void AddExp(int amount)
    {
        currentExp += amount;
        UpdateEXP(currentExp);

        if (currentExp >= expToNext)
        {
            LevelUp();

            if (level == 2)
            {
                FindObjectOfType<SquadManager>().SpawnMember(new Vector3(2, 0, 0));
            }

            if (level == 4)
            {
                FindObjectOfType<SquadManager>().SpawnMember(new Vector3(-2, 0, 0));
            }

            if (level == 6)
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