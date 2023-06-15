using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreContlloer : MonoBehaviour
{
    public Text Score000;
    // Start is called before the first frame update
    void Start()
    {
        Score000.text= GameDirector.kyori.ToString("D6");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("GameScene");
        }
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
