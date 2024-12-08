using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFloor : MonoBehaviour
{
    [SerializeField]
    private Vector3 min;
    [SerializeField]
    private Vector3 max;
    [SerializeField]
    private float speed;
    private float startSpeed;
    private Vector3 startPos;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startSpeed = speed;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void Update()
    {
        if(transform.position.x < startPos.x-min.x || transform.position.x > startPos.x + max.x)
        {
            speed *= -1;
        }

        Vector3 pos = transform.position;
        if (StartScript.isStart)
        {
            pos.x += speed;
        }
        


        transform.position = pos;
    }


}
