using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class warpPoint : MonoBehaviour
{
    public Vector3 pos;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
