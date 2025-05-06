using UnityEngine;

//ゴールのスクリプト


public class GoalScript : MonoBehaviour
{
    //ゲームクリアのテキスト
    public GameObject gameClearText;
    //ゴールのドアに触れているとき表示のテキスト
    public GameObject doorInText;
    //　クリアしたかの変数
    public static bool isGameClear = false;
    //　ゴールした後の音
    public AudioSource goalAudio;
    //　パーティクル
    public GameObject starParticle;



    // Start is called before the first frame update
    void Start()
    {
        isGameClear = false;
    }

    private void Update()
    {
        if (isGameClear)
        {
            //ゴールした後テキストを消す
            doorInText.SetActive(false);
            return;
        }

        if (GameManagerScript.eraseGoalText)
        {
            gameClearText.SetActive(false);
        }


    }

    //触れている時
    private void OnCollisionStay(Collision other)
    {
        //　コントローラの上下入力
        float moveY = Input.GetAxis("Vertical");

        // プレイヤーがゴールに触れているとき
        if (other.gameObject.CompareTag("Player"))
        {
            //テキスト表示
            doorInText.SetActive(true);
            

            //　上入力をしたら
            if ((Input.GetKey(KeyCode.UpArrow)||
                moveY >0)&&
                !isGameClear)
            {
                //ゴール判定
                goalAudio.Play();
                gameClearText.SetActive(true);
                isGameClear = true;
                Instantiate(starParticle, starParticle.transform.position, Quaternion.identity);
            }
        }
    }
    //離れた時
    private void OnCollisionExit(Collision other)
    {
        // プレイヤーがゴールから離れた時
        if (other.gameObject.CompareTag("Player"))
        {
            doorInText.SetActive(false);
        }
    }




}
