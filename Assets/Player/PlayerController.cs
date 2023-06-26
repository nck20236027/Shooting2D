using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir =Vector3.zero; //移動方向を保存する変数
    GameObject Shot;//弾のプレハブを保存する
    Animator anim;  //アニメーターとアニメーションを間違えないように   
    float ShotTimer;//弾の発射間隔制御用
    public static int power = 0;  //弾のレベル
    float speed = 6;//プレイヤーの速度


    void Start()
    {
        //アニメーターコンポーネントの情報を保存
        anim= GetComponent<Animator>();  //ゲットコンポーネントはスタートメソッドで一回だけ取得すればよいのでStratに入れるとよい
        //弾のプレハブを変数に保存する
        Shot = (GameObject)Resources.Load("Shot");

    }

    // Update is called once per frame
    void Update()
    {
        //移動方向をセット
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;  //dirこの変数の後ろに.normalizedをつけると斜め移動のスピードを

        //画面内移動制限
        Vector3 pos = transform.position; //変数pos
        pos.x = Mathf.Clamp(pos.x,-9f, 9f);　//x.yの画面制限座標設定
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;　　　　　//transform.position現在地の座標にposを入れる?

        //アニメーション設定
        if(dir.y==0)
        {
            //アニメーションクリップ「Player」を再生
            anim.Play("Player");
        }
        else if (dir.y==1)
        {
            anim.Play("PlayerL");
        }
        else if (dir.y==-1)
        {
            anim.Play("PlayerR");
        }
        //Cキーで弾のレベルアップ
        if(Input.GetKeyDown(KeyCode.C))
        {
            power = (power + 1) % 13;
        }
        //Zキーで球発射
        ShotTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z) && ShotTimer > 0.3f)
        {
            for (int i = -power; i < power + 1; i++)
            {
                //プレイヤーの現在地をposに保存
                pos = transform.position;
                //プレイヤーの回転角度を取得
                Vector3 r = transform.root.eulerAngles + new Vector3(0,0 , 15f * i);
                Quaternion rot = Quaternion.Euler(r);

                //弾を生成する際に、プレイヤーの位置と角度をリセット
                Instantiate(Shot,pos,rot);
            }
            ShotTimer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Red")
        {
            
            power = (power + 1) % 13;
        }
        if (collision.gameObject.tag =="Ger")
        {
            speed = (speed + 3);
            
        }
        if (collision.gameObject.tag=="Bul")
        {
            power = 0;
            speed = 5;
        }
    }
}
