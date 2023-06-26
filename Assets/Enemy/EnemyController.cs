using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;//移動方向
    float speed = 5;　　　　　 //移動速度
    Transform player;　　　　　//プレイヤーがどこにいるかの位置情報の保存
    public EzplosionContlloer expol;
    public GameObject tama;    //弾呼び出し　敵の
    float seisei = 2f;            //生成時間１秒」
    float delta;              //それ消すやつ
    int random = 0;
    int EnemyHp = 2;
    int BOSSEnemyHP = 10;
    void Start()
       
    {
        //寿命4秒
        Destroy(gameObject,5f);
        //プレイヤーの方向に移動　
        //player = GameObject.Find("player").transform;
        random = Random.Range(0, 100);


    }

    void Update()
    {
        //移動方向を決定
        dir = Vector3.left;
        //Y方向の移動
        //-1 <= Mathf.Sin(Time.time*5f) <=1
        //if(random <=1)
        //{
        //    トランスフォームScore　大きさを変更
        //    
        //    if(死んだら)
        //       {kyori+=3000}
        //}
        if (random <= 30)
        {
            dir.y = Mathf.Sin(Time.time * 5f);
        }
        //プレイヤーの方向に移動させる
        //dir=player.position -transform.position;

        //現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;

        delta += Time.deltaTime;
        if(delta > seisei)
        {
            delta = 0;
            GameObject go = Instantiate(tama);
            go.transform.position=transform.position;  
            
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        //何か他のオブジェクトと重なったら消去
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
           
            GameDirector.kyori -= 1000;
            
            //消去時にエフェクトを出す
            Instantiate(expol, transform.position, Quaternion.identity);

        }
        if (collision.gameObject.tag == "Shot")
        {
            EnemyHp--;
            if(EnemyHp < 0) { 
                EnemyHp = 2;
                GameDirector.kyori += 200;
                
                //消去時にエフェクトを出す
                Instantiate(expol, transform.position, Quaternion.identity);
                
                Destroy(gameObject);
            }
        }
    }
   
}
