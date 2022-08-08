using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Runa : MonoBehaviour
{
    public enum STATE
    {
        NONE, CREATE, PLAY, DEAD
    }
    public STATE mystate = STATE.NONE;
    public ChaData moveSpeedSetting;
    public MainPlay mainplayinfo;
    public PlayerCharacterStat RunaData;
    [SerializeField] public EnemyData[] EnemysData;
    [SerializeField] public myStatBar myStarBar;
    [SerializeField] public myApStatBar myApBar;
    [SerializeField] public myExStarBar myExBar;
    public int myLevel = 1;
    public SwordEnemy SwordenemyInfo;
    public PlayerData myRunaData;
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
            myStarBar.myHP.value = _curHP / myRunaData.PlayerHPSet(myLevel);
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
            myApBar.myAP.value = _curAP / myRunaData.PlayerAPSet(myLevel);
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
            myExBar.myEX.value = (EXChange);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        myLevel = DontDestroyobject.instance.LevelInfo;
        CharacterSelect();
        ChangeState(STATE.CREATE);
        if (SceneManager.GetActiveScene().name == "In Game 1-1")
        {
            mainplayinfo = GameObject.Find("PlayMain").GetComponent<MainPlay>();
        };
    }

    // Update is called once per frame
    void Update()
    {
        StateProcess();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyWeapon"))
        {
            Debug.Log("공격받고 있음.");
            OnDamage();
        }
    }

    public void OnDamage()
    {
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
    void CharacterSelect()
    {
        DontDestroyobject.instance.Chaselected = 2;
    }
    void ChangeState(STATE s)
    {
        if (mystate == s) return;
        mystate = s;
        switch (mystate)
        {
            case STATE.CREATE:
                _curHP = myRunaData.PlayerHPSet(myLevel);
                RunaData.HP = myRunaData.PlayerHPSet(myLevel);
                RunaData.AttackDelay = 3.0f;
                _curAP = 0.0f;
                _curEX = 0.0f;
                myLevel = DontDestroyobject.instance.LevelInfo;
                if (SceneManager.GetActiveScene().name == "In Game 1-1")
                {
                    ChangeState(STATE.PLAY);
                };
                break;
            case STATE.PLAY:
                mainplayinfo = GameObject.Find("PlayMain").GetComponent<MainPlay>();
                mainplayinfo.GameOverPopup.SetActive(false);
                myAnim.ResetTrigger("Dead");
           //     myAnim.SetTrigger("Start");
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
                myAnim.ResetTrigger("initialization");
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
