using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject PlayerPrefab;

    public static SpawnManager Instance;
    public GameObject SmallEnemyPrefab;
    public GameObject MediumEnemyPrefab;
    public GameObject LargeEnemyPrefab;

    public Spawner PlayerSpawnPoint;
    public Spawner[] EnemySpawnPoints;

    private List<GameObject> spawnedEntities = new List<GameObject>();

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }

    public GameObject SpawnPlayer() {
        GameObject player = PlayerSpawnPoint.SpawnOne(PlayerPrefab);
        spawnedEntities.Add(player);
        player.GetComponent<Dieable>().OnDie.AddListener(delegate { GameManager.Instance.OnPlayerDie(); });
        return player;
    }

    public void SpawnEnemies(WaveDescription description) {
        foreach (Spawner point in EnemySpawnPoints) {
            spawnedEntities.AddRange(point.SpawnMany(SmallEnemyPrefab, description.SmallEnemiesCount));
            spawnedEntities.AddRange(point.SpawnMany(MediumEnemyPrefab, description.MediumEnemiesCount));
            spawnedEntities.AddRange(point.SpawnMany(LargeEnemyPrefab, description.LargeEnemiesCount));
        }
    }

    public void DespawnAll() {
        foreach (var entity in spawnedEntities) {
            ObjectPool.Instance.Despawn(entity);
        }
    }

    public List<GameObject> GetSpawnedEntities() {
        return spawnedEntities;
    }
}