using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    /*
    private void Awake()
    {
        if(PlayerPrefs.GetInt("KKJgameFirstStart") == 0)
        {
            GoldClass.gold = 350;
            PlayerPrefs.SetInt("KKJgameFirstStart", 1);
        }
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void LoadPlayScene()
    {
        SceneLoad.inst.LoadingScene(1); //StartGame
    }
}
