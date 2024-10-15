using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    private bool isBlock = true;

    public AudioSource jumpAudio;

    public AudioSource coinAudio;

    int jumpCount = 0;

    float moveSpeed = 5.0f;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;
    }

    
    

    private void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.CompareTag("Treasure"))
        {
            other.gameObject.SetActive(false);

            coinAudio.Play();

            GameManagerScript.score += 1;

            
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }

        


    }

   
    


    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;

        

        var pos = transform.position;

        // yé≤ï˚å¸ÇÃà⁄ìÆîÕàÕêßå¿
        pos.y = Mathf.Clamp(pos.y, -10, 100);
        

        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.5f, 0.0f);

        Ray ray = new Ray(rayPosition, transform.up * -1);

        float distance = 0.35f;

        
        float moveX = Input.GetAxis("Horizontal");

        //RaycastHit hit;

        isBlock = Physics.Raycast(ray, distance);

        if (transform.position.y <= -5.0f)
        {
            

            transform.position = startPos;
            return;
        }

        if (isBlock)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

            
            Debug.Log(jumpCount);
        }
        else if
        (!isBlock)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);

            
        }

        if (GoalScript.isGameClear)
        {
            v.x = 0;

            rb.velocity = v;
            transform.position = pos;
            return;
        }

        
        if(PauseManagerScript.isGamePouse) 
        {
            v.x = 0;

            rb.velocity = v;
            transform.position = pos;

            return;
        }

        if (Input.GetKey(KeyCode.RightArrow) ||
            moveX > 0)
        {
            v.x = moveSpeed;
        }
        else
        if (Input.GetKey(KeyCode.LeftArrow)||
            moveX < 0)
        {
            v.x = -moveSpeed;
        }
        else
        {
            v.x = 0;
        }

        if ((Input.GetKeyDown(KeyCode.Space)||
            Input.GetKeyDown("joystick button 0"))
            &&jumpCount<2)
        {
            v.y = 5;


            jumpCount++;

            jumpAudio.Play();

            Debug.Log(jumpCount);

        }

        

        rb.velocity = v;
        transform.position = pos;
    }

    



}
