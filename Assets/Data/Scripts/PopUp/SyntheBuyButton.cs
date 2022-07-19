using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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
        synthebuyButton.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void SyntheButtonSetActiveTrue() //Buy��ư�� ������ ������� 
    {
        mySyntheButton.interactable = true;
        PistolBuyButton.gameObject.SetActive(false);
        synthebuyButton.gameObject.SetActive(false);
        Debug.Log("10���� �����ϰ� ��� ���� �����Ͽ����ϴ�. �ѹ� �� ������ ������ �����մϴ�.");

        //     WeaponData.GetComponent<WeaponData>().ChangeStateWeaponState(WEAPONTYPE.SYNTHE);
        Gold = Gold - WeaponBuyPrices.WeaponBuyPrices;
        GoldText.text = Gold.ToString();


    }

}


