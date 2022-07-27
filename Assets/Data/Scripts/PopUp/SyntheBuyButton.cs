using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class SyntheBuyButton : InvenMain
{
    public Button synthebuyButton;
    public Button mySyntheButton;
    public Button PistolBuyButton;
    public GameObject WeaponData;
    public PlayerWeaponData WeaponBuyPrices;
    public TMP_Text GoldText;

    void Start()
    {
   //     PlayerPrefs.SetInt("BuySynthe", 0); //테스트용임 암튼 테스트용임 
        synthebuyButton.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("BuySynthe") == 1) //값을 저장해서 사용을 한다.
        {
            mySyntheButton.interactable = true;
            synthebuyButton.gameObject.SetActive(false);
        }
    }

    public void SyntheButtonSetActiveTrue() //Buy버튼을 누르면 생기는일 
    {
        PlayerPrefs.SetInt("BuySynthe", 1);
        mySyntheButton.interactable = true;
        PistolBuyButton.gameObject.SetActive(false);
        synthebuyButton.gameObject.SetActive(false);
        Debug.Log("10원을 구매하고 사신 낫을 구매하였습니다. 한번 더 누르면 장착이 가능합니다.");

        //     WeaponData.GetComponent<WeaponData>().ChangeStateWeaponState(WEAPONTYPE.SYNTHE);
        Gold = Gold - WeaponBuyPrices.WeaponBuyPrices;
        GoldText.text = Gold.ToString();
    }

}


