using CrystalMind;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private Animator characterAnimator;

    void Update()
    {
        if (GameManager.instance.isGameOver) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        transform.position += move * moveSpeed * Time.deltaTime;

        float movePercent = Mathf.Clamp01(move.magnitude);

        if (characterAnimator != null)
        {
            characterAnimator.SetFloat("speed", movePercent);
        }
    }
}