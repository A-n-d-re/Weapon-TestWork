using DG.Tweening;
using UnityEngine;

public class BouncingWeapon : Weapon
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    public override void HandleTouch(Touch touch)
    {
        if (touch.phase == TouchPhase.Ended)
        {
            Shoot();
        }
    }

    public override void Shoot()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        BouncingProjectile bouncingProjectile = projectile.GetComponent<BouncingProjectile>();
        bouncingProjectile.Init(firePoint.up * projectileSpeed);

        Destroy(projectile, projectileLifeTime);

        transform.DOMove(transform.parent.localPosition + -transform.up * 0.3f, 0.05f).SetLoops(2, LoopType.Yoyo);
    }
}
