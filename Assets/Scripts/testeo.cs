using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testeo : MonoBehaviour
{
    public TMP_Text crono;
    public float contador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
        crono.text = contador.ToString();
    }
}
