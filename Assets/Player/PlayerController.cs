using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir =Vector3.zero; //�ړ�������ۑ�����ϐ�

    Animator anim;  //�A�j���[�^�[�ƃA�j���[�V�������ԈႦ�Ȃ��悤��   

    void Start()
    {
        //�A�j���[�^�[�R���|�[�l���g�̏���ۑ�
        anim= GetComponent<Animator>();  //�Q�b�g�R���|�[�l���g�̓X�^�[�g���\�b�h�ň�񂾂��擾����΂悢�̂�Strat�ɓ����Ƃ悢


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

        //�A�j���[�V�����ݒ�
        if(dir.y==0)
        {
            //�A�j���[�V�����N���b�v�uPlayer�v���Đ�
            anim.Play("Player");
        }
        else if (dir.y==1)
        {
            anim.Play("PlayerL");
        }
        else if (dir.y==-1)
        {
            anim.Play("PlayerR");
        }

    }
}
