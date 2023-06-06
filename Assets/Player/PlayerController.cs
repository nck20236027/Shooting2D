using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir =Vector3.zero; //�ړ�������ۑ�����ϐ�

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5;
        
        //�ړ��������Z�b�g
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;  //dir���̕ϐ��̌���.normalized������Ǝ΂߈ړ��̃X�s�[�h��

        //��ʓ��ړ�����
        Vector3 pos = transform.position; //�ϐ�pos
        pos.x = Mathf.Clamp(pos.x,-9f, 9f);�@//x.y�̉�ʐ������W�ݒ�
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;�@�@�@�@�@//transform.position���ݒn�̍��W��pos������?


    }
}
