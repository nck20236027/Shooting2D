using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel; //距離を表示するUI‐Textオブジェクト
    public Text ShotLevel;  //弾の強さを表示するUI

    public static int kyori;           //距離を保存する変数
    public static float hp;

    float lastTime;    //残り時間を保存する変数  public static
    public Image GaugeLavel; //ゲージを表示するUI
    
    
    void Start()
    {
        kyori = 0;
        lastTime = 100f; //残り時間100秒
        hp = 100f;
       
    }

    void Update()
    {

        GaugeLavel.fillAmount = hp / 100;
        hp = Mathf.Clamp(hp, 0, 100);

        //進んだ距離を表示
        if (kyori < 0) kyori = 0;
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + ":Score";
        

        //残り時間を減らす処理
        //lastTime -= Time.deltaTime;
        //timeGauge.fillAmount = lastTime / 100f;

        //残り時間が0になったらリロード
        if(hp == 0)
        {
            SceneManager.LoadScene("TorSene");
        }
        ShotLevel.text = "Level:"+PlayerController.power. ToString("D2");
    }
    
    
}
