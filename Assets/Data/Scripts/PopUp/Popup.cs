using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public event UnityAction CloseAct = null;

    void Start()
    {
        Time.timeScale = 0.0f;
    }

    private void Update()
    {
    

    }
    public void Initialize( UnityAction Act)
    {
        CloseAct += Act;
    }

    public void OnClose()
    {
        CloseAct?.Invoke();
        Destroy(this.gameObject);
        Time.timeScale = 1.0f;
    }

}
