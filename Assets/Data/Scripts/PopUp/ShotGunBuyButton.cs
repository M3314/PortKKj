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
        if (PlayerPrefs.GetInt("BuyShotGun") == 1) //���� �����ؼ� ����� �Ѵ�.
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
        Debug.Log("15���� �����ϰ� ��� ���� �����Ͽ����ϴ�. �ѹ� �� ������ ������ �����մϴ�.");

        Gold = Gold - WeaponBuyPrices.WeaponBuyPrices;
        GoldText.text = Gold.ToString();
    }
}
