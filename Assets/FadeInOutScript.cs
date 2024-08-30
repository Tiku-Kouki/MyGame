using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutScript : MonoBehaviour
{
    
   

    public Image facePanel;

    Coroutine coroutine;

    

    [SerializeField]
    Color panelColor = new Color(0, 0, 0, 0);

    [SerializeField]
    float fadeTime = 5;

    public static bool isFade = false;


    // Start is called before the first frame update
    void Start()
    {
        isFade = false;
        FadeIn();
    }

    void Update()
    {
        

       
            //テスト用　フェードアウト
            if (isFade && panelColor.a == 0)
            {
                FadeOut();
            }

            //テスト用　フェードイン
            if (!isFade && panelColor.a == 1)
            {
                FadeIn();
            }

        

    }

    public void FadeOut()
    {
        if (panelColor.a == 0)
        {
            coroutine = StartCoroutine(FadeOutCoroutine());
        }
    }


    IEnumerator FadeOutCoroutine()
    {
        float alpha = 1;

        while (panelColor.a < 1)
        {
            yield return new WaitForSeconds(0.1f);
            panelColor.a += alpha / (fadeTime * 10);
            facePanel.color = panelColor;
        }

        panelColor.a = 1;

        StopCoroutine(coroutine);
        coroutine = null;
    }

    public void FadeIn()
    {
        if (panelColor.a == 1)
        {
            coroutine = StartCoroutine(FadeInCoroutine());
        }
    }


    IEnumerator FadeInCoroutine()
    {
        float alpha = 1;

        while (panelColor.a > 0)
        {
            yield return new WaitForSeconds(0.1f);
            panelColor.a -= alpha / (fadeTime * 10);
            facePanel.color = panelColor;
        }

        panelColor.a = 0;

        StopCoroutine(coroutine);
        coroutine = null;
    }
}
