using UnityEngine;

//�S�[���̃X�N���v�g


public class GoalScript : MonoBehaviour
{
    //�Q�[���N���A�̃e�L�X�g
    public GameObject gameClearText;
    //�S�[���̃h�A�ɐG��Ă���Ƃ��\���̃e�L�X�g
    public GameObject doorInText;
    //�@�N���A�������̕ϐ�
    public static bool isGameClear = false;
    //�@�S�[��������̉�
    public AudioSource goalAudio;
    //�@�p�[�e�B�N��
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
            //�S�[��������e�L�X�g������
            doorInText.SetActive(false);
            return;
        }

        if (GameManagerScript.eraseGoalText)
        {
            gameClearText.SetActive(false);
        }


    }

    //�G��Ă��鎞
    private void OnCollisionStay(Collision other)
    {
        //�@�R���g���[���̏㉺����
        float moveY = Input.GetAxis("Vertical");

        // �v���C���[���S�[���ɐG��Ă���Ƃ�
        if (other.gameObject.CompareTag("Player"))
        {
            //�e�L�X�g�\��
            doorInText.SetActive(true);
            

            //�@����͂�������
            if ((Input.GetKey(KeyCode.UpArrow)||
                moveY >0)&&
                !isGameClear)
            {
                //�S�[������
                goalAudio.Play();
                gameClearText.SetActive(true);
                isGameClear = true;
                Instantiate(starParticle, starParticle.transform.position, Quaternion.identity);
            }
        }
    }
    //���ꂽ��
    private void OnCollisionExit(Collision other)
    {
        // �v���C���[���S�[�����痣�ꂽ��
        if (other.gameObject.CompareTag("Player"))
        {
            doorInText.SetActive(false);
        }
    }




}
