using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUpgradePopup : MonoBehaviour
{
    public GameObject UpgradePopup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPopup()
    {
        bool isActive = UpgradePopup.activeSelf;

        UpgradePopup.SetActive(!isActive);
    }
}
