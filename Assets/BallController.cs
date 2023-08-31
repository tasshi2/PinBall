using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class BallController : MonoBehaviour
{

        //ボールが見える可能性のあるz軸の最小値
        private float visiblePosZ = -6.5f;

        //ゲームオーバを表示するテキスト
        private GameObject gameoverText;

        //得点
        private int tokuten;
        //得点テキスト
        private GameObject tokutenText;
        //ハイスコア
        private int score;
        //ハイスコアテキスト
        private GameObject scoreText;

        // Start is called before the first frame update
        void Start()
        {
                //シーン中のGameOverTextオブジェクトを取得
                this.gameoverText = GameObject.Find("GameOverText");

                //シーン中のTokutenTextオブジェクトを取得
                this.tokutenText = GameObject.Find("TokutenText");

                //シーン中のHighScoreTextオブジェクトを取得
                this.scoreText = GameObject.Find("HighScoreText");
        }

        // Update is called once per frame
        void Update()
        {
                //ボールが画面外に出た場合
                if (this.transform.position.z < this.visiblePosZ)
                {
                        //GameoverTextにゲームオーバを表示
                        // this.gameoverText.GetComponent<Text>().text = "Game Over";


                        if (score < tokuten)
                        {
                                score = tokuten;
                        }
                        tokuten = 0;

                        // HighScoreTextを表示
                        this.scoreText.GetComponent<Text>().text = "ハイスコア" + score + "点";
                        transform.position = new Vector3(3f, 2.8f, 4f);

                }
        }

        //衝突時に呼ばれる関数
        void OnCollisionEnter(Collision other)
        {
                // タグによって得点を変える
                if (other.gameObject.tag == "SmallStarTag")
                {
                        //得点を10点加算
                        tokuten = tokuten + 10;
                }
                else if (other.gameObject.tag == "LargeStarTag")
                {
                        //得点を20点加算
                        tokuten = tokuten + 20;
                }
                else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
                {
                        //得点を30点加算
                        tokuten = tokuten + 30;
                }

                //TokutenTextに得点を表示
                this.tokutenText.GetComponent<Text>().text = tokuten + "点";
        }
}