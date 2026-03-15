using UnityEngine;
using System.Collections;

namespace CrystalMind
{
    public class SpawnIntro : MonoBehaviour
    {
        [Header("Intro Motion")]
        public float bounceHeight = 0.6f;
        public float duration = 0.25f;

        [Header("Scale")]
        public float startScale = 0.8f;
        public float endScale = 1f;

        [Header("Collider")]
        public Collider targetCollider;

        Vector3 startPos;

        void Awake()
        {
            startPos = transform.position;

            if (targetCollider != null)
                targetCollider.enabled = false;
        }

        void Start()
        {
            StartCoroutine(IntroRoutine());
        }

        IEnumerator IntroRoutine()
        {
            float t = 0f;

            while (t < duration)
            {
                t += Time.deltaTime;

                float progress = t / duration;

                // bounce motion
                float yOffset = Mathf.Sin(progress * Mathf.PI) * bounceHeight;
                transform.position = startPos + Vector3.up * yOffset;

                // smooth scale
                float scale = Mathf.Lerp(startScale, endScale, Mathf.SmoothStep(0, 1, progress));
                transform.localScale = Vector3.one * scale;

                yield return null;
            }

            transform.position = startPos;
            transform.localScale = Vector3.one * endScale;

            if (targetCollider != null)
                targetCollider.enabled = true;
        }
    }
}