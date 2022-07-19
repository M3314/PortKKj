using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class SelectCha : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadChaSelect()
    {
        SceneLoad.inst.LoadingScene(4); //메뉴로 돌아가게함.

    }
}
