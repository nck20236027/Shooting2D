using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EzplosionContlloer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       //演出が終わったら削除
       ParticleSystem expol =GetComponent<ParticleSystem>();
        Destroy(gameObject, expol.main.duration);
    }

}
