using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InGame : MonoBehaviour
{
    [SerializeField] static int myGold = 350;
    [SerializeField] int myLevel = 1;
    public Transform WeaponInventory = null;
    public GameInfoUi myInfoUI = null;
    public STATE myState = STATE.CREATE;
    public WeaponPopup weaponpopups = null;
    public WeaponData weaponDatachange = null;
    public WeaponChange weaponchange = null;
    public GameObject UpgradePopup;
    public TMPro.TMP_Text UpgradeText;
    public BuyButton WeaponBuyBotton = null;
    public GameObject DDOL;
    // Start is called before the first frame update
    public enum STATE
    {
        CREATE, START, PLAY, GAMEOVER, CLEAR
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
    public int Gold
    {
        get { return myGold; }
        set
        {
            //    if (myGold = GetComponent<WeaponData>(). )
            myGold = (int)value;
            myInfoUI.Gold.text = myGold.ToString();

            if (weaponchange != null)
            {
            //    WeaponBuyMenu();
           //     WeaponUpgradeMenu();
            }
        }
    }
    void Start()
    {
  
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                Gold = 350;
                Level = 1;
                ChangeState(STATE.PLAY);
                break;
            case STATE.PLAY:
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
