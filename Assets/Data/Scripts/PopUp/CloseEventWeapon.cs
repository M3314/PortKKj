using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEventWeapon : MonoBehaviour
{

    public GameObject Selectweapons;
    // Start is called before the first frame update
    public void LoadPopUp()
    {
        bool isActive = Selectweapons.activeSelf;

        Selectweapons.SetActive(!isActive);
    }
}
