using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ShotGunSelect : MonoBehaviour, IPointerClickHandler
{
    float interval = 0.25f;
    float doubleClickTime = -1.0f;
    bool isDoubleClicked = false;
    public Button myShotGunButton;
    public TMPro.TMP_Text ShotGunName;
    public TMPro.TMP_Text ShotGunExplain;
    public Button Buttonbuy;
    public Button SyntheButtonBuy;
    public Button PistolButtonBuy;

    public GameObject PlayMainScript = null;
    // Start is called before the first frame update
    void Start()
    {
        Texture();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Texture()
    {
        myShotGunButton.interactable = false;
        ShotGunName.text = "ShotGun";
        ShotGunExplain.text = "�����Դϴ�. ����Ÿ����� �ʴٸ� �ѹ濡 �������� ������?";
    }
    
    public void textSetActive()
    {
        ShotGunName.text = "ShotGun";
        ShotGunExplain.text = "�����Դϴ�. ����Ÿ����� �ʴٸ� �ѹ濡 �������� ������?";

        PlayMainScript.GetComponent<WeaponData>().ChangeStateWeaponState(WEAPONTYPE.SHOTGUN);
   //     GameObject.Find("PlayMain").GetComponent<MainPlay>().WeaponUpgradeMenu();
    }
    public void OnPointerClick(PointerEventData eventData) //����Ŭ���� 
    {
        if (this.GetComponent<Button>().interactable) return;
        if ((Time.time - doubleClickTime) < interval)
        {
            Texture();
            isDoubleClicked = true;
            doubleClickTime = -1.0f;

            Debug.Log("Selecting ShotGun");
            Buttonbuy.gameObject.SetActive(true);
            PistolButtonBuy.gameObject.SetActive(false);
            SyntheButtonBuy.gameObject.SetActive(false);
        }
        else
        {
            isDoubleClicked = false;
            doubleClickTime = Time.time;
        }
    }
}
