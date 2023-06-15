using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotContlloer : MonoBehaviour
{
    float speed = 7f;//弾の発射スピード
    


    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject, 4f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed,0, 0) * Time.deltaTime;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            GameDirector.kyori += 200;
        }
    }
}
