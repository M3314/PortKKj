using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class equipsPopup : MonoBehaviour
{
    public GameObject PopupActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PopupLayerOnActive()
    {
        bool isActive = PopupActive.activeSelf;

        PopupActive.SetActive(!isActive);


    }
    

}
