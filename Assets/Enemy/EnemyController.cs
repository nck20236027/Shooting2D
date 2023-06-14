using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;//�ړ�����
    float speed = 5;�@�@�@�@�@ //�ړ����x
    Transform player;�@�@�@�@�@//�v���C���[���ǂ��ɂ��邩�̈ʒu���̕ۑ�
    void Start()
    {
        //����4�b
        Destroy(gameObject,4f);
        //�v���C���[�̕����Ɉړ��@
        player = GameObject.Find("player").transform;
    }

    void Update()
    {
        //�ړ�����������
        dir = Vector3.left;

        //���Ɍ��؂ꂽ��E����o��
        if(transform.position.x<-9f)
        {
            Vector3 pos = transform.position;
            pos.x = 9f;
            transform.position = pos;
        }
        //Y�����̈ړ�
        //-1 <= Mathf.Sin(Time.time*5f) <=1
        dir.y = Mathf.Sin(Time.time * 5f);
        //�v���C���[�̕����Ɉړ�������
        dir=player.position -transform.position;

        //���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;

        

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //�������Ԃ��P�O�b���炷
        GameDirector.lastTime -= 10f;
        //�������̃I�u�W�F�N�g�Əd�Ȃ��������
        Destroy(gameObject);

    }
}
