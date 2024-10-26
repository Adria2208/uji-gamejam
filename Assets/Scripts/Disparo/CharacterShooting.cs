using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public GameObject treat;
    public GameObject trick;
    public Transform FirePoint;
    public float fireRate;
    public bool canFire = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canFire){
            if (Input.GetKey(KeyCode.Mouse0) )
            {
                StartCoroutine(shotTreat());
            }
            else if (Input.GetKey(KeyCode.Mouse1) )
            {
                StartCoroutine(shotTrick());        
            }
    }
    }
    //Disparar trato
    IEnumerator shotTreat()
    {       
            canFire = false;
            Instantiate(treat, FirePoint.position, FirePoint.rotation);
            StartCoroutine(FireHandler());
            yield return null;
    }
    //Disparar truco
    IEnumerator shotTrick()
    {
            canFire = false;
            Instantiate(trick, FirePoint.position, FirePoint.rotation);
            StartCoroutine(FireHandler());
            yield return null;

    }
    IEnumerator FireHandler()
    {
        float timeToNextFire = 1 / fireRate;
        yield return new WaitForSeconds(timeToNextFire);
        canFire = true;
    }

}
