using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{

    //Cubeの移動速度
    //★変数
    private float speed = -12;

    // 消滅位置
    //★　変数
    private float deadLine = -10;


    // Use this for initialization
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        // Cubeを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }

    }
    //Update()　END

}
//Class　END