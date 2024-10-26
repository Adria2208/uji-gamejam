using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseList : MonoBehaviour
{
    public List<Transform> houses = new List<Transform>();
    public bool completed = false;
    public int housesCompleted = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform[] pathTransform = GetComponentsInChildren<Transform>();
        houses = new List<Transform>();
        
        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != transform)
            {
                houses.Add(pathTransform[i]);
            }
        }
        Debug.Log(houses.Count);
        if (houses.Count == housesCompleted)
        {
            completed = true;
        }
    }
}
