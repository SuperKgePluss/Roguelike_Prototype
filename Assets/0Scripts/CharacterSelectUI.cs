using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectUI : MonoBehaviour
{
    public GameObject swat;
    public GameObject tank;
    public GameObject engineer;
    public GameObject hunter;

    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        SaveManager save = FindObjectOfType<SaveManager>();

        int bestScore = save.LoadScore();
        highScoreText.text = "Best score : " + bestScore.ToString();
    }

    public void SelectSWAT()
    {
        CharacterManager.instance.SelectCharacter(swat);
        StartGame();
    }

    public void SelectTANK()
    {
        CharacterManager.instance.SelectCharacter(tank);
        StartGame();
    }

    public void SelectENG()
    {
        CharacterManager.instance.SelectCharacter(engineer);
        StartGame();
    }

    public void SelectHUNTER()
    {
        CharacterManager.instance.SelectCharacter(hunter);
        StartGame();
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame() {
        Application.Quit(); 
    }
}