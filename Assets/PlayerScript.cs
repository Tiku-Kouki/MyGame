using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    private bool isBlock = true;

    int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;

        

        var pos = transform.position;

        // xé≤ï˚å¸ÇÃà⁄ìÆîÕàÕêßå¿
        pos.y = Mathf.Clamp(pos.y, -10, 10);
        float moveSpeed = 5.0f;

        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);

        Ray ray = new Ray(rayPosition, Vector3.down);

        float distance = 0.35f;

        isBlock = Physics.Raycast(ray, distance);

        if (isBlock == true)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

            
        }
        else
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);

            jumpCount = 1;
        }

        if (GoalScript.isGameClear == true)
        {
            v.x = 0;
            return;
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

        if (Input.GetKeyDown(KeyCode.Space)&&jumpCount<2)
        {
            v.y = 5;

            jumpCount++;

            Debug.Log(jumpCount);

        }


        
        rb.velocity = v;
        transform.position = pos;
    }
}
