using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class CloseEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SelectEquips;

    // Start is called before the first frame update


    public void LoadPopUp()
    {
        bool isActive = SelectEquips.activeSelf;

        SelectEquips.SetActive(!isActive);
    }
}
