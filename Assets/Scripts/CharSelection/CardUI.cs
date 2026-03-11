using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image portraitImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI roleText;
    [SerializeField] private Image lockIcon;
    [SerializeField] private Button selectButton;
    [SerializeField] private Image borderImage;

    //private CharacterData characterData;
    private bool isSelected = false;
    private Color selectedColor = new Color(0.8f, 0.7f, 0.3f, 1f); // Gold #D4AF37
    private Color defaultColor = new Color(0.4f, 0.4f, 0.4f, 1f); // Gray
    private Color hoverColor = new Color(0.6f, 0.55f, 0.25f, 1f); // Hover Gold

    private Outline outlineComponent;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        outlineComponent = GetComponent<Outline>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }



    //public void Setup(CharacterData data, System.Action onSelected)
    //{
    //    portraitImage.sprite = data.portrait;
    //    nameText.text = data.characterName;
    //    roleText.text = data.role;

    //    selectButton.onClick.RemoveAllListeners();
    //    selectButton.onClick.AddListener(() => onSelected?.Invoke());
    //}

    //public void OnCardClicked()
    //{
    //    if (characterData != null && !characterData.isLocked)
    //    {
    //        Debug.Log($"Selected: {characterData.characterName}");
    //        // Play sound effect here if needed
    //    }
    //}

    public void SetSelected(bool selected)
    {
        isSelected = selected;

        if (borderImage != null)
        {
            borderImage.color = selected ? selectedColor : defaultColor;
        }

        if (outlineComponent != null)
        {
            outlineComponent.enabled = selected;

            if (selected)
            {
                outlineComponent.effectColor = new Color(0.8f, 0.7f, 0.3f, 1f); // สีทอง
                outlineComponent.effectDistance = new Vector2(4f, 4f); // ความหนา
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isSelected && borderImage != null)
        {
            borderImage.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected && borderImage != null)
        {
            borderImage.color = defaultColor;
        }
    }
}