using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointPosition : MonoBehaviour
{
    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }          
    
    void turn(float inputMovement)  {
    if (velocity.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        } else if (velocity.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180f, 0);
        }
    }
}
