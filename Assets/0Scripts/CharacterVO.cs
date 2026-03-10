using UnityEngine;

public class CharacterVO : MonoBehaviour
{
    public AudioClip spawnVO;
    AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlaySpawn();
    }

    public void PlaySpawn()
    {
        if (spawnVO == null) return;

        source.PlayOneShot(spawnVO);
    }
}