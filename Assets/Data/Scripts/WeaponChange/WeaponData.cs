using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;
using System;
using TMPro;

public enum WEAPONTYPE
{
    SWORD, SYNTHE, PISTOL, SHOTGUN
}

public class WeaponData : MonoBehaviour
{
    [SerializeField] public WEAPONTYPE myWeaponType = WEAPONTYPE.SWORD;
    [SerializeField] public PlayerWeaponData[] myData;
    public int[] weaponmyLevel;
    private static WeaponData weaponData_instance = null;
    public TMP_Text UpgradeLevels;

    public WeaponPopup weaponpopups;

    public int GetPrice(int lv)
    {
        return myData[(int)myWeaponType].GetPrice(lv);
    }

    public int GetPrice()
    {
        return weaponmyLevel[(int)myWeaponType] ==
         myData[(int)myWeaponType].MaxLevel ? 0 : myData[(int)myWeaponType].GetPrice(weaponmyLevel[(int)myWeaponType]);
    }

    public void OnUpgrade()
    {
        weaponmyLevel[(int)myWeaponType] += 1;
        UpgradeLevels = GameObject.Find("Upgrade Level").GetComponent<TMP_Text>();
        UpgradeLevels.text = weaponmyLevel[(int)myWeaponType].ToString();
        DontDestroyobject.instance.weaponlevelinfo = weaponmyLevel[(int)myWeaponType];
    }

    public void Awake()
    {
        if (weaponData_instance != this)
        {
           DontDestroyOnLoad(gameObject);
        }
        else
        {
           Destroy(gameObject);
        }
    }


    private void Start()
    {
        weaponmyLevel[(int)myWeaponType] = 1;
    }
    public void ChangeStateWeaponState(WEAPONTYPE w)
    {
        weaponpopups = GameObject.Find("WeaponPopup").GetComponent<WeaponPopup>();
        if (myWeaponType == w) return;
        myWeaponType = w;
        switch (myWeaponType)
        {
            case WEAPONTYPE.SWORD:
                Debug.Log("칼을 선택했습니다.");
            //    DontDestroyobject.instance.WeaponDatas = (int)WEAPONTYPE.SWORD;
                if (weaponmyLevel[(int)myWeaponType] > 0)
                {
                    weaponpopups.upgradeBtn.gameObject.SetActive(true);
                }
                else
                {
                    weaponpopups.upgradeBtn.gameObject.SetActive(false);
                }
                if (weaponmyLevel[(int)myWeaponType] >= 5)
                {
                    weaponpopups.upgradeBtn.gameObject.SetActive(false);
                }
                break;
            case WEAPONTYPE.SYNTHE:
                Debug.Log("낫을 선택했습니다.");
                if (weaponmyLevel[(int)myWeaponType] > 0)
                {
                    weaponpopups.upgradeBtn.gameObject.SetActive(true);
                }
                else
                {
                    weaponpopups.upgradeBtn.gameObject.SetActive(false);
                }
                if (weaponmyLevel[(int)myWeaponType] >= 5)
                {
                    weaponpopups.upgradeBtn.gameObject.SetActive(false);
                }
                break;
            case WEAPONTYPE.PISTOL:      
                Debug.Log("권총을 선택했습니다.");
                if (weaponmyLevel[(int)myWeaponType] > 0)
                {
                    weaponpopups.upgradeBtn.gameObject.SetActive(true);
                }
                else
                {
                    weaponpopups.upgradeBtn.gameObject.SetActive(false);
                }
                if (weaponmyLevel[(int)myWeaponType] >= 5)
                {
                    weaponpopups.upgradeBtn.gameObject.SetActive(false);
                }
                break;
            case WEAPONTYPE.SHOTGUN:
      
                Debug.Log("샷건을 선택했습니다.");
                if (weaponmyLevel[(int)myWeaponType] > 0)
                {
                    weaponpopups.upgradeBtn.gameObject.SetActive(true);
                }
                else
                {
                    weaponpopups.upgradeBtn.gameObject.SetActive(false);
                }

                if (weaponmyLevel[(int)myWeaponType] >= 5)
                {
                    weaponpopups.upgradeBtn.gameObject.SetActive(false);
                }
                break;
        }

    }
}
