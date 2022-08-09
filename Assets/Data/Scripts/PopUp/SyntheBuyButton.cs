using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class SyntheBuyButton : InvenMain
{
    public InvenMain GoldInven;
    public Button synthebuyButton;
    public Button mySyntheButton;
    public Button PistolBuyButton;
    public GameObject WeaponData;
    public PlayerWeaponData WeaponBuyPrices;
    public TMP_Text GoldText;

    void Start()
    {
        synthebuyButton.gameObject.SetActive(false);
        mySyntheButton.interactable = false;
    

        if (PlayerPrefs.GetInt("BuyWeaponsynthe") == 1) //값을 저장해서 사용을 한다.
        {
            mySyntheButton.interactable = true;
            synthebuyButton.gameObject.SetActive(false);
            //      Gold = GoldInven.Gold - WeaponBuyPrices.WeaponBuyPrices;
            GoldText.text = Gold.ToString();
            PlayerPrefs.GetInt("KKJgameGold");
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
        if (PlayerPrefs.GetInt("BuyWeaponsynthe") == 1) //값을 저장해서 사용을 한다.
       {
            mySyntheButton.interactable = true;
            synthebuyButton.gameObject.SetActive(false);
       }
        
    }

    public void SyntheButtonSetActiveTrue() //Buy버튼을 누르면 생기는일 
    {
        PlayerPrefs.SetInt("BuyWeaponsynthe", 1);
        mySyntheButton.interactable = true;
        PistolBuyButton.gameObject.SetActive(false);
        synthebuyButton.gameObject.SetActive(false);
        Debug.Log("10원을 구매하고 사신 낫을 구매하였습니다. 한번 더 누르면 장착이 가능합니다.");

        //     WeaponData.GetComponent<WeaponData>().ChangeStateWeaponState(WEAPONTYPE.SYNTHE);
        Gold = Gold - WeaponBuyPrices.WeaponBuyPrices;
        GoldText.text = Gold.ToString();
        Gold = GoldClass.gold;
        PlayerPrefs.SetInt("KKJgameGold", Gold);
    }

}


