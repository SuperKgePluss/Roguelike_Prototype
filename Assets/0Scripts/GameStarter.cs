using System.Collections;
using UnityEngine;

namespace CrystalMind
{
    public class GameStarter : MonoBehaviour
    {
        GameObject teamLeader;

        void Start()
        {
            teamLeader = Instantiate(
                CharacterManager.instance.selectedCharacterPrefab,
                Vector3.zero,
                Quaternion.identity
            );

            FindObjectOfType<CameraFollow>().player = teamLeader.transform;

            StartCoroutine(DelayDeleteLeader());
        }
        IEnumerator DelayDeleteLeader()
        {
            var squadManager = FindObjectOfType<SquadManager>();

            yield return new WaitUntil(() => squadManager.availableSquads.Count > 0);
            squadManager.leader = teamLeader.transform;
            squadManager.RemoveLeader(
                CharacterManager.instance.selectedCharacterPrefab
            );
        }
    }
}