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
    private float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float nextTimeToFire = 1 / fireRate;
        if (time >= nextTimeToFire)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                shotTreat();
                time = 0;
            }
            else if (Input.GetKey(KeyCode.Mouse1))
            {
                shotTrick();
                time = 0;
            }
        }
    }
    //Disparar trato
    //IEnumerator 
    void shotTreat()
    {
        //    canFire = false;
        SoundManager.PlaySound(SoundType.SHOOT, 0, false, (float).5);
        Instantiate(treat, FirePoint.position, FirePoint.rotation);
        //    StartCoroutine(FireHandler());
        //    yield return null;
    }
    //Disparar truco
    //IEnumerator
    void shotTrick()
    {
        //    canFire = false;
        SoundManager.PlaySound(SoundType.SHOOT, 0, false, (float).5);
        Instantiate(trick, FirePoint.position, FirePoint.rotation);
        //         StartCoroutine(FireHandler());
        //       yield return null;

    }
    IEnumerator FireHandler()
    {
        float timeToNextFire = 1 / fireRate;
        yield return new WaitForSeconds(timeToNextFire);
        canFire = true;
    }

}
