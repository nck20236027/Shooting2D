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
    int EnemyHp = 2;
    int BOSSEnemyHP = 10;
    void Start()
       
    {
        //����4�b
        Destroy(gameObject,5f);
        //�v���C���[�̕����Ɉړ��@
        //player = GameObject.Find("player").transform;
        random = Random.Range(0, 100);


    }

    void Update()
    {
        //�ړ�����������
        dir = Vector3.left;
        //Y�����̈ړ�
        //-1 <= Mathf.Sin(Time.time*5f) <=1
        //if(random <=1)
        //{
        //    �g�����X�t�H�[��Score�@�傫����ύX
        //    
        //    if(���񂾂�)
        //       {kyori+=3000}
        //}
        if (random <= 30)
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
           
            GameDirector.kyori -= 1000;
            
            //�������ɃG�t�F�N�g���o��
            Instantiate(expol, transform.position, Quaternion.identity);

        }
        if (collision.gameObject.tag == "Shot")
        {
            EnemyHp--;
            if(EnemyHp < 0) { 
                EnemyHp = 2;
                GameDirector.kyori += 200;
                
                //�������ɃG�t�F�N�g���o��
                Instantiate(expol, transform.position, Quaternion.identity);
                
                Destroy(gameObject);
            }
        }
    }
   
}
