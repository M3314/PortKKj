using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StagePopup : MonoBehaviour
{

    public TMPro.TMP_Text myTitle = null;
    public TMPro.TMP_Text myContent = null;
    public event UnityAction CloseAct = null;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(string Title, string Content, UnityAction Act)
    {
        myTitle.text = Title;
        myContent.text = Content;
        CloseAct += Act;
    }

    public void OnClose()
    {
        CloseAct?.Invoke();
        Destroy(this.gameObject);
        Time.timeScale = 1.0f;
    }
}
