using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotContlloer : MonoBehaviour
{
    float speed = 7f;//弾の発射スピード
    


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
       
        if(transform.position.x >9f)
        { Destroy(gameObject); }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

        }
    }
}
