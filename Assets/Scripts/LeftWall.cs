using UnityEngine;

public class LeftWall : MonoBehaviour
{

    private new Transform camera;
    private float startX;
    private float startY;
    private float startZ;

    private void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        startX = transform.position.x;
        startY = transform.position.y;
        startZ = transform.position.z;
    }
    void Update()
    {
        Vector3 newPosition = new Vector3 (startX + camera.position.x, startY, startZ);
        transform.position = newPosition;
    }
}
