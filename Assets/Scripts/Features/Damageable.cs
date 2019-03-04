using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour {
    public UnityEvent OnTakeDamage;
    public int Health = 100;
    private int maxHealth;

    private void OnEnable() {
        maxHealth = Health;
    }

    private void OnDisable() {
        Health = maxHealth;
    }

    public void TakeDamage(int amountOfDamage) {
        Health -= amountOfDamage;
        if (Health > 0) {
            OnTakeDamage.Invoke();
        } else {
            Dieable dieable = GetComponent<Dieable>();
            if (dieable) {
                dieable.Die();
            }
        }
    }

    public float GetHealthPercentage() {
        return (float) Health / maxHealth;
    }

    public int GetMaxHealth() {
        return maxHealth;
    }
}