using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//動く床
public class moveFloor : FloorsScript
{
    [SerializeField]
    private Vector3 min;//
    [SerializeField]
    private Vector3 max;//
    [SerializeField]
    private float speed;//動くスピード
    private float backSpeed = -1;//スピードの反転に使うスクリプト
    private float startSpeed;
    private Vector3 startPos;

    

    public override void Move()
    {
        if (transform.position.x < startPos.x - min.x || transform.position.x > startPos.x + max.x)
        {
            speed *= backSpeed;
        }

        Vector3 pos = transform.position;
        if (StartScript.isStart)
        {
            pos.x += speed;
        }



        transform.position = pos;
    }




    // プレイヤーが触れているときにプレイヤーの親となる
    private void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
            
        }
    }
    // プレイヤーが離れた時親子関係を解除する
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
            speed *= backSpeed;
        }

        Vector3 pos = transform.position;
        if (StartScript.isStart)
        {
            pos.x += speed;
        }
        


        transform.position = pos;
    }

    
}
