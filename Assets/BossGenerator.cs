using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    public GameObject BossPre;//�G�̃v���n�u��ۑ�����ϐ�
    float delta;               //�o�ߎ��Ԍv�Z�p
    float span;                //�G���o�����o�i�b�j

    void Start()
    {
        delta = 0;
        span = 45f;           //��������
    }

    // Update is called once per frame
    void Update()
    {
        //�o�ߎ��Ԃ����Z
        delta += Time.deltaTime;

        if (delta > span)
        {
            GameObject go = Instantiate(BossPre);
            
            go.transform.position = new Vector3(8, 0, 0);

            //���Ԍo�߂�ۑ����Ă���ϐ����O�ɃN���A����
            delta = 0;


            //�G���o���Ԋu�����X�ɒZ������
            //span -= (span >= 0.5f) ? 0.01f : 0f;

        }
    }

}
