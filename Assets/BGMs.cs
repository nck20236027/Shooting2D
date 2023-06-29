using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMs : MonoBehaviour
{
    AudioSource audioSource;
    const int MAX_BGM = 3;
    AudioClip[] bgmClip = new AudioClip[MAX_BGM];//オーディオクリップ
    int bgmNumder = 0;                     //BGM管理番号
    AudioClip seClip;
    void Start()
    {
        string[] bgmName =
         {
            "Audio/BGM/bgm_maoudamashii_8bit08", //bgmName[0]
            "Audio/BGM/bgm_maoudamashii_8bit10", //bgmName[1]
            "Audio/BGM/bgm_maoudamashii_8bit11"  //bgmName[2]
        };
        //オーディオクリップを読み込む
        for (int i = 0; i < MAX_BGM; i++)
        {
            bgmClip[i] = Resources.Load<AudioClip>(bgmName[i]);
        }
        //BGMの再生
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmClip[bgmNumder];
        audioSource.Play();
    }
    
}
