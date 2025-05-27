using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WarpPoint : MonoBehaviour
{
    // 移動させる位置
    [SerializeField]
    private Vector3 pos;
    //　高さ
    [SerializeField]
    private float height = 3.0f;
    //　どれくらいで移動するか
    [SerializeField]
    const float fps = 60.0f;

    public AudioSource warpAudio;

    [SerializeField]
    private float roteSpeed = 3.0f;
    private float radius ;

    private float distance = 0.35f;

    private float direction;

    // 線間補完
    Vector3 CalcLerpPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        var a = Vector3.Lerp(p0, p1, t);
        var b = Vector3.Lerp(p1, p2, t);
        return Vector3.Lerp(a, b, t);
    }

    // コルーチン
    IEnumerator LerpThrow(GameObject target, Vector3 start, Vector3 half, Vector3 end, float duration)
    {
        float startTime = Time.timeSinceLevelLoad;
        float rate = 0f;
        while (true)
        {
            if (rate >= 1.0f)
                yield break;

            float diff = Time.timeSinceLevelLoad - startTime;
            rate = diff / (duration / 60f);
            target.transform.position = CalcLerpPoint(start, half, end, rate);

            radius = target.transform.localScale.x / 2f;
            float angle = (distance / radius) * Mathf.Rad2Deg;
            

            //回転させる
            if (start.z < end.z)
            {
                direction = Mathf.Sign(-roteSpeed); // 左右で回転方向を変える
                target.transform.Rotate(Vector3.left, angle * direction, Space.World);
            }
            else if (start.z > end.z)
            {
                direction = Mathf.Sign(roteSpeed); // 左右で回転方向を変える
                target.transform.Rotate(Vector3.left, angle * direction, Space.World);
            }

            yield return null;
        }
    }
    //指定位置に弧を描いて移動する
    public void StartThrow(GameObject target, float height, Vector3 start, Vector3 end, float duration)
    {
        float halfToUse = 0.50f;

        // 中点を求める
        Vector3 half = end - start * halfToUse + start;
        half.y += Vector3.up.y + height;
        


            StartCoroutine(LerpThrow(target, start, half, end, duration));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            

            warpAudio.Play();
           //指定位置に弧を描いて移動
            StartThrow(other.gameObject, height, transform.position, pos, fps);


        }
    }
    
    


}
