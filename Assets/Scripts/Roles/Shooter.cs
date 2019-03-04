using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
public class Shooter : MonoBehaviour {
    public Transform BulletStart;
    public Weapon Weapon;

    public UnityEvent OnShoot;

    private PlayerInput input;

    private Coroutine shootingProcess;

    void Start() {
        input = GetComponent<PlayerInput>();
    }

    void Update() {
        if (input.Shooting && shootingProcess == null) {
            startShooting();
        } else if (!input.Shooting && shootingProcess != null) {
            stopShooting();
        }
    }

    void startShooting() {
        shootingProcess = StartCoroutine(shoot());
    }

    void stopShooting() {
        StopCoroutine(shootingProcess);
        shootingProcess = null;
    }

    IEnumerator shoot() {
        while (true) {
            OnShoot.Invoke();
            yield return Weapon.shoot(BulletStart);
        }
    }
}