using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI eXPText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public GameObject gameOverText;

    public GameObject upgradePanel;

    public GameObject bossWarningImage;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        gameOverText.SetActive(false);
    }

    public void UpdateHP(int hp)
    {
        hpText.text = $"HP : {hp}";
    }

    public void UpdateEXP(int exp)
    {
        eXPText.text = $"EXP : {exp}";
    }

    public void UpdateLV(int level)
    {
        levelText.text = $"LV : {level}";
    }

    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score : " + score;
    }

    public void UpdateWave(int wave)
    {
        waveText.text = $"Wave : {wave}";
    }

    public void ShowWaveComplete(int wave)
    {
        StartCoroutine(WaveCompleteRoutine(wave));
    }

    public void ShowBossWarning(bool show)
    {
        bossWarningImage.SetActive(show);
    }

    IEnumerator WaveCompleteRoutine(int wave)
    {
        waveText.text = $"Wave {wave} Complete!";

        yield return new WaitForSeconds(2f);

        waveText.text = $"Wave : {wave + 1}";
    }

    public void ShowUpgradeUI()
    {
        upgradePanel.SetActive(true);
    }

    public void HideUpgradeUI()
    {
        upgradePanel.SetActive(false);
    }
}