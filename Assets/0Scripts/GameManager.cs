using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CrystalMind
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public int score = 0;

        public List<AutoAbility> allAbilities = new List<AutoAbility>();

        public bool isGameOver = false;

        void Awake()
        {
            instance = this;
        }

        public void AddScore(int value)
        {
            score += value;

            UIManager._instance.UpdateScore(score);
        }

        public void GameOver()
        {
            UIManager._instance.ShowGameOver();

            SaveManager save = FindObjectOfType<SaveManager>();

            int best = save.LoadScore();

            if (score > best)
            {
                save.SaveScore(score);
            }

            StartCoroutine(DelayToMenu());
        }

        IEnumerator DelayToMenu()
        {
            isGameOver = true;
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("MainMenu");
        }
    }
}