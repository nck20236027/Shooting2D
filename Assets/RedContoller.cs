using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedContoller : MonoBehaviour
{
    AudioSource audioSource;   //オーディオソースコンポーネントの情報を取得
    AudioClip seClip;          //オーディオクリップ保存
    Vector3 sePos;             //効果音を鳴らす位置
    Vector3 dir = Vector3.zero;
    float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        //５秒後きえる
        Destroy(gameObject, 5f);
        //メインカメラの位置を保存
        sePos = GameObject.Find("Main Camera").transform.position;
        seClip = Resources.Load<AudioClip>("Audio/SE/decision49");

    }

    // Update is called once per frame
    void Update()
    {
        dir = Vector3.down;
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(seClip, sePos);
            Destroy(gameObject);
        }
    }
}
