using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BuyButton : InvenMain
{
    public Button weaponBuyButton;
    public Button mypistolButton;
    public GameObject WeaponData;
    public TMP_Text GoldText;
    public PlayerWeaponData WeaponBuyPrices;
    // Start is called before the first frame update
    void Start()
    {
        weaponBuyButton.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }


    public void PistolButtonSetActiveTrue()
    {
        WeaponData.GetComponent<WeaponData>().ChangeStateWeaponState(WEAPONTYPE.PISTOL);
        mypistolButton.interactable = true;
        weaponBuyButton.gameObject.SetActive(false);
        Debug.Log("7���� �����ϰ� ��� ���� �����Ͽ����ϴ�. �ѹ� �� ������ ������ �����մϴ�.");

        Gold = Gold - WeaponBuyPrices.WeaponBuyPrices;
        GoldText.text = Gold.ToString();
    }

}
