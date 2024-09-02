using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WarpPoint : MonoBehaviour
{
    public Vector3 pos;

    float height = 3.0f;

    float fps = 60.0f;

    public AudioSource warpAudio;

    

    // ���ԕ⊮
    Vector3 CalcLerpPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        var a = Vector3.Lerp(p0, p1, t);
        var b = Vector3.Lerp(p1, p2, t);
        return Vector3.Lerp(a, b, t);
    }

    // �R���[�`��
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

            yield return null;
        }
    }

    public void StartThrow(GameObject target, float height, Vector3 start, Vector3 end, float duration)
    {
        // ���_�����߂�
        Vector3 half = end - start * 0.50f + start;
        half.y += Vector3.up.y + height;

        StartCoroutine(LerpThrow(target, start, half, end, duration));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            

            warpAudio.Play();
           
            StartThrow(other.gameObject, height, transform.position, pos, fps);


        }
    }
    
    


}
