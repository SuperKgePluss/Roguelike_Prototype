using UnityEngine;
using UnityEngine.UI;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private RawImage backgroundImage;
    [SerializeField] private float parallaxSpeed = 0.005f;

    void Update()
    {
        backgroundImage.uvRect = new Rect(
            backgroundImage.uvRect.x + parallaxSpeed * Time.deltaTime,
            backgroundImage.uvRect.y,
            backgroundImage.uvRect.width,
            backgroundImage.uvRect.height
        );
    }
}