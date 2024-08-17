using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    private bool isBlock = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    int jampCount = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;

        

        var pos = transform.position;

        // xé≤ï˚å¸ÇÃà⁄ìÆîÕàÕêßå¿
        pos.y = Mathf.Clamp(pos.y, -10, 10);
        float moveSpeed = 3.0f;

        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);

        Ray ray = new Ray(rayPosition, Vector3.down);

        float distance = 0.9f;

        isBlock = Physics.Raycast(ray, distance);

        if (isBlock == true)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

            jampCount = 0;
        }
        else
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);

            

        }


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

        if (Input.GetKeyDown(KeyCode.Space)&&jampCount<5)
        {
            v.y = 5;

            jampCount++;

            Debug.Log(jampCount);

        }


        
        rb.velocity = v;
        transform.position = pos;
    }
}
