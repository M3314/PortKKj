using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ChagneChaInfo : MonoBehaviour
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
        SceneLoad.inst.LoadingScene(3); //메뉴로 돌아가게함.
    }
}
