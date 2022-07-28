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
        if (PlayerPrefs.GetInt("PistolBuy") == 1)
        {
            Gold = Gold - WeaponBuyPrices.WeaponBuyPrices;
            GoldText.text = Gold.ToString();
            mypistolButton.interactable = true;
            weaponBuyButton.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("PistolBuy") == 1)
        {
            mypistolButton.interactable = true;
            weaponBuyButton.gameObject.SetActive(false);
        }
    }

    public void PistolButtonSetActiveTrue()
    {
        PlayerPrefs.SetInt("PistolBuy", 1);
        WeaponData.GetComponent<WeaponData>().ChangeStateWeaponState(WEAPONTYPE.PISTOL);
        mypistolButton.interactable = true;
        weaponBuyButton.gameObject.SetActive(false);
        Debug.Log("7���� �����ϰ� ��� ���� �����Ͽ����ϴ�. �ѹ� �� ������ ������ �����մϴ�.");

        Gold = Gold - WeaponBuyPrices.WeaponBuyPrices;
        GoldText.text = Gold.ToString();
    }

}
