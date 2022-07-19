using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
 public  void MoveToOtherScene(GameObject obj, int sceneNum)
    {
        Scene scene = SceneManager.GetSceneByBuildIndex(sceneNum);
        SceneManager.MoveGameObjectToScene(obj, scene);
    }
}
