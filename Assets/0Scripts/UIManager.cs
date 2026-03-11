using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace CrystalMind
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager _instance;

        [Header("GameState")]
        public GameObject GameOverPanel;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI timeText;
        public TextMeshProUGUI waveText;
        public GameObject bossIncoming;

        [Header("Player UI")]
        public TextMeshProUGUI hpText;
        public TextMeshProUGUI levelText;
        public TextMeshProUGUI expText;

        [Header("Upgrade UI")]
        public GameObject upgradePanel;

        public UpgradeButtonUI[] upgradeButtons;

        void Awake()
        {
            _instance = this;

            if (upgradePanel != null)
                upgradePanel.SetActive(false);
        }

        private void Update()
        {
            if (timeText != null)
            {
                int totalSeconds = (int)Time.time;

                int minutes = totalSeconds / 60;
                int seconds = totalSeconds % 60;

                timeText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
            }
        }

        // -------------------------
        // HP
        // -------------------------

        public void UpdateHP(float current, float max)
        {
            if (hpText != null)
            {
                hpText.text = "HP : " + current + " / " + max;
            }
        }

        // -------------------------
        // EXP
        // -------------------------

        public void UpdateEXP(int exp)
        {
            if (expText != null)
            {
                expText.text = "EXP : " + exp;
            }
        }

        // -------------------------
        // LEVEL
        // -------------------------

        public void UpdateLV(int level)
        {
            if (levelText != null)
            {
                levelText.text = "LV : " + level;
            }
        }

        // -------------------------
        // UPGRADE UI
        // -------------------------

        public void ShowUpgradeUI(List<UpgradeOption> choices)
        {
            if (upgradePanel == null)
                return;

            upgradePanel.SetActive(true);

            for (int i = 0; i < upgradeButtons.Length; i++)
            {
                if (i < choices.Count)
                {
                    upgradeButtons[i].gameObject.SetActive(true);

                    upgradeButtons[i].Setup(choices[i], i);
                }
                else
                {
                    upgradeButtons[i].gameObject.SetActive(false);
                }
            }
        }

        public void UpdateScore(int score)
        {
            scoreText.text = "SCORE: " + score;
        }

        public void UpdateWave(int wave)
        {
            waveText.text = "WAVE: " + wave;
        }

        public void ShowBossWarning(bool isEnable)
        {
            bossIncoming.SetActive(isEnable);
        }

        public void HideUpgradeUI()
        {
            if (upgradePanel != null)
                upgradePanel.SetActive(false);
        }

        public void ShowGameOver()
        {
            GameOverPanel.SetActive(true);
        }
    }
}