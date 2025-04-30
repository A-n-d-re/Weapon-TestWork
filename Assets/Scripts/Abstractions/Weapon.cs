using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] protected float MinAngle = -90f;
    [SerializeField] protected float MaxAngle = 90f;

    [Header("Projectile Settings")]
    [SerializeField] protected float projectileSpeed = 10f;
    [SerializeField] protected float projectileLifeTime = 5f;

    protected Transform barrel;

    protected virtual void Awake()
    {
        barrel = transform;
    }

    public virtual void RotateToTouch(Vector2 touchPosition)
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;

        Vector2 direction = touchPosition - (Vector2)transform.position;
        float angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, MinAngle, MaxAngle);
        barrel.rotation = Quaternion.Euler(0, 0, angle);
    }

    public abstract void HandleTouch(Touch touch);
    public abstract void Shoot();
}
