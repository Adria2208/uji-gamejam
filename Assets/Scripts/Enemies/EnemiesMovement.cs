using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMovement1 : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    public float speed = 3f;
    private Collider2D ObjColl;
    private Animator animator;
    private bool lookRight = true;
        void Start()
    {
        ObjColl = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }
    
        void Update()
    {
       Movement();
       turn();
    }
//Movimiento del personaje
    void Movement(){
        if (Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < .1f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
    }

    void turn()  {
        if ( (lookRight ==true && currentWaypoint != 0)|| (lookRight == false && currentWaypoint == 0) )
        {
            lookRight = !lookRight;
            transform.Rotate(0f, 180f, 0f);
        }

    }
}
