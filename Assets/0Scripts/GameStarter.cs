using UnityEngine;

public class GameStarter : MonoBehaviour
{
    void Start()
    {
        var teamLeader = Instantiate(
            CharacterManager.instance.selectedCharacterPrefab,
            Vector3.zero,
            Quaternion.identity
        );

        var squadManager = FindObjectOfType<SquadManager>();

        squadManager.leader = teamLeader.transform;
        squadManager.RemoveLeader(
            CharacterManager.instance.selectedCharacterPrefab
        );

        FindObjectOfType<CameraFollow>().player = teamLeader.transform;
    }
}