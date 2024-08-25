using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {

    }



   

    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;



        var pos = transform.position;

        // xé≤ï˚å¸ÇÃà⁄ìÆîÕàÕêßå¿
        pos.x = Mathf.Clamp(pos.x, -9.5f, 9.5f);

        pos.z = Mathf.Clamp(pos.z, -5.5f, 5.5f);


        float moveSpeed = 5.0f;

        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);

        Ray ray = new Ray(rayPosition, Vector3.down);

        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            v.x = moveSpeed;
        }
        else
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            v.x = -moveSpeed;
        }
        else
        {
            v.x = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            v.z = moveSpeed;
        }
        else
        if (Input.GetKey(KeyCode.DownArrow))
        {
            v.z = -moveSpeed;
        }
        else
        {
            v.z = 0;
        }





        rb.velocity = v;
        transform.position = pos;
    }
}
