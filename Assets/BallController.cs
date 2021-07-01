using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController: MonoBehaviour
{
    //ボールが見える可能性のありｚ軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //当たり判定のコンポーネントを入れる【課題】

    private Rigidbody myRigidbody;

    //画面右上にScoreを表示する　【課題】

    private GameObject ScoreText;

    //得点　【課題】

    private int score = 0;




    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyコンポーネントを取得

        this.myRigidbody = GetComponent<Rigidbody>();


        //シーン中のGameOverTextオブジェクトを習得
        this.gameoverText = GameObject.Find("GameOverText");


        //シーン中のScoreTextオブジェクトを取得

        this.ScoreText = GameObject.Find("ScoreText");


    }

    // Update is called once per frame
    void Update()
    {
         //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameOverTextにGame Overを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //ボールがオブジェクトと接触した場合の処理【課題】
    void OnCollisionEnter(Collision other)
    {
        //ボールが小さい雲,大きい星に衝突した場合

        if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeStarTag")
        {
            this.score += 10;
        }
        //ボールが大きい雲に衝突した場合

        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.score += 50;
        }
        //ボールが小さい星に衝突した場合
        else if (other.gameObject.tag == "SmallStarTag")
        {
            this.score += 1;
        }

        //ScoreTextに獲得した点数を表示
        this.ScoreText.GetComponent<Text>().text = this.score + "pt";
    }



}


