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
    public MainPlay mainplayinfo;
    public PlayerCharacterStat SeiData;
    [SerializeField] public EnemyData[] EnemysData;
    [SerializeField] public myStatBar myStarBar;
    [SerializeField] public myApStatBar myApBar;
    [SerializeField] public myExStarBar myExBar;
    public int myLevel;
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
        CharacterSelect();
        ChangeState(STATE.CREATE);
       // myAnim = GameObject.Find("SeiKo_32(Clone)");
        if (SceneManager.GetActiveScene().name == "In Game 1-1")
        {
            mainplayinfo = GameObject.Find("PlayMain").GetComponent<MainPlay>();
            SwordenemyInfo = GameObject.Find("EnemySword").GetComponent<SwordEnemy>();
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
           //     HPChange = -50.0f;
                APChange = 0.0f;
                EXChange = 0.0f;
                LevelInfomation = GameObject.Find("LevelText").GetComponent<TMP_Text>();
                break;
            case STATE.DEAD:
                base.StopAllCoroutines();
                myAnim.SetTrigger("Dead");
                mainplayinfo.mystate = MainPlay.STATE.GAMEOVER;
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
