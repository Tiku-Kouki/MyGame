using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WarpDoorScript : MonoBehaviour
{
    public Vector3 pos;

    

    // Start is called before the first frame update
    void Start()
    {
        

    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
            }

        }
    }

    
    

   
}
