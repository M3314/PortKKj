using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class InvenUI : MonoBehaviour
{

    private WeaponChange weaponchangee;

    // Start is called before the first frame update
    void Start()
    {
        weaponchangee = GameObject.Find("WeaponImage").GetComponent<WeaponChange>();
    }
  

    public void ButtonWeaponChange()
    {
        GameObject WeaponImage = EventSystem.current.currentSelectedGameObject;
        int tempBtnIndex = WeaponImage.transform.GetSiblingIndex();

        Debug.Log(WeaponImage + " : " + tempBtnIndex);
        weaponchangee.ChangeWeapon(tempBtnIndex);
        /*
        WeaponData.instance.WeaponsCurrents = (WeaponSword)tempBtnIndex;
        WeaponData.instance.WeaponSyntheCurrents = (WeaponSynthe)tempBtnIndex;
        WeaponData.instance.PistolsCurrents = (Pistols)tempBtnIndex;
        WeaponData.instance.WeaponsShotgunsCurrents = (WeaponShotguns)tempBtnIndex;
        */
        return;
    }

}
