using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InvenMain : MonoBehaviour
{
    [SerializeField] public static int myGold = 350;
    [SerializeField] int myLevel = 1;
    public enum STATE
    {
        CREATE, START, PLAY, GAMEOVER, CLEAR
    }
    public GameInfoUi myInfoUI = null;
    public STATE myState = STATE.CREATE;
    public WeaponPopup weaponpopups = null;
    public WeaponData myWeaponData = null;
    public Sword myswordlevels = null;
    public Synthe mysynthelevels = null;
    public Transform WeaponInventory = null;
    public TMPro.TMP_Text UpgradeText;
    public WeaponChange weaponchange = null;
    public GameObject UpgradePopup;
    public ChaData Weaponlists;
    public TMPro.TMP_Text UpgradeLevelText;


    public int Gold
    {
        get { return myGold; }
        set
        {
            myGold = value;
            myInfoUI.Gold.text = myGold.ToString();
            if (weaponchange != null)
            {
                WeaponUpgradeMenu();
            }
            DontDestroyobject.instance.GoldInfo = Gold;
        }
    }
    int Level
    {
        get => myLevel;
        set
        {
            myLevel = value;
            myInfoUI.Level.text = myLevel.ToString();
        }

    }
    public static void UseGold(int price)
    {
        myGold -= price;
    }
    public void WeaponUpgradeMenu()
    {
        //    WeaponInventory.gameObject.SetActive(true);
        WeaponInventory.position = weaponchange.transform.position;
        int price = weaponchange.myWeaponData.GetPrice();
   
        if (price > 0 && Gold >= price)
        { 
            weaponpopups.upgradeBtn.gameObject.SetActive(true);
            weaponpopups.upgradeBtn.onClick.RemoveAllListeners();
            weaponpopups.upgradeBtn.onClick.AddListener(
                () =>
                {
                    Gold -= price;
                    weaponchange.myWeaponData.OnUpgrade(); 
                    weaponchange.myswordlevels.Getlevel();
                    weaponchange.mysynthelevels.Getlevel();
                    WeaponUpgradeMenu();
                    Debug.Log("업그레이드 완료");
                });
        }
        else
        {
            UpgradePopup.gameObject.SetActive(true);
            UpgradeText.text = "업그레이드가 최대치에 도달하였습니다.";
            UpgradeLevelText.text = "Max";
            weaponpopups.upgradeBtn.gameObject.SetActive(false);
        }
        if (Gold < price)
        {
            UpgradeText.text = "Not Enough Gold";
        }
    }

 
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(STATE.START);
    }

    // Update is called once per frame
    void Update()
    {
        processState();
    }
    void ChangeState(STATE s)
    {
        if (myState == s) return;
        myState = s;
        switch (myState)
        {
            case STATE.CREATE:
                break;
            case STATE.START:
                if (SceneManager.GetActiveScene().name == "In Game 1-1")
                {
                    ChangeState(STATE.PLAY);
                };
                Gold = DontDestroyobject.instance.GoldInfo;
                Level = DontDestroyobject.instance.LevelInfo;
                break;
            case STATE.PLAY:
                Gold = DontDestroyobject.instance.GoldInfo;
                Level = DontDestroyobject.instance.LevelInfo;
                break;
            case STATE.GAMEOVER:
                break;
            case STATE.CLEAR:
                break;
        }
    }

    void processState()
    {
        switch (myState)
        {
            case STATE.CREATE:
                break;
            case STATE.START:
                break;
            case STATE.PLAY:
                break;
            case STATE.GAMEOVER:
                break;
            case STATE.CLEAR:
                break;
        }
    }
}
