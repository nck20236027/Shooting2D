using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;//移動方向
    float speed = 5;　　　　　 //移動速度
    Transform player;　　　　　//プレイヤーがどこにいるかの位置情報の保存
    public EzplosionContlloer expol;
    public GameObject tama;    //弾呼び出し　敵の
    float seisei = 3f;            //生成時間3秒」
    float delta;              //それ消すやつ
    int random = 0;
    int EnemyHp = 2;
    AudioClip seClip;          //オーディオクリップ保存
    Vector3 sePos;             //効果音を鳴らす位置

    void Start()
    {
        //寿命4秒
        Destroy(gameObject,5f);
        //敵の行動ランダム化
        random = Random.Range(0, 100);
        //メインカメラの位置を保存
        sePos= GameObject.Find("Main Camera").transform.position;
        seClip = Resources.Load<AudioClip>("Audio/SE/bomb");
    }

    void Update()
    {
        //移動方向を決定
        dir = Vector3.left;
        if (random <= 30)
        {
            dir.y = Mathf.Sin(Time.time * 5f);
        }

        //現在地に移動量を加算
        transform.position += dir.normalized * speed * Time.deltaTime;

        //弾を打つ
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
           
            GameDirector.hp -= 10f;
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

                AudioSource.PlayClipAtPoint(seClip, sePos);
                //消去時にエフェクトを出す
                Instantiate(expol, transform.position, Quaternion.identity);
                
                Destroy(gameObject);
            }
        }
    }
   
}
