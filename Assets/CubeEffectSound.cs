using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEffectSound : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //★　private void OnCollisionEnter2D(Collision2D collision) { }は　自動実行
    //★　引数には　衝突Objectが自動で入る。

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "CubePrefab")
        {
            GetComponent<AudioSource>().Play();  // 効果音を鳴らす
        }

        if (collision.gameObject.tag == "Ground")
        {
            GetComponent<AudioSource>().Play();  // 効果音を鳴らす
        }


    }


}
//Class　END