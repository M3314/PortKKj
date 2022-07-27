using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class SwordEnemy : MonoBehaviour
{
    public enum State
    {
        CREATE, BATTLE, DEAD, GAMEOVER
    }

    public enum ENEMYSTATE
    {
        SWORD, SPEAR, RIFLE
    }
    public Transform HPBar; //적 HPBAR 넣는곳 
    public ENEMYSTATE myEnemyInfoState = ENEMYSTATE.SWORD;
    [SerializeField] public WEAPONTYPE PlayerWeaponType;
    public PlayerWeaponData[] myDamageData;
    [SerializeField] public Transform EnemyTarget;
    public float moveSpeed = 3.0f;
    public EnemyData SwordEnemyData;
    public State myEnemyState = State.CREATE;
    public float attackDelay = 1.5f;
    public TMP_Text GoldInfo;
    public TMP_Text LevelInfomation;
    public PlayerData playerdatas;
    [SerializeField] public WeaponData playerWeaponChange;
    public Sei seiCharacterData = null;
    public Runa RunaCharacterData = null;
    [SerializeField] public myExStarBar myExBar;
    public SwordEnemyHPBAR SwordEnemyHPBar;
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
            SwordEnemyHPBar.EnemyHP.value = _curHP / SwordEnemyData.MaxHP - myDamageData[(int)PlayerWeaponType].GetDamage(DontDestroyobject.instance.weaponlevelinfo);
        }
    }

    public void HpSet()
    {
        GameObject obj = Instantiate(Resources.Load("UI/EnemyHP"), GameObject.Find("Canvas").transform) as GameObject;
        SwordEnemyHPBar = obj.GetComponent<SwordEnemyHPBAR>();
        SwordEnemyHPBar.Initialize(HPBar, 0.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        SwordEnemyData.MaxHP = 100;
        HpSet();
        ChangeState(State.BATTLE);
        myExBar = GameObject.Find("Ex Bar").GetComponent<myExStarBar>();
        if (DontDestroyobject.instance.Chaselected == 1)
        {
            seiCharacterData = GameObject.Find("SeiKo_32(Clone)").GetComponent<Sei>();
            EnemyTarget = GameObject.Find("SeiKo_32(Clone)").transform;
            playerdatas = Instantiate(Resources.Load("InGameData/SeiPlayerData")) as PlayerData;
        }

        if (DontDestroyobject.instance.Chaselected == 2)
        {
            RunaCharacterData = GameObject.Find("RUNA_2(Clone)").GetComponent<Runa>();
            EnemyTarget = GameObject.Find("RUNA_2(Clone)").transform;
            playerdatas = Instantiate(Resources.Load("InGameData/RunaPlayerData")) as PlayerData;
        }
        GoldInfo.text = DontDestroyobject.instance.GoldInfo.ToString();
        LevelInfomation.text = DontDestroyobject.instance.LevelInfo.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        TargetPosition();
        DoubleInput();
        Vector3 dir = EnemyTarget.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    Animator _anim = null;
    public Animator myAnim
    {
        get
        {
            if (_anim == null)
            {
                _anim = this.GetComponentInChildren<Animator>();
            }
            return _anim;
        }
    }
    public Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3
        (
            Mathf.Clamp(position.x, -20.0f, 18.5f), Mathf.Clamp(position.y, -8.8f, 2.6f), 0  //맵 거리 이동 제한 
        );
    }

    public bool IsLive()
    {
        return myEnemyState == State.BATTLE;
    }

    void TargetPosition()
    {
        if(EnemyTarget.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }
    }

    public void OnDamage()
    {
        if (myEnemyState == State.DEAD) return;
    SwordEnemyData.MaxHP = SwordEnemyData.MaxHP - myDamageData[(int)PlayerWeaponType].GetDamage(DontDestroyobject.instance.weaponlevelinfo);
        HPChange = SwordEnemyData.MaxHP - myDamageData[(int)PlayerWeaponType].GetDamage(DontDestroyobject.instance.weaponlevelinfo);
        if (SwordEnemyData.MaxHP <= 0.0f)
        {
            ChangeState(State.DEAD);
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
            myExBar.myEX.value = _curEX + playerdatas.PlayerEXSet(seiCharacterData.myLevel) + 
                (playerdatas.PlayerEXSet(seiCharacterData.myLevel) - seiCharacterData.EXChange);
            myExBar.myEX.value = _curEX / playerdatas.PlayerEXSet(RunaCharacterData.myLevel);
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerWeapon"))
        {
            //        Debug.Log("Player에게 공격 받고있습니다.");
            other.gameObject.GetComponent<Sword>()?.OnAttack();
            other.gameObject.GetComponent<ShotGunBullet>()?.OnAttack();
            OnDamage();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myAnim.SetBool("Run", true); //플레이어가 감지 범위를 벗어 났을때 뛰도록 한다. (플레이어 맹추격)
        }
    }


    public void DoubleInput()
    {
        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            myAnim.SetBool("Run", false);
            moveSpeed = 0.0f;
        }
        else moveSpeed =3.0f;
    }

    void ChangeState(State s)
    {
        if (myEnemyState == s) return;
        myEnemyState = s;
        switch (myEnemyState)
        {
            case State.CREATE:
                ChangeState(State.BATTLE);
                break;
            case State.BATTLE:
                _curHP = SwordEnemyData.MaxHP;
                SwordEnemyData.ScoreGold = 10;
                SwordEnemyData.MaxAP = 5;
                break;
            case State.DEAD:
                StopAllCoroutines();
                myAnim.SetTrigger("Dead");
                myAnim.SetBool("Run", false);
                myAnim.ResetTrigger("GameOver");
                GoldInfo.text = (DontDestroyobject.instance.GoldInfo + SwordEnemyData.ScoreGold).ToString();
                DontDestroyobject.instance.GoldInfo = (DontDestroyobject.instance.GoldInfo + SwordEnemyData.ScoreGold);
                seiCharacterData.APChange += SwordEnemyData.MaxAP;
                seiCharacterData.EXChange += SwordEnemyData.MaxEX;
                if (seiCharacterData.EXChange >= playerdatas.PlayerEXSet(seiCharacterData.myLevel))
                {
                    seiCharacterData.myLevel += 1;
                    LevelInfomation.text = (DontDestroyobject.instance.LevelInfo + 1).ToString();
                    DontDestroyobject.instance.LevelInfo = (DontDestroyobject.instance.LevelInfo + 1);
                }

                myAnim.ResetTrigger("Attack"); //공격을 못하도록 설정한다.
                // StartCorutine(Disappearing());
                break;
            case State.GAMEOVER:
                //       myAnim.SetTrigger("");
                break;
        }
    }

    void StateProcess()
    {
        switch (myEnemyState)
        {
            case State.CREATE:
                break;
            case State.BATTLE:
                break;
            case State.DEAD:
                break;
            case State.GAMEOVER:
                break;
        }
    }
}
