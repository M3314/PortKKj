using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BuyButton : InvenMain
{
    public InvenMain GoldInven;
    public Button weaponBuyButton;
    public Button mypistolButton;
    public GameObject WeaponData;
    public TMP_Text GoldText;
    public PlayerWeaponData WeaponBuyPrices;
    // Start is called before the first frame update
    void Start()
    {
        weaponBuyButton.gameObject.SetActive(false);
        
        if (PlayerPrefs.GetInt("BuyWeaponpistol") == 1)
        {
            Gold = GoldInven.Gold - WeaponBuyPrices.WeaponBuyPrices;
            GoldText.text = Gold.ToString();
            mypistolButton.interactable = true;
            weaponBuyButton.gameObject.SetActive(false);
            GoldInven.Gold = PlayerPrefs.GetInt("Gold");
      //      PlayerPrefs.SetInt("Gold", Gold);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("BuyWeaponpistol") == 1)
        {
            mypistolButton.interactable = true;
            weaponBuyButton.gameObject.SetActive(false);
        }
    }

    public void PistolButtonSetActiveTrue()
    {
        PlayerPrefs.SetInt("BuyWeaponpistol", 1);
        WeaponData.GetComponent<WeaponData>().ChangeStateWeaponState(WEAPONTYPE.PISTOL);
        mypistolButton.interactable = true;
        weaponBuyButton.gameObject.SetActive(false);
        Debug.Log("7원을 구매하고 사신 낫을 구매하였습니다. 한번 더 누르면 장착이 가능합니다.");

        Gold = DontDestroyobject.instance.GoldInfo;
        Gold = Gold - WeaponBuyPrices.WeaponBuyPrices;
        GoldText.text = Gold.ToString();
        PlayerPrefs.SetInt("Gold", Gold);
    }

}
