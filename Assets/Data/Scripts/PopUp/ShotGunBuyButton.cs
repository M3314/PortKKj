using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShotGunBuyButton : InvenMain
{
    public Button weaponBuyButton;
    public Button myShotGunButton;
    public GameObject WeaponData;
    public TMP_Text GoldText;
    public PlayerWeaponData WeaponBuyPrices;

    // Start is called before the first frame update
    void Start()
    {
        weaponBuyButton.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("BuyShotGun") == 1) //값을 저장해서 사용을 한다.
        {
            myShotGunButton.interactable = true;
            weaponBuyButton.gameObject.SetActive(false);
            Gold = Gold - WeaponBuyPrices.WeaponBuyPrices;
            GoldText.text = Gold.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("BuyShotGun") == 1)
        {
            myShotGunButton.interactable = true;
            weaponBuyButton.gameObject.SetActive(false);
        }
    }
    public void ShotGunButtonSetActiveTrue()
    {
        PlayerPrefs.SetInt("BuyShotGun", 1);
        WeaponData.GetComponent<WeaponData>().ChangeStateWeaponState(WEAPONTYPE.SHOTGUN);
        myShotGunButton.interactable = true;
        weaponBuyButton.gameObject.SetActive(false);
        Debug.Log("15원을 구매하고 사신 낫을 구매하였습니다. 한번 더 누르면 장착이 가능합니다.");

        Gold = Gold - WeaponBuyPrices.WeaponBuyPrices;
        GoldText.text = Gold.ToString();
    }
}
