using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    private FloorsScript[] floors;


    // Start is called before the first frame update
    void Start()
    {
        floors = FindObjectsOfType<FloorsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach(var f in floors)
        {
            f.Move();

        }


    }
}
