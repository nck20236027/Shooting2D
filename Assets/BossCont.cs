using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCont : MonoBehaviour
{
    Vector3 dir = Vector3.zero;//�ړ�����
    float speed = 5;      //�ړ����x
    public EzplosionContlloer expol; //�����̃G�t�F�N�g
    int EnemyHp = 50;                //�{�Xhp
    float time = 0;                    //���o����
    float sporn = 3;                    //���o���ԂQ
    public GameObject tama;    //�e�Ăяo���@�G��
    float seisei = 1f;            //��������3�b�v
    float delta;              //����������


    AudioClip seClip;          //�I�[�f�B�I�N���b�v�ۑ�
    Vector3 sePos;             //���ʉ���炷�ʒu

    // Start is called before the first frame update
    void Start()
    {
        

        sePos = GameObject.Find("Main Camera").transform.position;
        seClip = Resources.Load<AudioClip>("Audio/SE/bomb");

    }

    void Update()
    {
        transform.position += dir.normalized * speed * Time.deltaTime;

        //�e��ł�
        delta += Time.deltaTime;
        if (delta > seisei)
        {
            delta = 0;
            GameObject go = Instantiate(tama);
            go.transform.position = transform.position;

        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameDirector.hp -= 10f;
            GameDirector.kyori -= 1000;
            ////�������ɃG�t�F�N�g���o��
            //Instantiate(expol, transform.position, Quaternion.identity);

        }
        if (collision.gameObject.tag == "Shot")
        {
            EnemyHp--;
            if (EnemyHp < 0)
            {

                GameDirector.kyori += 200;

                AudioSource.PlayClipAtPoint(seClip, sePos);
                //�������ɃG�t�F�N�g���o��
                Instantiate(expol, transform.position, Quaternion.identity);
                SceneManager.LoadScene("TorSene");
              
                Destroy(gameObject);
                

                
            }
        }
    }
}


