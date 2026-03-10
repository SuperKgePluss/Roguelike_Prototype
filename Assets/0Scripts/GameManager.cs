using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int value)
    {
        score += value;

        UIManager._instance.UpdateScore(score);
    }

    public void GameOver() {
        UIManager._instance.ShowGameOver();

        SaveManager save = FindObjectOfType<SaveManager>();

        int best = save.LoadScore();

        if (score > best)
        {
            save.SaveScore(score);
        }
    }
}