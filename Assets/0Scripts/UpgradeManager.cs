using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ApplyUpgrade(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ApplyUpgrade(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ApplyUpgrade(3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ApplyUpgrade(4);
            }
        }
    }

    public void ShowUpgrade()
    {
        Time.timeScale = 0f;

        UIManager._instance.ShowUpgradeUI();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    void ApplyUpgrade(int id)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (id == 1)
        {
            player.GetComponent<AutoShoot>().fireRate -= 0.1f;
        }

        if (id == 2)
        {
            player.GetComponent<PlayerMovement>().moveSpeed += 1f;
        }

        if (id == 3)
        {
            player.GetComponent<PlayerHealth>().maxHealth += 1;
        }

        if (id == 4)
        {
            AbilityController[] controllers = FindObjectsOfType<AbilityController>();

            foreach (var ac in controllers)
            {
                foreach (var ability in ac.abilities)
                {
                    ability.LevelUp();
                }
            }
        }

        UIManager._instance.HideUpgradeUI();
        ResumeGame();
    }
}