using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveHealthUI : MonoBehaviour {
    public Slider Slider;

    private void LateUpdate() {
        List<GameObject> enemies = SpawnManager.Instance.GetSpawnedEntities();

        int currentHealth = 0, totalHealth = 0;
        foreach (var enemy in enemies) {
            if (enemy.CompareTag("Enemy")) {
                if (enemy.activeSelf) {
                    currentHealth += enemy.GetComponent<Damageable>().Health;
                }
                totalHealth += enemy.GetComponent<Damageable>().GetMaxHealth();
            }
        }

        Slider.value = Mathf.Lerp(Slider.value, currentHealth, 0.1f);
        Slider.maxValue = totalHealth;
    }
}