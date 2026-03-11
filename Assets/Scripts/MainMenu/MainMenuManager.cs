using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private WelcomePopup welcomePopup;
    [SerializeField] private GameObject optionsPanel;

    // START
    public void OnStartGame()
    {
        SceneManager.LoadScene("CharSelection");
    }

    // UPGRADE
    public void OnUpgrades()
    {
        SceneManager.LoadScene("UpgradesScene");
    }

    // ACHIEVEMENTS
    public void OnAchievements()
    {
        SceneManager.LoadScene("AchievementsScene");
        // ถ้ายังไม่มี Scene ใช้ Debug แทนก่อน
        // Debug.Log("Achievements Clicked");
    }

    // FOLLOW UP
    public void OnFollowUp()
    {
        Application.OpenURL("https://youtu.be/6Kkg4fda2zc?si=L3AzmlT0CxU6lnYv");
        // เช่น Discord / Facebook / Steam Page
    }

    // OPTIONS
    public void OnOptions()
    {
        optionsPanel.SetActive(true);
    }

    // QUIT
    public void OnQuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}