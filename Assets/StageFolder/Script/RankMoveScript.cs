using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankMoveScript : MonoBehaviour
{
    //“¾“_‚Ìˆê’èˆÈãŽB‚Á‚½Žž‚Ìƒ‰ƒ“ƒN
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI nowRank;
    [SerializeField]
    private Vector3 endRankTextPos;
    [SerializeField]
    private Vector3 endGoalRankPos;
    


    [SerializeField]
    private float speed;

    public  bool isRankSet = false;

    // Start is called before the first frame update
    void Start()
    {
        
        

        isRankSet = false;

    }

     void Update()
    {
        if (GoalScript.isGameClear)
        {

            if (rankText.transform.position.x > endRankTextPos.x)
            {
                rankText.transform.position = rankText.transform.position - new Vector3(speed, 0, 0);
            }

            if (rankText.transform.position.x <= endRankTextPos.x)
            {
                rankText.transform.position = new Vector3 (endRankTextPos.x,rankText.transform.position.y, rankText.transform.position.z);

                if (nowRank.transform.position.x > endGoalRankPos.x)
                {
                    nowRank.transform.position = nowRank.transform.position - new Vector3(speed, 0, 0);
                }

            }

            if (nowRank.transform.position.x <= endGoalRankPos.x)
            {
                nowRank.transform.position = new Vector3(endGoalRankPos.x, nowRank.transform.position.y, nowRank.transform.position.z);

                isRankSet = true;

            }
        }

    }

}
