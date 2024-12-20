using UnityEngine;

[RequireComponent(typeof(Transform))]
public class FollowPlayer : MonoBehaviour
{
    public Transform followPoint;

    public float offsetX;
    public float offsetY;

    private float zAxis;

    private void Start()
    {
        zAxis = transform.position.z;
    }

    void Update()
    {
        if (followPoint != null)
        {
            gameObject.transform.position = GetNextPosition();
        }
    }

    private Vector3 GetNextPosition()
    {
        Vector3 playerPosition = followPoint.transform.position;
        return new Vector3(playerPosition.x + offsetX, playerPosition.y + offsetY, zAxis);
    }
}
