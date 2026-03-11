using UnityEngine;
using System.Collections.Generic;

namespace CrystalMind
{
    public class SquadManager : MonoBehaviour
    {
        public GameObject[] squadPrefabs;

        public Transform leader;
        public List<GameObject> availableSquads;

        void Start()
        {
            availableSquads = new List<GameObject>(squadPrefabs);
        }

        public void SpawnMember(Vector3 offset)
        {
            if (availableSquads.Count == 0) return;

            GameObject prefab =
                availableSquads[Random.Range(0, availableSquads.Count)];

            GameObject member = Instantiate(
                prefab,
                leader.position + offset,
                Quaternion.identity
            );

            availableSquads.Remove(prefab);

            member.tag = "Ally";

            SquadFollower follower = member.GetComponent<SquadFollower>();
            follower.leader = leader;
            follower.offset = offset;

            var leaderHP = leader.GetComponent<PlayerHealth>();
            var newFollowerHP = follower.GetComponent<PlayerHealth>();

            leaderHP.maxHealth += 400;
            leaderHP.Heal(400);

            member.GetComponent<PlayerMovement>().enabled = false;
            member.GetComponent<PlayerLevel>().enabled = false;
            member.GetComponent<CharacterLoader>().enabled = false;
        }

        public void RemoveLeader(GameObject leaderPrefab)
        {
            availableSquads.Remove(leaderPrefab);
        }
    }
}