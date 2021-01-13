using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//★GameScene遷移用　Engine　読み込み必須
using UnityEngine.SceneManagement; //（追加）


public class UIController : MonoBehaviour
{

    // GameOverText　Object
    //★変数
    private GameObject gameOverText;

    // 走行距離Text
    //★変数
    private GameObject runLengthText;

    // 走った距離
    //★変数　初期化
    private float len = 0;

    // 走る速度
    //★変数　初期化
    private float speed = 0.03f;

    // GameOverの判定
    //★変数　初期化
     private bool isGameOver = false;

    // Use this for initialization
    void Start()
    {
        // SceneViewからObjectの実体を検索する
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false)
        {
            // 走った距離を更新する
            this.len += this.speed;

            // 走った距離を表示する
            //★　 「ToString()」は数値を文字列に変換　F2は少数部　2桁迄表示する
            this.runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString("F2") + "m";
        }

        // GameOverになった場合
        if (this.isGameOver == true)
        {
            // ClickされたらSceneを読み込む（追加）
            if (Input.GetMouseButtonDown(0))
            {
                //GameSceneを読み込む（追加）
                //★　頭で読み込んだ　SceneManagerClass　の　LoadScene関数
                SceneManager.LoadScene("GameScene");
            }
        }


    }



    public void GameOver()
    {
        // GameOverになったときに、画面上にGameOverを表示する
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }

}
//Class　END