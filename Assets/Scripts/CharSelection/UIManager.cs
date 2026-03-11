using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CharacterSelectionManager selectionManager;
    [SerializeField] private GameObject runHistoryPanel;

    private void Start()
    {
        if (selectionManager == null)
        {
            selectionManager = GetComponent<CharacterSelectionManager>();
        }
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnContinuePressed();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnRunHistoryPressed();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackPressed();
        }
    }

    public void OnContinuePressed()
    {
        Debug.Log("Continue/Start Mission");

        if (selectionManager != null)
        {
            //CharacterData selected = selectionManager.GetSelectedCharacter();
            //if (selected != null && !selected.isLocked)
            //{
                //selectionManager.StartMission();
                // Uncomment below to load game scene
                // SceneManager.LoadScene("GameplayScene");
            //}
        }
    }

    public void OnRunHistoryPressed()
    {
        Debug.Log("Opening Run History");

        if (runHistoryPanel != null)
        {
            runHistoryPanel.SetActive(!runHistoryPanel.activeSelf);
        }
    }

    public void OnBackPressed()
    {
        Debug.Log("Going back to main menu");
        // Uncomment below to load main menu
        // SceneManager.LoadScene("MainMenu");
    }
}