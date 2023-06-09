using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    public GameObject BossPre;//敵のプレハブを保存する変数
    float delta;               //経過時間計算用
    float span;                //敵を出す感覚（秒）

    void Start()
    {
        delta = 0;
        span = 45f;           //生成時間
    }

    // Update is called once per frame
    void Update()
    {
        //経過時間を加算
        delta += Time.deltaTime;

        if (delta > span)
        {
            GameObject go = Instantiate(BossPre);
            
            go.transform.position = new Vector3(8, 0, 0);

            //時間経過を保存している変数を０にクリアする
            delta = 0;


            //敵を出す間隔を徐々に短くする
            //span -= (span >= 0.5f) ? 0.01f : 0f;

        }
    }

}
