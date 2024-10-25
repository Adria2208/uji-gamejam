using UnityEngine;

public static class Extensions 
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");
    public static bool CheckGrounds(this Rigidbody2D rigidbody, BoxCollider2D boxCollider)
    {
        if (rigidbody.isKinematic)
        {
            return false;
        }

        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.02f, layerMask);
        return raycastHit2d.collider != null;
    }

    // Checks if the rigidbody is colliding with an object in a given direction.
    // For example, if you want to check if the player is touching the ground,
    // you can pass Vector2.down. If you want to check if the player is running
    // into a wall, you can pass Vector2.right or Vector2.left.
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
        if (rigidbody.isKinematic)
        {
            return false;
        }

        float radius = 0.25f;
        float distance = 0.375f;

        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction.normalized, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }

    public static bool DotTest(this Transform transform, Vector2 collisionPoint, Vector2 testDirection)
    {
        Vector3 collisionPointPosition = collisionPoint;
        Vector2 direction = collisionPointPosition - transform.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.5f;
    }

    public static bool RaycastLateral(this Rigidbody2D rigidbody, Vector2 direction)
    {
        if (rigidbody.isKinematic)
        {
            return false;
        }

        float radius = 0.25f;
        float distance = 0.20f;

        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction.normalized, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }

}
