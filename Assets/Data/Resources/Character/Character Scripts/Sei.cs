using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Sei : MonoBehaviour
{
    public STATE mystate = STATE.NONE;
    public ChaData moveSpeedSetting;
    public MainPlay mainplayinfo;
    public PlayerCharacterStat SeiData;
    [SerializeField] public EnemyData[] EnemysData;
    [SerializeField] public myStatBar myStarBar;
    [SerializeField] public myApStatBar myApBar;
    [SerializeField] public myExStarBar myExBar;
    public int myLevel = 1;
    public SwordEnemy SwordenemyInfo;
    public PlayerData myseiData;
    public TMP_Text LevelInfomation;
    public Animator myAnim;
    public float _curHP;
    public float HPChange
    {
        get
        {
            return _curHP;
        }
        set
        {
            _curHP += value;
            if (_curHP < 0.0f) _curHP = 0.0f;
            myStarBar = GameObject.Find("Hp Bar").GetComponent<myStatBar>();
            myStarBar.myHP.value = _curHP / myseiData.PlayerHPSet(myLevel);
        }
    }

    public float _curAP;
    public float APChange
    {
        get
        {
            return _curAP;
        }
        set
        {
            _curAP += value;
            if (_curAP < 0.0f) _curAP = 0.0f;
            myApBar = GameObject.Find("AP Bar").GetComponent<myApStatBar>();
            myApBar.myAP.value = _curAP / myseiData.PlayerAPSet(myLevel);
        }
    }

    public float _curEX;
    public float EXChange
    {
        get
        {
            return _curEX;
        }
        set
        {
            _curEX += value;
            if (_curEX < 0.0f) _curEX = 0.0f;
            myExBar = GameObject.Find("Ex Bar").GetComponent<myExStarBar>();
            myExBar.myEX.value =  (EXChange);
        }
    }
    public enum STATE
    {
        NONE, CREATE, PLAY, DEAD
    }
    private void Start()
    {
        myLevel = DontDestroyobject.instance.LevelInfo;
        CharacterSelect();
        ChangeState(STATE.CREATE);
       // myAnim = GameObject.Find("SeiKo_32(Clone)");
        if (SceneManager.GetActiveScene().name == "In Game 1-1")
        {
            mainplayinfo = GameObject.Find("PlayMain").GetComponent<MainPlay>();
   //         SwordenemyInfo = GameObject.Find("EnemySword").GetComponent<SwordEnemy>(); //Test용 
       //     SwordenemyInfo = GameObject.Find("EnemySword(Clone)").GetComponent<SwordEnemy>();
        };
    }
    void Update()
    {
        StateProcess();
        ApChanges();
    }

    public void ApChanges()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            APChange = -2;
            HPChange = +4;

             if(APChange <=2)
            {
                HPChange = +0;
                APChange = -0;
            }
        }
    }

    void CharacterSelect()
    {
        DontDestroyobject.instance.Chaselected = 1;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyWeapon"))
        {
   //         other.gameObject.GetComponent<EnemyData>().MaxEnemyAttack();
            Debug.Log("공격받고 있음.");
            OnDamage();
        }
    }

    public void OnDamage()
    {
        //     _curHP = GetComponent<SwordEnemy>().UpdateHP();
        if (mystate == STATE.DEAD) return;
        HPChange = -EnemysData[(int)SwordenemyInfo.myEnemyInfoState].MaxEnemyAttack();
        if (HPChange <= 0.0f)
        {
            ChangeState(STATE.DEAD);
            mainplayinfo.mystate = MainPlay.STATE.GAMEOVER;
            mainplayinfo.GameOverPopup.SetActive(true);
            myAnim.SetTrigger("Dead");
            myAnim.ResetTrigger("Start");
            myAnim.ResetTrigger("IdleChange2");
            myAnim.ResetTrigger("ShotGunAttack");
        }
            
    }

    public void Exchangevalue()
    {
        myLevel += 1;
    }

    void ChangeState(STATE s)
    {
        if (mystate == s) return;
        mystate = s;
        switch (mystate)
        {
            case STATE.CREATE:
                _curHP = myseiData.PlayerHPSet(myLevel);
                SeiData.HP = myseiData.PlayerHPSet(myLevel);
                SeiData.AttackDelay = 3.0f;
                _curAP = 0.0f;
                _curEX = 0.0f;
                myLevel = DontDestroyobject.instance.LevelInfo;
                //      LevelInfomation =GameObject.Find("LevelText").GetComponent<TMP_Text>();
                if (SceneManager.GetActiveScene().name == "In Game 1-1")
                {
                    ChangeState(STATE.PLAY);
                };
                break;
            case STATE.PLAY:
                mainplayinfo = GameObject.Find("PlayMain").GetComponent<MainPlay>();
                mainplayinfo.GameOverPopup.SetActive(false);
                myAnim.ResetTrigger("Dead");
                myAnim.SetTrigger("Start");
                mainplayinfo.mystate = MainPlay.STATE.PLAY;
                APChange = 9f;
                EXChange = 0f;
                LevelInfomation = GameObject.Find("LevelText").GetComponent<TMP_Text>();
                if (SceneManager.GetActiveScene().name == "Cha Info, Inven(Back Menu)")
                {
                    moveSpeedSetting.moveSpeed = 0.0f;
                }
                    break;
            case STATE.DEAD:
                base.StopAllCoroutines();
                mainplayinfo.mystate = MainPlay.STATE.GAMEOVER;
                myAnim.SetTrigger("Dead");
                myAnim.ResetTrigger("Start");
                myAnim.ResetTrigger("IdleChange2");
             myAnim.ResetTrigger("ShotGunAttack");
                myAnim.SetBool("RUN", false);
                moveSpeedSetting.moveSpeed = 0.0f;
                break;
        }
    }

    void StateProcess()
    {
        switch (mystate)
        {
            case STATE.CREATE:
                break;
            case STATE.PLAY:
                break;
            case STATE.DEAD:
                break;
        }
    }

}
