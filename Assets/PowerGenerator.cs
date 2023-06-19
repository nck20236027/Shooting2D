using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGenerator : MonoBehaviour
{
    public GameObject Red; //Redのオブジェクトを保存する
    public GameObject Ger; //Gerのオブジェクトを保存する
    public GameObject Bul; //Bulのオブジェクトを保存する

    float delta;               //経過時間計算用
    float span;                //敵を出す感覚（秒）
    int random = 0;
    // Start is called before the first frame update
    void Start()
    {
        delta = 0;
        span = 10f;
        
    }


    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if(delta > span)
        {
            //GameObject go = Random.InitState(Red, Ger, Bul);
            
            random = Random.Range(0, 3);
            Debug.Log(Random.Range(0, 3));
            if(random == 0 )
            {
                //生成する
                GameObject go = Instantiate(Red);
                float py = Random.Range(-8f, 8f);
                go.transform.position = new Vector3(py,7 , 0);

                //時間経過を保存している変数を０にクリアする
                delta = 0;
                
            }
            else if(random == 1 )
            {
                GameObject go = Instantiate(Ger);
                float py = Random.Range(-9f, 9f);
                go.transform.position = new Vector3(py, 7, 0);

            }
            else if(random == 2 )
            {
                GameObject go = Instantiate(Bul);
                float py = Random.Range(-9f, 9f);
                go.transform.position = new Vector3(py, 7, 0);
            }
            delta = 0;
        }
    }

}
