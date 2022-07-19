using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class SwordSelect : MonoBehaviour
{
    public Button myButton;
    public TMPro.TMP_Text SwordName;
    public TMPro.TMP_Text SwordExplain;
    public TMPro.TMP_Text SwordGoldPrice;
    public TMPro.TMP_Text SwordUpgradePrice;
    public Button Buttonbuy;

    public GameObject PlayMainScript;

    // Start is called before the first frame update
    void Start()
    {
        Texture();
    }

   void Texture()
    {
        myButton.interactable = true;
        SwordName.text = "Sword";
        SwordExplain.text = "�⺻ Į�Դϴ�. ���� ���ؽô� �ʱ⿡ ������� ������ �� ���� ������ ����մϴ�. ";
        SwordGoldPrice.text = " G : 0";
        SwordUpgradePrice.text = "Upgrade : +30";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void textSetActive()
    {
        SwordName.text = "Sword";
        SwordExplain.text = "�⺻ Į�Դϴ�. ���� ���ؽô� �ʱ⿡ ������� ������ �� ���� ������ ����մϴ�. ";
        SwordGoldPrice.text = " G : 20";
        SwordUpgradePrice.text = "Upgrade : +30";

        PlayMainScript.GetComponent<WeaponData>().ChangeStateWeaponState(WEAPONTYPE.SWORD);
    //    GameObject.Find("InvenMain").GetComponent<InvenMain>().WeaponUpgradeMenu();
    }

   

}
