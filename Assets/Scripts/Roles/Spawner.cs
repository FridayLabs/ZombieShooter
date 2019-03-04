using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float SpawnRadius = 1f;

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, SpawnRadius);
    }

    public GameObject[] SpawnMany(GameObject prefab, int enemiesCount) {
        GameObject[] list = new GameObject[enemiesCount];
        for (int i = 0; i < enemiesCount; i++) {
            list[i] = SpawnOne(prefab);
        }

        return list;
    }

    public Vector3 CalculateSpawnPoint() {
        Vector3 position = transform.position;
        Vector3 random = UnityEngine.Random.insideUnitSphere;
        random.y = position.y * SpawnRadius;
        position += random;
        return position;
    }

    public GameObject SpawnOne(GameObject prefab) {
        return ObjectPool.Instance.Spawn(prefab, CalculateSpawnPoint(), transform.rotation);
    }
}