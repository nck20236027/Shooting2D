using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir =Vector3.zero; //移動方向を保存する変数

    Animator anim;  //アニメーターとアニメーションを間違えないように   

    void Start()
    {
        //アニメーターコンポーネントの情報を保存
        anim= GetComponent<Animator>();  //ゲットコンポーネントはスタートメソッドで一回だけ取得すればよいのでStratに入れるとよい


    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5;
        
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

    }
}
