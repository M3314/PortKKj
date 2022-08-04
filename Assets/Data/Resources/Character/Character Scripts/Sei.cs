using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Sei : MonoBehaviour
{
    public STATE mystate = STATE.NONE; //게임 플레이,게임 오버 상태 
    public ChaData moveSpeedSetting; //이동 속도 설정
    public MainPlay mainplayinfo; //InGame으로 가는 메인 플레이 설정 
    public PlayerCharacterStat SeiData; //캐릭터 설정 (HP, AP 등)
    [SerializeField] public EnemyData[] EnemysData; //적 설정 
    [SerializeField] public myStatBar myStarBar; //HP BAR 설정 
    [SerializeField] public myApStatBar myApBar; //AP Bar 설정 
    [SerializeField] public myExStarBar myExBar; //EX Bar 설정 
    public int myLevel = 1; //플레이어의 레벨 설정 
    public SwordEnemy SwordenemyInfo; //칼을든 적 정보 설정 
    public PlayerData myseiData; //플레이어의 설정 
    public TMP_Text LevelInfomation; //레벨 정보 설정 
    public Animator myAnim; //애니메이션 설정 
    public float _curHP; //HP Setting
    public float HPChange //HP 설정 
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
        myLevel = DontDestroyobject.instance.LevelInfo; //플레이어의 레벨의 경우 인벤토리로 넘어갈때 고정이 되도록 
        CharacterSelect();
        ChangeState(STATE.CREATE);
        if (SceneManager.GetActiveScene().name == "In Game 1-1")
        {
            mainplayinfo = GameObject.Find("PlayMain").GetComponent<MainPlay>();
        };
    }
    void Update()
    {
        StateProcess();
    }

    void CharacterSelect()
    {
        DontDestroyobject.instance.Chaselected = 1;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("EnemyWeapon"))
        {
            Debug.Log("공격받고 있음.");
            OnDamage();
        }
    }

    public void OnDamage() //데미지 설정 
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
                if (SceneManager.GetActiveScene().name == "In Game 1-1")
                {
                    ChangeState(STATE.PLAY);
                };
                break;
            case STATE.PLAY:
            //    HPChange = -50.0f;
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
