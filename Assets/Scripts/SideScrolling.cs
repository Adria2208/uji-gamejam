using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 cameraPosition = transform.position;
            // Use this line of code for Super Mario Bros-like right only camera movement
            // cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
            // Use this line of code to scroll left and right like normal
            cameraPosition.x = player.position.x;
            transform.position = cameraPosition;
        }
    }
}
