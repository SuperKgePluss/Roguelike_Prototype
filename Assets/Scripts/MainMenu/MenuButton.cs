using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Image highlightBar;

    private Color normalColor = Color.white;
    private Color hoverColor = new Color(1f, 0.3f, 0.1f);

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = hoverColor;
        highlightBar.gameObject.SetActive(true);
        transform.localScale = new Vector3(1.05f, 1f, 1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = normalColor;
        highlightBar.gameObject.SetActive(false);
        transform.localScale = Vector3.one;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked " + gameObject.name);
    }
}