using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamaContoller : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    GameObject player;
    float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        dir = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir *speed* Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.tag == "Player")
        {
            GameDirector.kyori -= 500;
            Destroy(gameObject);
        }
    }
}
