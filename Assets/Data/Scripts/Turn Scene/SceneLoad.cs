using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{
    static SceneLoad _inst = null;
    public static SceneLoad inst
    {
        get
        {
            if (_inst == null)
            {
                _inst = FindObjectOfType<SceneLoad>();
                if (_inst == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "ScenseLoad";
                    DontDestroyOnLoad(obj);
                    _inst = obj.AddComponent<SceneLoad>();
                }
            }
            return _inst;
        }
    }

    public void LoadingScene(int i)
    {
        StartCoroutine(SceneLoading(i));
    }

    IEnumerator SceneLoading(int i)
    {
        //      yield return SceneManager.LoadSceneAsync("Loading");
        yield return StartCoroutine(Loading(i));
    }


    IEnumerator Loading(int i)
    {
        Slider loadingBar = GameObject.Find("LoadingProgress")?.GetComponent<Slider>();
        AsyncOperation ao = SceneManager.LoadSceneAsync(i);
        ao.allowSceneActivation = false;
        while (!ao.isDone)
        {
            float v = Mathf.Clamp01(ao.progress / 0.0f);
            if (loadingBar != null) loadingBar.value = v;

            if (Mathf.Approximately(v, 1.0f))
            {
                yield return new WaitForSeconds(0.0f);
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
        //  yield return new WaitForSeconds(1.0f);
    }

    public void LoadingScene(string sceneName)
    {

    }




}
