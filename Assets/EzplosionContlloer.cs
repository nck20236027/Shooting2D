using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EzplosionContlloer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       //‰‰o‚ªI‚í‚Á‚½‚çíœ
       ParticleSystem expol =GetComponent<ParticleSystem>();
        Destroy(gameObject, expol.main.duration);
    }

}
