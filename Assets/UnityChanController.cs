using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour
{
    //AnimationするためのComponent指定
    //★変数
    Animator animator;

   //Unityちゃんを移動させるComponent指定　（追加）
   //★変数
    Rigidbody2D rigid2D;

    // 地面の位置　設定
    //★変数　初期化
    private float groundLevel = -3.0f;


    // Jampの速度の減衰（追加）
    //★変数
    private float dump = 0.8f;

    // Jampの速度（追加）
    //★変数
    float jumpVelocity = 20;


    // GameOverになる位置（追加）
    //★変数　初期化
    private float deadLine = -9;



    // Use this for initialization
    void Start()
    {
        //AnimaterのComponentを取得する
        this.animator = GetComponent<Animator>();

        // Rigidbody2DのComponentを取得する（追加）
        this.rigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // 走るAnimationを再生するために、Animatorの値を調節する
        this.animator.SetFloat("Horizontal", 1);

        // 着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);
        
        // Jamp状態のときには音量Volumeを0にする（追加）
        //★Audio Component　を指定しているということ
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        // 着地状態でClickされた場合（追加）
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // 上方向の力をかける（追加）
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        // Clickをやめたら上方向への速度を減速する（追加）
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        // DeadLineを超えた場合GameOverにする（追加）
        //★transform.position.x　はUnityちゃんの位置　それがDeadLineを超えているか判定している
        if (transform.position.x < this.deadLine)
        {
            // UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する（追加）
            //★　UIControllerからGameOver()関数を呼び出している
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            // Unitｙちゃんを破棄する（追加）
            Destroy(gameObject);
        }



    }
    //Update () END
}
//Class　END