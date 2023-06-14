using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;//移動方向
    float speed = 5;　　　　　 //移動速度
    Transform player;　　　　　//プレイヤーがどこにいるかの位置情報の保存
    void Start()
    {
        //寿命4秒
        Destroy(gameObject,4f);
        //プレイヤーの方向に移動　
        player = GameObject.Find("player").transform;
    }

    void Update()
    {
        //移動方向を決定
        dir = Vector3.left;

        //左に見切れたら右から登場
        if(transform.position.x<-9f)
        {
            Vector3 pos = transform.position;
            pos.x = 9f;
            transform.position = pos;
        }
        //Y方向の移動
        //-1 <= Mathf.Sin(Time.time*5f) <=1
        dir.y = Mathf.Sin(Time.time * 5f);
        //プレイヤーの方向に移動させる
        dir=player.position -transform.position;

        //現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;

        

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //制限時間を１０秒減らす
        GameDirector.lastTime -= 10f;
        //何か他のオブジェクトと重なったら消去
        Destroy(gameObject);

    }
}
