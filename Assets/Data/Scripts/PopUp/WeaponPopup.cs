using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPopup : MonoBehaviour
{
    public Button upgradeBtn;
    public GameObject WeaponpopupActive;

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
        bool isActive = WeaponpopupActive.activeSelf;

        WeaponpopupActive.SetActive(!isActive);
    }
}
