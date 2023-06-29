using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedContoller : MonoBehaviour
{
    AudioSource audioSource;   //�I�[�f�B�I�\�[�X�R���|�[�l���g�̏����擾
    AudioClip seClip;          //�I�[�f�B�I�N���b�v�ۑ�
    Vector3 sePos;             //���ʉ���炷�ʒu
    Vector3 dir = Vector3.zero;
    float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        //�T�b�カ����
        Destroy(gameObject, 5f);
        //���C���J�����̈ʒu��ۑ�
        sePos = GameObject.Find("Main Camera").transform.position;
        seClip = Resources.Load<AudioClip>("Audio/SE/decision49");

    }

    // Update is called once per frame
    void Update()
    {
        dir = Vector3.down;
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(seClip, sePos);
            Destroy(gameObject);
        }
    }
}
