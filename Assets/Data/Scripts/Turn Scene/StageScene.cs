using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageScene : MonoBehaviour
{
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
        SceneLoad.inst.LoadingScene(0); //메뉴로 돌아가게함.
    }
}
