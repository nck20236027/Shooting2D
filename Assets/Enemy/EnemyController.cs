using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;//�ړ�����
    float speed = 5;�@�@�@�@�@ //�ړ����x
    Transform player;�@�@�@�@�@//�v���C���[���ǂ��ɂ��邩�̈ʒu���̕ۑ�
    public EzplosionContlloer expol;
    public GameObject tama;    //�e�Ăяo���@�G��
    float seisei = 2f;            //�������ԂP�b�v
    float delta;              //����������
    int random = 0;
    void Start()
       
    {
        //����4�b
        Destroy(gameObject,5f);
        //�v���C���[�̕����Ɉړ��@
        //player = GameObject.Find("player").transform;
        random = Random.Range(0, 10);


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
        if (random <= 3)
        {
            dir.y = Mathf.Sin(Time.time * 5f);
        }
        //�v���C���[�̕����Ɉړ�������
        //dir=player.position -transform.position;

        //���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;

        delta += Time.deltaTime;
        if(delta > seisei)
        {
            delta = 0;
            GameObject go = Instantiate(tama);
            go.transform.position=transform.position;  
            
        }

    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        //�������̃I�u�W�F�N�g�Əd�Ȃ��������
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
           
            
            //�������ɃG�t�F�N�g���o��
            Instantiate(expol, transform.position, Quaternion.identity);
            GameDirector.kyori -= 1000;

        }
        if (collision.gameObject.tag == "Shot")
        {
            Destroy(gameObject);
            //�������ɃG�t�F�N�g���o��
            Instantiate(expol, transform.position, Quaternion.identity);

        }
    }
   
}
