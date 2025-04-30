using UnityEngine;

public class BouncingProjectile : MonoBehaviour
{
    private Vector2 velocity;

    public void Init(Vector2 initialVelocity)
    {
        velocity = initialVelocity;
    }

    void Update()
    {
        transform.position += (Vector3)(velocity * Time.deltaTime);

        Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 screenBounds = new Vector2(Screen.width, Screen.height);

        if (pos.x < 0 || pos.x > screenBounds.x)
            velocity.x *= -1;
        if (pos.y < 0 || pos.y > screenBounds.y)
            velocity.y *= -1;
    }
}
