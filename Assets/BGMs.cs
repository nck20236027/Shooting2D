using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMs : MonoBehaviour
{
    AudioSource audioSource;
    const int MAX_BGM = 3;
    AudioClip[] bgmClip = new AudioClip[MAX_BGM];//�I�[�f�B�I�N���b�v
    int bgmNumder = 0;                     //BGM�Ǘ��ԍ�
    AudioClip seClip;
    void Start()
    {
        string[] bgmName =
         {
            "Audio/BGM/bgm_maoudamashii_8bit08", //bgmName[0]
            "Audio/BGM/bgm_maoudamashii_8bit10", //bgmName[1]
            "Audio/BGM/bgm_maoudamashii_8bit11"  //bgmName[2]
        };
        //�I�[�f�B�I�N���b�v��ǂݍ���
        for (int i = 0; i < MAX_BGM; i++)
        {
            bgmClip[i] = Resources.Load<AudioClip>(bgmName[i]);
        }
        //BGM�̍Đ�
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgmClip[bgmNumder];
        audioSource.Play();
    }
    
}
