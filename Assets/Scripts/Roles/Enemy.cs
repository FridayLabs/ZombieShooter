using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int Damage = 10;
    public float detectionRadius = 10f;

    private float nextAttackTime;
    public float AttackCooldown = 1f;

    private void Start() {
        nextAttackTime = Time.time;
    }

    private void Update() {
        if (CheckIfPlayerInRange() && nextAttackTime <= Time.time) {
            GameManager.Instance.Player.GetComponent<Damageable>().TakeDamage(Damage);
            nextAttackTime = Time.time + AttackCooldown;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    private bool CheckIfPlayerInRange() {
        Collider[] cols = Physics.OverlapSphere(transform.position, detectionRadius, LayerMask.GetMask("Player"));
        return cols.Length > 0;
    }
}