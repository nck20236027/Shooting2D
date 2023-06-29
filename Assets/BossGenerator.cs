using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    public GameObject BossPre;//“G‚ÌƒvƒŒƒnƒu‚ð•Û‘¶‚·‚é•Ï”
    float delta;               //Œo‰ßŽžŠÔŒvŽZ—p
    float span;                //“G‚ðo‚·Š´Šoi•bj

    void Start()
    {
        delta = 0;
        span = 45f;           //¶¬ŽžŠÔ
    }

    // Update is called once per frame
    void Update()
    {
        //Œo‰ßŽžŠÔ‚ð‰ÁŽZ
        delta += Time.deltaTime;

        if (delta > span)
        {
            GameObject go = Instantiate(BossPre);
            
            go.transform.position = new Vector3(8, 0, 0);

            //ŽžŠÔŒo‰ß‚ð•Û‘¶‚µ‚Ä‚¢‚é•Ï”‚ð‚O‚ÉƒNƒŠƒA‚·‚é
            delta = 0;


            //“G‚ðo‚·ŠÔŠu‚ð™X‚É’Z‚­‚·‚é
            //span -= (span >= 0.5f) ? 0.01f : 0f;

        }
    }

}
