using System;
using System.Collections;
using UnityEngine;

[Serializable]
public struct WaveDescription {
    public int SmallEnemiesCount;
    public int MediumEnemiesCount;
    public int LargeEnemiesCount;
}

[RequireComponent(typeof(SpawnManager))]
[RequireComponent(typeof(GatesManager))]
public class GameManager : MonoBehaviour {
    public int CurrentWave;
    public bool IsPrepearingStage = true;
    public static GameManager Instance;
    [HideInInspector] public GameObject Player;

    public WaveDescription[] Waves;
    public GameObject DamageUI;
    public GameObject WavesUI;
    public EndGameUI EndGameUI;
    public PlayerInitPortal[] PlayerPortals;

    private GatesManager gatesManager;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        gatesManager = GetComponent<GatesManager>();
    }

    public void StartGame() {
        WavesUI.SetActive(true);
        DamageUI.SetActive(true);
        StartCoroutine(processThroughWaves());
    }

    public int GetCurrentWaveNumber() {
        return CurrentWave + 1;
    }

    public void OnPlayerDie() {
        endDame(false);
    }

    IEnumerator processThroughWaves() {
        IsPrepearingStage = true;
        if (Player == null) {
            Player = SpawnManager.Instance.SpawnPlayer();
        }
        for (int i = 0; i < Waves.Length; i++) {
            CurrentWave = i;
            yield return new WaitForSeconds(2f);
            IsPrepearingStage = false;

            SpawnManager.Instance.SpawnEnemies(Waves[i]);
            yield return new WaitForSeconds(1f);
            gatesManager.OpenGates();
            while (hasAliveEnemies()) {
                yield return new WaitForSeconds(0.5f);
            }

            gatesManager.CloseGates();
            IsPrepearingStage = true;
            foreach (var portal in PlayerPortals) {
                portal.TeleportPlayer(Player.transform);    
            }
        }
        endDame(true);
    }

    private bool hasAliveEnemies() {
        foreach (var enemy in SpawnManager.Instance.GetSpawnedEntities()) {
            if (enemy.activeSelf && enemy.CompareTag("Enemy")) {
                return true;
            }
        }

        return false;
    }

    private void endDame(bool isWin) {
        StopAllCoroutines();
        SpawnManager.Instance.DespawnAll();
        WavesUI.SetActive(false);
        DamageUI.SetActive(false);
        EndGameUI.SetWin(isWin);
        EndGameUI.gameObject.SetActive(true);
        Player = null;
    }
}