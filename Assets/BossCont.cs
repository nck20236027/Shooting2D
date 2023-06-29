using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCont : MonoBehaviour
{
    Vector3 dir = Vector3.zero;//移動方向
    float speed = 5;      //移動速度
    public EzplosionContlloer expol; //爆発のエフェクト
    int EnemyHp = 50;                //ボスhp
    float time = 0;                    //演出時間
    float sporn = 3;                    //演出時間２
    public GameObject tama;    //弾呼び出し　敵の
    float seisei = 1f;            //生成時間3秒」
    float delta;              //それ消すやつ


    AudioClip seClip;          //オーディオクリップ保存
    Vector3 sePos;             //効果音を鳴らす位置

    // Start is called before the first frame update
    void Start()
    {
        

        sePos = GameObject.Find("Main Camera").transform.position;
        seClip = Resources.Load<AudioClip>("Audio/SE/bomb");

    }

    void Update()
    {
        transform.position += dir.normalized * speed * Time.deltaTime;

        //弾を打つ
        delta += Time.deltaTime;
        if (delta > seisei)
        {
            delta = 0;
            GameObject go = Instantiate(tama);
            go.transform.position = transform.position;

        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameDirector.hp -= 10f;
            GameDirector.kyori -= 1000;
            ////消去時にエフェクトを出す
            //Instantiate(expol, transform.position, Quaternion.identity);

        }
        if (collision.gameObject.tag == "Shot")
        {
            EnemyHp--;
            if (EnemyHp < 0)
            {

                GameDirector.kyori += 200;

                AudioSource.PlayClipAtPoint(seClip, sePos);
                //消去時にエフェクトを出す
                Instantiate(expol, transform.position, Quaternion.identity);
                SceneManager.LoadScene("TorSene");
              
                Destroy(gameObject);
                

                
            }
        }
    }
}


