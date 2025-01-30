using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;




public class PushesOutScript : MonoBehaviour
{

    //待機時間
    [SerializeField]
    private float waitTime;
    //どれだけたったか
    private float time;
    //押し出しの速さ
    [SerializeField]
    private float speed;
    //押し出されたプレイヤーの速さ
    [SerializeField]
    private float pushPlayerSpeed;
    //押し出された後のプレイヤーの位置
    [SerializeField] 
    private Vector3 afterPlayerPos;
    //戻るときの速さ
    [SerializeField]
    private float buckSpeed;
    //どこまで押し出すか
    [SerializeField]
    private Vector3 pushPos;
    private Vector3 startPos;
    //　どれくらいで移動するか
    [SerializeField]
    private float fps = 60.0f;


    private int mode = 0;

    private float distance_two;

    

    

    // コルーチン
    IEnumerator LerpPush(GameObject target, Vector3 start, Vector3 end, float duration)
    {
        float startTime = Time.timeSinceLevelLoad;
        float rate = 0f;
        while (true)
        {
            if (rate >= 1.0f)
                yield break;

            float diff = Time.timeSinceLevelLoad - startTime;
            rate = diff / (duration / 60f);
            
            target.transform.position = Vector3.Lerp(start, end, rate);

            yield return null;
        }
    }
    //指定位置に移動する
    public void StartPush(GameObject target,Vector3 start, Vector3 end, float duration)
    {
        
        StartCoroutine(LerpPush(target, start,  end, duration));
    }

    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartPush(other.gameObject, other.transform.position, afterPlayerPos,fps);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        distance_two = Vector3.Distance(transform.position, afterPlayerPos);
    }

    // Update is called once per frame
    void Update()
    {
        

        switch (mode)
        {
            case 0:

                time++;

                if(time > waitTime)
                {

                    mode = 1;
                    time = 0;

                }

             break;

            case 1:

                if (transform.position.z < pushPos.z)
                {
                    mode = 2;
                }
                else
                {
                    
                    transform.position -= new Vector3(0, 0, speed);
                }
                break;
            case 2:
                if (transform.position.z > startPos.z)
                {
                    mode = 0;
                }
                else
                {

                    transform.position += new Vector3(0, 0, buckSpeed);
                }


                break;

        }





    }
}
