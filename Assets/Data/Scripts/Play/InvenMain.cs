using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

class GoldClass
{
    public static int gold
    {
        get
        {
            return PlayerPrefs.GetInt("KKJgameGold");
        }
        set
        {
            PlayerPrefs.SetInt("KKJgameGold", value);
        }
    }
}

public class InvenMain : MonoBehaviour
{
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
    public ShotGunBullet myShotgunbulletlevels = null;
    public ShotGun myShotGunlevels = null;
    public Pistol myPistolLevels = null;
    public PistolBullet myPistolBulletLevels = null;
    public Transform WeaponInventory = null;
    public TMPro.TMP_Text UpgradeText;
    public WeaponChange weaponchange = null;
    public GameObject UpgradePopup;
    public ChaData Weaponlists;
    public TMPro.TMP_Text UpgradeLevelText;
    public PlayerWeaponData SwordWeapons;
    public PlayerWeaponData SyntheWeapons;
    public PlayerWeaponData PistolWeapons;
    public PlayerWeaponData ShotGunWeapons;

    public int Gold
    {
        get { return GoldClass.gold; }
        set
        {
            GoldClass.gold = value;
            myInfoUI.Gold.text = GoldClass.gold.ToString();
            if (weaponchange != null)
            {
                WeaponUpgradeMenu();
            }
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
        GoldClass.gold -= price;
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
                    weaponchange.myWeaponData.OnUpgrade();

                    if (myWeaponData.myWeaponType == WEAPONTYPE.SWORD)
                    {
                        price = SwordWeapons.GetPrice(myswordlevels.Swordmylevel);
                        weaponchange.myswordlevels.Getlevel();
                    }
                    if (myWeaponData.myWeaponType == WEAPONTYPE.SYNTHE)
                    {
                        price = SyntheWeapons.GetPrice(mysynthelevels.Synthemylevel);
                        weaponchange.mysynthelevels.Getlevel();
                    }
                    if(myWeaponData.myWeaponType == WEAPONTYPE.PISTOL)
                    {
                        price = PistolWeapons.GetPrice(myPistolLevels.PistolLevel);
                        weaponchange.myPistolLevels.GetLevel();
                        weaponchange.myPistilBulletLevels.Getlevel();
                    }
                    if (myWeaponData.myWeaponType == WEAPONTYPE.SHOTGUN)
                    {
                        price = ShotGunWeapons.GetPrice(myShotGunlevels.Shotgunlevel);
                        weaponchange.myShotGunLevels.GetLevel();
                        weaponchange.myShotGunBulletLevels.Getlevel();
                    }
                    Gold -= price;
                    WeaponUpgradeMenu();
           //         PlayerPrefs.SetInt("Gold", Gold);
          //         PlayerPrefs.Save();
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
    private void Awake()
    {
        if (PlayerPrefs.GetInt("KKJgameFirstStart") == 0)
        {
            GoldClass.gold = 350;
            PlayerPrefs.SetInt("KKJgameFirstStart", 1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
   //    Gold = PlayerPrefs.GetInt("Gold");    
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
                Level = DontDestroyobject.instance.LevelInfo;
                Gold = GoldClass.gold;
             //   Gold = 350;
                break;
            case STATE.PLAY:
                Gold = GoldClass.gold;
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
