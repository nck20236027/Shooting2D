using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Text kyoriLabel;//������\������UI�]Text�I�u�W�F�N�g
    public Text ShotLevel;//�e�̋�����\������UI
    public static int kyori;           //������ۑ�����ϐ�
    

    float lastTime;    //�c�莞�Ԃ�ۑ�����ϐ�  public static
    public Image timeGauge; //�^�C���Q�[�W��\������UI
    
    void Start()
    {
        kyori = 0;
        lastTime = 100f; //�c�莞��100�b
       
    }

    void Update()
    {
        //�i�񂾋�����\��
        if (kyori < 0) kyori = 0;
        kyori++;
        kyoriLabel.text = kyori.ToString("D6") + ":Score";
        

        //�c�莞�Ԃ����炷����
        //lastTime -= Time.deltaTime;
        //timeGauge.fillAmount = lastTime / 100f;

        //�c�莞�Ԃ�0�ɂȂ����烊���[�h
        if(lastTime <0)
        {
            SceneManager.LoadScene("TorSene");
        }
        ShotLevel.text = "Level:"+PlayerController.power. ToString("D2");

    }
}
