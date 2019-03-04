using UnityEngine;

public class PlayerInitPortal : MonoBehaviour {
    public Spawner spawnPoint;
    private bool playerInPortal;

    public void TeleportPlayer(Transform playerTransform) {
        if (playerInPortal) {
            playerTransform.position = spawnPoint.CalculateSpawnPoint();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            playerInPortal = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            playerInPortal = false;
        }
    }
}