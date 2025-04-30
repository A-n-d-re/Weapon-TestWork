using DG.Tweening;
using UnityEngine;

public class PhysicsWeapon : Weapon
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float maxChargeTime = 1.5f;

    private float currentForce = 0f;
    private bool charging = false;

    public override void HandleTouch(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            charging = true;
            currentForce = 0f;
        }
        else if (touch.phase == TouchPhase.Ended && charging)
        {
            Shoot();
            charging = false;
        }
        else if (charging)
        {
            currentForce += Time.deltaTime * (projectileSpeed / maxChargeTime);
            currentForce = Mathf.Min(currentForce, projectileSpeed);
        }
    }

    public override void Shoot()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;

        GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        rb.AddForce(firePoint.up * currentForce, ForceMode2D.Impulse);

        Destroy(proj, projectileLifeTime);

        transform.DOMove(transform.parent.localPosition + -transform.up * 0.3f, 0.05f).SetLoops(2, LoopType.Yoyo);
    }
}
