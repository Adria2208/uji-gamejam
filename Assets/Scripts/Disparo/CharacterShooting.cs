using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public GameObject treat;
    public GameObject trick;
    public Transform FirePoint;
    public int Seconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) )
    {
        shotTreat();
        
    }
    else if (Input.GetKey(KeyCode.Mouse1) )
    {
        shotTrick();
        
        
    }
    }
    //Disparar trato
    void shotTreat()
    {
            Instantiate(treat, FirePoint.position, FirePoint.rotation);
    }
    //Disparar truco
    void shotTrick()
    {
            Instantiate(trick, FirePoint.position, FirePoint.rotation);

    }

}
