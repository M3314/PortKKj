using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PopupControl : MonoBehaviour
{
    public GameObject Notouch;
    public PopupControl myPopupControl = null;
    // Start is called before the first frame update

    void Update()
    {

    }
    public void CloseLastPopup()
    {
        Popup[] list = GetComponentsInChildren<Popup>();
        if (list.Length > 0) list[list.Length - 1].OnClose();
    }



    public void AddPopup()
    {
        Notouch.SetActive(true);
        Notouch.transform.SetAsLastSibling();
        GameObject obj = Instantiate(Resources.Load("UI/PopUp"), this.transform) as GameObject;
        obj.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0.0f);
        obj.GetComponent<Popup>().Initialize(
            () =>
            {
                int Index = Notouch.transform.GetSiblingIndex();
                if (Index == 0)
                {
                    Notouch.SetActive(false);
                }
                else
                {
                    Notouch.transform.SetSiblingIndex(Index - 1);
                }
            });

    }
}







