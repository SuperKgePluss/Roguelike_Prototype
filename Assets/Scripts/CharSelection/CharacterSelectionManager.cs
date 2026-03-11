using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class CharacterSelectionManager : MonoBehaviour
{
    [SerializeField] private CharacterDatabase characterDatabase;
    [SerializeField] private Transform characterCardContainer;
    [SerializeField] private GameObject characterCardPrefab;

    // Left Panel References
    [SerializeField] private TextMeshProUGUI charNameText;
    [SerializeField] private TextMeshProUGUI charDescText;
    [SerializeField] private Image charPortrait;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Transform weaponsContainer;
    [SerializeField] private Transform abilitiesContainer;
    [SerializeField] private Transform synergiesContainer;
    [SerializeField] private GameObject statIconPrefab;

    private CharacterData selectedCharacter;
    private List<GameObject> cardInstances = new List<GameObject>();

    private void Start()
    {
        SelectCharacter(0);
    }
    private void ClearLeftPanel()
    {
        charNameText.text = "";
        charDescText.text = "";
        charPortrait.sprite = null;
        levelText.text = "";
    }
    private void InitializeUI()
    {
        foreach (Transform child in characterCardContainer)
        {
            Destroy(child.gameObject);
        }

        cardInstances.Clear();

        for (int i = 0; i < characterDatabase.characters.Count; i++)
        {
            GameObject cardObj = Instantiate(characterCardPrefab, characterCardContainer);
            CardUI cardUI = cardObj.GetComponent<CardUI>();

            if (cardUI != null)
            {
                int index = i;
                //cardUI.Setup(characterDatabase.characters[i], () => SelectCharacter(index));
                cardInstances.Add(cardObj);
            }
        }
    }

    public void SelectCharacter(int index)
    {
        selectedCharacter = characterDatabase.characters[index];

        charNameText.text = selectedCharacter.characterName;
        charDescText.text = selectedCharacter.description;
        charPortrait.sprite = selectedCharacter.portrait;
        levelText.text = selectedCharacter.level.ToString();

        UpdateStats();
    }
    private void UpdateStats()
    {
        ClearContainer(weaponsContainer);
        ClearContainer(abilitiesContainer);
        ClearContainer(synergiesContainer);

        // Weapons
        foreach (Sprite weapon in selectedCharacter.stats.weapons)
        {
            CreateStatIcon(weapon, weaponsContainer);
        }

        //// Abilities
        foreach (Sprite ability in selectedCharacter.stats.abilities)
        {
            CreateStatIcon(ability, abilitiesContainer);
        }

        //// Synergies
        foreach (Sprite synergy in selectedCharacter.stats.synergies)
        {
            CreateStatIcon(synergy, synergiesContainer);
        }
    }

    private void CreateStatIcon(Sprite sprite, Transform parent)
    {
        GameObject obj = Instantiate(statIconPrefab, parent);
        Image iconImage = obj.transform.Find("Icon").GetComponent<Image>();
        iconImage.sprite = sprite;
    }
    private void ClearContainer(Transform container)
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
    }

    public void StartMission()
    {
        if (selectedCharacter != null && !selectedCharacter.isLocked)
        {
            Debug.Log("Starting mission with " + selectedCharacter.characterName);
        }
    }

    public CharacterData GetSelectedCharacter()
    {
        return selectedCharacter;
    }
}