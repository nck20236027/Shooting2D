using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedContoller : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        //‚T•bŒã‚«‚¦‚é
        Destroy(gameObject, 5f);
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
            Destroy(gameObject);
            
        }
    }
}
