using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombieWalker : MonoBehaviour {
    private GameObject player;
    private NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        Vector3 playerPosition = getPlayerPosition();
        agent.SetDestination(playerPosition);
    }

    private Vector3 getPlayerPosition() {
        return ensurePlayer().transform.position;
    }

    private GameObject ensurePlayer() {
        if (player == null) {
            player = GameManager.Instance.Player;
        }

        return player;
    }
}