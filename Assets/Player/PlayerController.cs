using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir =Vector3.zero; //�ړ�������ۑ�����ϐ�
    GameObject ShotPre;//�e�̃v���n�u��ۑ�����
    Animator anim;  //�A�j���[�^�[�ƃA�j���[�V�������ԈႦ�Ȃ��悤��   
    float ShotTimer;//�e�̔��ˊԊu����p
    int power = 0;  //�e�̃��x��
    
    

    void Start()
    {
        //�A�j���[�^�[�R���|�[�l���g�̏���ۑ�
        anim= GetComponent<Animator>();  //�Q�b�g�R���|�[�l���g�̓X�^�[�g���\�b�h�ň�񂾂��擾����΂悢�̂�Strat�ɓ����Ƃ悢
        //�e�̃v���n�u��ϐ��ɕۑ�����
        ShotPre = (GameObject)Resources.Load("Shot");

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
        //C�L�[�Œe�̃��x���A�b�v
        if(Input.GetKeyDown(KeyCode.C))
        {
            power = (power + 1) % 13;
        }
        //Z�L�[�ŋ�����
        ShotTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z) && ShotTimer > 0.3f)
        {
            for (int i = -power; i < power + 1; i++)
            {
                //�v���C���[�̌��ݒn��pos�ɕۑ�
                pos = transform.position;
                //�v���C���[�̉�]�p�x���擾
                Vector3 r = transform.rotation.eulerAngles + new Vector3(0, 15f * i, 0);
                Quaternion rot = Quaternion.Euler(r);

                //�e�𐶐�����ۂɁA�v���C���[�̈ʒu�Ɗp�x�����Z�b�g
                Instantiate(ShotPre,pos,rot);
            }
            ShotTimer = 0;
        }
    }

    
}
