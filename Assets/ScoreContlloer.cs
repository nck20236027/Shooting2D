using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreContlloer : MonoBehaviour
{
    AudioSource audioSource;
    const int MAX_BGM= 3;
    AudioClip[] bgmClip = new AudioClip[MAX_BGM];//オーディオクリップ
    int bgmNumder = 0;                     //BGM管理番号
    AudioClip seClip;
    public Text StratBotn;
    public Text Score000;
    // Start is called before the first frame update
    void Start()
    {
        Score000.text= GameDirector.kyori.ToString("D6");
        string[] bgmName =
        {
            "Audio/BGM/bgm_maoudamashii_8bit29", //bgmName[0]
            "Audio/BGM/bgm_maoudamashii_8bit10", //bgmName[1]
            "Audio/BGM/bgm_maoudamashii_8bit11"  //bgmName[2]
        };
        //オーディオクリップを読み込む
        for(int i = 0;i<MAX_BGM;i++)
        {
            bgmClip[i] = Resources.Load<AudioClip>(bgmName[i]);
        }
        //BGMの再生
        audioSource=GetComponent<AudioSource>();
        audioSource.clip = bgmClip[bgmNumder];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void StratBoton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
