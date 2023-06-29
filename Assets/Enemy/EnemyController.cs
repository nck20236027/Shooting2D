using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Vector3 dir = Vector3.zero;//�ړ�����
    float speed = 5;�@�@�@�@�@ //�ړ����x
    Transform player;�@�@�@�@�@//�v���C���[���ǂ��ɂ��邩�̈ʒu���̕ۑ�
    public EzplosionContlloer expol;
    public GameObject tama;    //�e�Ăяo���@�G��
    float seisei = 3f;            //��������3�b�v
    float delta;              //����������
    int random = 0;
    int EnemyHp = 2;
    AudioClip seClip;          //�I�[�f�B�I�N���b�v�ۑ�
    Vector3 sePos;             //���ʉ���炷�ʒu

    void Start()
    {
        //����4�b
        Destroy(gameObject,5f);
        //�G�̍s�������_����
        random = Random.Range(0, 100);
        //���C���J�����̈ʒu��ۑ�
        sePos= GameObject.Find("Main Camera").transform.position;
        seClip = Resources.Load<AudioClip>("Audio/SE/bomb");
    }

    void Update()
    {
        //�ړ�����������
        dir = Vector3.left;
        if (random <= 30)
        {
            dir.y = Mathf.Sin(Time.time * 5f);
        }

        //���ݒn�Ɉړ��ʂ����Z
        transform.position += dir.normalized * speed * Time.deltaTime;

        //�e��ł�
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
           
            GameDirector.hp -= 10f;
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

                AudioSource.PlayClipAtPoint(seClip, sePos);
                //�������ɃG�t�F�N�g���o��
                Instantiate(expol, transform.position, Quaternion.identity);
                
                Destroy(gameObject);
            }
        }
    }
   
}
