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
    

        if (PlayerPrefs.GetInt("BuyWeaponsynthe") == 1) //���� �����ؼ� ����� �Ѵ�.
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
        
        if (PlayerPrefs.GetInt("BuyWeaponsynthe") == 1) //���� �����ؼ� ����� �Ѵ�.
       {
            mySyntheButton.interactable = true;
            synthebuyButton.gameObject.SetActive(false);
       }
        
    }

    public void SyntheButtonSetActiveTrue() //Buy��ư�� ������ ������� 
    {
        PlayerPrefs.SetInt("BuyWeaponsynthe", 1);
        mySyntheButton.interactable = true;
        PistolBuyButton.gameObject.SetActive(false);
        synthebuyButton.gameObject.SetActive(false);
        Debug.Log("10���� �����ϰ� ��� ���� �����Ͽ����ϴ�. �ѹ� �� ������ ������ �����մϴ�.");

        //     WeaponData.GetComponent<WeaponData>().ChangeStateWeaponState(WEAPONTYPE.SYNTHE);
        Gold = Gold - WeaponBuyPrices.WeaponBuyPrices;
        GoldText.text = Gold.ToString();
        Gold = GoldClass.gold;
        PlayerPrefs.SetInt("KKJgameGold", Gold);
    }

}


