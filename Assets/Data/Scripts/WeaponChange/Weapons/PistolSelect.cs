using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PistolSelect : MonoBehaviour, IPointerClickHandler
{
    float interval = 0.25f;
    float doubleClickTime = -1.0f;
    bool isDoubleClicked = false;
    public Button mypistolButton;
    public TMPro.TMP_Text PistolName;
    public TMPro.TMP_Text PistolExplain;
    public Button Buttonbuy;
    public Button SyntheButtonBuy;
    public Button ShotGunButtonBuy;
    public GameObject PlayMainScript = null;
    // Start is called before the first frame update
    void Start()
    {
        Texture();
    }

    void Texture()
    {
        mypistolButton.interactable = false;
        PistolName.text = "PISTOL";
        PistolExplain.text = "권총입니다. 아마도요. ";
    }

    public void textSetActive()
    {
        PistolName.text = "PISTOL";
        PistolExplain.text = "권총입니다. 아마도요. ";
        PlayMainScript.GetComponent<WeaponData>().ChangeStateWeaponState(WEAPONTYPE.PISTOL);
//        GameObject.Find("PlayMain").GetComponent<MainPlay>().WeaponUpgradeMenu();
 
    }

    public void OnPointerClick(PointerEventData eventData) //더블클릭용 
    {
        if (this.GetComponent<Button>().interactable) return;
        if((Time.time - doubleClickTime) < interval)
        {
            Texture();
            isDoubleClicked = true;
            doubleClickTime = -1.0f;

            Debug.Log("Selecting Pistol");
            Buttonbuy.gameObject.SetActive(true);
            SyntheButtonBuy.gameObject.SetActive(false);
  //          ShotGunButtonBuy.gameObject.SetActive(false);
        }
        else
        {
            isDoubleClicked = false;
            doubleClickTime = Time.time;
        }

    }
    

}
