using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EzplosionContlloer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       //���o���I�������폜
       ParticleSystem expol =GetComponent<ParticleSystem>();
        Destroy(gameObject, expol.main.duration);
    }

}
