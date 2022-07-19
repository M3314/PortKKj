using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupResume : MonoBehaviour
{

    public GameObject ResumeGame;
    // Start is called before the first frame update
public void ResumeGameStart()
    {
        bool isActive = ResumeGame.activeSelf;

        ResumeGame.SetActive(!isActive);
    }
}
