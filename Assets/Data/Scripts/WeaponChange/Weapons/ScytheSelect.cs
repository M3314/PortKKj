using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScytheSelect : MonoBehaviour, IPointerClickHandler
{
    public Button myButton;
    public Button Buttonbuy;
    public Button PistolbuyButton;
    public Button ShotGunBuyButton;
    float interval = 0.25f;
    float doubleClickTime = -1.0f;
    bool isDoubleClicked = false;
    public TMPro.TMP_Text ScytheName;
    public TMPro.TMP_Text ScytheExplain;
    public TMPro.TMP_Text ScytheGoldPrice;
    public TMPro.TMP_Text ScytheUpgradePrice;
    // Start is called before the first frame update

    public GameObject PlayMainScript = null;

    void Start()
    {
        Texture();
        Awake();
    }

    void Awake()
    {
        if(myButton.interactable == true)
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void Texture()
    {
     //   myButton.interactable = false;
        ScytheName.text = "Synthe";
        ScytheExplain.text = "����� ���� ���Դϴ�. ����� ��Ծ����� �ƴϸ� ������ ������� ����(?)�� �ؼ� ���°����� �𸣰ڱ���. ��ó�� �Һи��� ���Դϴ�.";
        ScytheGoldPrice.text = "G : 50";
        ScytheUpgradePrice.text = "Upgrade : 70";
    }

    // Update is called once per frame
    void Update()
    {
 //       myButton.interactable = true;
    }
    public void textSetActive()
    {
        ScytheName.text = "Synthe";
        ScytheExplain.text = "����� ���� ���Դϴ�. ����� ��Ծ����� �ƴϸ� ������ ������� ����(?)�� �ؼ� ���°����� �𸣰ڱ���. ��ó�� �Һи��� ���Դϴ�.";
        ScytheGoldPrice.text = "G : 50";
        ScytheUpgradePrice.text = "Upgrade : 70";

        PlayMainScript.GetComponent<WeaponData>().ChangeStateWeaponState(WEAPONTYPE.SYNTHE);
    //    GameObject.Find("InvenMain").GetComponent<InvenMain>().WeaponSyntheUpgradeMenu();
    }

    public void OnPointerClick(PointerEventData eventData) //����Ŭ���� 
    {
        if (this.GetComponent<Button>().interactable) return;
        if ((Time.time - doubleClickTime) < interval)
        {
            Texture();
            isDoubleClicked = true;
            doubleClickTime = -1.0f;

            Debug.Log("Selecting Synthe");
            Buttonbuy.gameObject.SetActive(true);
            PistolbuyButton.gameObject.SetActive(false);

      //      ShotGunBuyButton.gameObject.SetActive(false);
        }
        else
        {
            isDoubleClicked = false;
            doubleClickTime = Time.time;
        }

    }

}

