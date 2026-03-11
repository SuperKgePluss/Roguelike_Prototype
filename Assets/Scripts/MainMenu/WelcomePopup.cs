using UnityEngine;
using System.Collections;

public class WelcomePopup : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform popupRect;

    [SerializeField] private float animationDuration = 0.35f;
    [SerializeField] private float overshootScale = 1.1f;

    void Start()
    {
        ShowPopup();
    }

    public void ShowPopup()
    {
        gameObject.SetActive(true);
        popupRect.localScale = Vector3.zero;
        canvasGroup.alpha = 1f;

        StartCoroutine(ScaleBounce());
    }

    IEnumerator ScaleBounce()
    {
        float time = 0f;

        // Phase 1: ขยายเกินเล็กน้อย
        while (time < animationDuration)
        {
            time += Time.deltaTime;
            float t = time / animationDuration;
            float scale = Mathf.Lerp(0f, overshootScale, EaseOutBack(t));
            popupRect.localScale = Vector3.one * scale;
            yield return null;
        }

        // Phase 2: เด้งกลับ 1.0
        time = 0f;
        while (time < 0.1f)
        {
            time += Time.deltaTime;
            float t = time / 0.1f;
            float scale = Mathf.Lerp(overshootScale, 1f, t);
            popupRect.localScale = Vector3.one * scale;
            yield return null;
        }

        popupRect.localScale = Vector3.one;
    }

    float EaseOutBack(float x)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1f;

        return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}