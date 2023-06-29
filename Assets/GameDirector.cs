using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel; //������\������UI�]Text�I�u�W�F�N�g
    public Text ShotLevel;  //�e�̋�����\������UI

    public static int kyori;           //������ۑ�����ϐ�
    public static float hp;

    float lastTime;    //�c�莞�Ԃ�ۑ�����ϐ�  public static
    public Image GaugeLavel; //�Q�[�W��\������UI
    
    
    void Start()
    {
        kyori = 0;
        lastTime = 100f; //�c�莞��100�b
        hp = 100f;
       
    }

    void Update()
    {

        GaugeLavel.fillAmount = hp / 100;
        hp = Mathf.Clamp(hp, 0, 100);

        //�i�񂾋�����\��
        if (kyori < 0) kyori = 0;
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + ":Score";
        

        //�c�莞�Ԃ����炷����
        //lastTime -= Time.deltaTime;
        //timeGauge.fillAmount = lastTime / 100f;

        //�c�莞�Ԃ�0�ɂȂ����烊���[�h
        if(hp == 0)
        {
            SceneManager.LoadScene("TorSene");
        }
        ShotLevel.text = "Level:"+PlayerController.power. ToString("D2");
    }
    
    
}
