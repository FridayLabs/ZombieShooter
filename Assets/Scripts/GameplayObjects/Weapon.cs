using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Weapon", fileName = "Weapon")]
public class Weapon : ScriptableObject {
    public float ProjectileDistance = 20f;
    public int Damage = 10;
    public float Cooldown = 0.1f;
    public float Spread = 0.015f;
    public GameObject ProjectilePrefab;

    public IEnumerator shoot(Transform bulletStart) {
        RaycastHit hit;

        Vector3 direction = bulletStart.forward + bulletStart.right * Random.Range(-Spread, Spread);
        Vector3 projectileEndPosition = bulletStart.position + direction * ProjectileDistance;

        int mask = LayerMask.GetMask("Enemy", "Environment");
        if (Physics.Raycast(bulletStart.position, direction, out hit, ProjectileDistance, mask)) {
            Damageable damageable = hit.transform.GetComponent<Damageable>();
            if (damageable) {
                damageable.TakeDamage(Damage);
            }

            projectileEndPosition = hit.point;
        }

        Vector3 position = bulletStart.position;
        GameObject projectile = ObjectPool.Instance.Spawn(ProjectilePrefab, position, bulletStart.rotation);
        LineRenderer line = projectile.GetComponent<LineRenderer>();
        line.SetPosition(0, position);
        line.SetPosition(1, projectileEndPosition);

        ObjectPool.Instance.Despawn(projectile, Cooldown + 0.1f);

        yield return new WaitForSeconds(Cooldown);
    }
}