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

        // xŽ²•ûŒü‚ÌˆÚ“®”ÍˆÍ§ŒÀ
        pos.x = Mathf.Clamp(pos.x, -9.5f, 9.5f);
        // ‚šŽ²•ûŒü‚ÌˆÚ“®”ÍˆÍ§ŒÀ
        pos.z = Mathf.Clamp(pos.z, -5.5f, 5.5f);


        float moveSpeed = 5.0f;

        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);

        Ray ray = new Ray(rayPosition, Vector3.down);

        float moveX = Input.GetAxis("Horizontal");

        float moveY = Input.GetAxis("Vertical");

        if (!ShaterScript.isShaterOpen)
        {
            return;
        }


        if (Input.GetKey(KeyCode.RightArrow)||moveX>0)
        {
            v.x = moveSpeed;
        }
        else
        if (Input.GetKey(KeyCode.LeftArrow)|| moveX<0)
        {
            v.x = -moveSpeed;
        }
        else
        {
            v.x = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow) || moveY > 0)
        {
            v.z = moveSpeed;
        }
        else
        if (Input.GetKey(KeyCode.DownArrow) || moveY<0)
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
