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
    };
    public MainPlay MainPlayer; //메인 플레이 연동
    public ChaData chadatas; //
    public GameObject Clearpopup; //클리어 팝업 
    public Transform HPBar; //적 HPBAR 넣는곳 
    public ENEMYSTATE myEnemyInfoState = ENEMYSTATE.SWORD; //적군은 칼로 설정함 
    [SerializeField] public WEAPONTYPE PlayerWeaponType; //플레이어가 들고 있는 무기 설정 
    public PlayerWeaponData[] myDamageData; //플레이어의 무기 데미지 정보 설정 
    [SerializeField] public Transform EnemyTarget; //플레이어를 타겟으로 설정
    public float moveSpeed; //이동속도
    public EnemyData SwordEnemyData; //적 캐릭터 데이터 
    public State myEnemyState = State.CREATE; //게임이 시작하면 Create 모드로
    public float attackDelay = 1.5f; //공격 딜레이 시간 
    public TMP_Text GoldInfo; //골드 정보 (Text)
    public TMP_Text LevelInfomation; //레벨 정보 (플레이어, Text)
    public PlayerData playerdatas; //플레이어 데이터 
    [SerializeField] public WeaponData playerWeaponChange; //플레이어가 어떤 무기를 장착 하고 있을때 설정 
    public Sei seiCharacterData = null; //플레이어중 Sei라는 플레이어 정보 
    public Runa RunaCharacterData = null; //플레이어중 Runa라는 플레이어 정보
    [SerializeField] public myExStarBar myExBar; //EX Bar 연동
    public SwordEnemyHPBAR SwordEnemyHPBar; //적 캐릭터 체력 연동 

    public bool enemyattacked = false;

    void AttackTrue()
    {
        enemyattacked = true;
    }
    void AttackFalse()
    {
        enemyattacked = false;
    }
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
            SwordEnemyHPBar.EnemyHP.value = _curHP / SwordEnemyData.MaxHP;
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
        Clearpopup = GameObject.Find("Canvas").transform.FindChild("ClearPopup").gameObject;
        SwordEnemyData.MaxHP = 100;
        HpSet();
        ChangeState(State.BATTLE);
             MainPlayer = GameObject.Find("PlayMain").GetComponent<MainPlay>();
        myExBar = GameObject.Find("Ex Bar").GetComponent<myExStarBar>();
        if (DontDestroyobject.instance.Chaselected == 1)
        {
           chadatas = GameObject.Find("SeiKo_32(Clone)").GetComponent<ChaData>();
            seiCharacterData = GameObject.Find("SeiKo_32(Clone)").GetComponent<Sei>();
            EnemyTarget = GameObject.Find("SeiKo_32(Clone)").transform;
            playerdatas = Instantiate(Resources.Load("InGameData/SeiPlayerData")) as PlayerData;
        }

        if (DontDestroyobject.instance.Chaselected == 2)
        {
            chadatas = GameObject.Find("RUNA_2(Clone)").GetComponent<ChaData>();
            RunaCharacterData = GameObject.Find("RUNA_2(Clone)").GetComponent<Runa>();
            EnemyTarget = GameObject.Find("RUNA_2(Clone)").transform;
            playerdatas = Instantiate(Resources.Load("InGameData/RunaPlayerData")) as PlayerData;
        }
        GoldInfo = GameObject.Find("GoldText").GetComponent<TMP_Text>();
        LevelInfomation = GameObject.Find("LevelText").GetComponent<TMP_Text>();
        GoldInfo.text = DontDestroyobject.instance.GoldInfo.ToString();
        LevelInfomation.text = DontDestroyobject.instance.LevelInfo.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        TargetPosition();
        DoubleInput();
        Moving();
    }

    public void Moving()
    {
        Vector3 dir = EnemyTarget.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * moveSpeed * Time.deltaTime;
        if(HPChange <= 0)
        {
            moveSpeed = 0;
           EnemyTarget = this.gameObject.transform;
        }
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
        HPChange = -myDamageData[(int)PlayerWeaponType].GetDamage(DontDestroyobject.instance.weaponlevelinfo);
        if (HPChange <= 0.0f)
        {
            moveSpeed = 0;
            myAnim.SetTrigger("Dead");
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
            //   other.gameObject.GetComponent<Sword>()?.OnAttack();
            if (playerWeaponChange.myWeaponType == WEAPONTYPE.SHOTGUN)
            {
                other.gameObject.GetComponent<ShotGunBullet>()?.OnAttack();
                OnDamage();
            }
            if (playerWeaponChange.myWeaponType == WEAPONTYPE.PISTOL)
            {
                other.gameObject.GetComponent<PistolBullet>()?.OnAttack();
                OnDamage();
            }
            if (chadatas.attacked == true && playerWeaponChange.myWeaponType == WEAPONTYPE.SWORD)
            {
                other.gameObject.GetComponent<Sword>()?.OnAttack();
                OnDamage();
            }
            if (chadatas.attacked == true && playerWeaponChange.myWeaponType == WEAPONTYPE.SYNTHE)
            {
                other.gameObject.GetComponent<Synthe>()?.OnAttack();
                OnDamage();
            }
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

    IEnumerator Disappearing()
    {
        MainPlayer.Enemynums -= 1;
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
        Destroy(SwordEnemyHPBar.gameObject);
        if(MainPlayer.Enemynums == 0)
        {
            MainPlayer.mystate = MainPlay.STATE.GAMEOVER;
            Clearpopup.gameObject.SetActive(true);
        }
    }

   public void ChangeState(State s)
    {
        if (myEnemyState == s) return;
        myEnemyState = s;
        switch (myEnemyState)
        {
            case State.CREATE:
                ChangeState(State.BATTLE);
                break;
            case State.BATTLE:
                HPChange = SwordEnemyData.MaxHP;
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
                if (DontDestroyobject.instance.Chaselected == 1)
                {
                    seiCharacterData.APChange = +SwordEnemyData.MaxAP;
                    seiCharacterData.EXChange = +SwordEnemyData.MaxEX;
                    if (seiCharacterData.EXChange >= playerdatas.PlayerEXSet(seiCharacterData.myLevel))
                    {
                        seiCharacterData.myLevel += 1;
                        LevelInfomation.text = (DontDestroyobject.instance.LevelInfo + 1).ToString();
                        DontDestroyobject.instance.LevelInfo = (DontDestroyobject.instance.LevelInfo + 1);
                    }
                }

                if (DontDestroyobject.instance.Chaselected == 2)
                {
                    RunaCharacterData.APChange = +SwordEnemyData.MaxAP;
                    RunaCharacterData.EXChange = +SwordEnemyData.MaxEX;
                    if (RunaCharacterData.EXChange >= playerdatas.PlayerEXSet(RunaCharacterData.myLevel))
                    {
                        RunaCharacterData.myLevel += 1;
                        LevelInfomation.text = (DontDestroyobject.instance.LevelInfo + 1).ToString();
                        DontDestroyobject.instance.LevelInfo = (DontDestroyobject.instance.LevelInfo + 1);
                    }
                }
                moveSpeed = 0.0f;
                myAnim.ResetTrigger("Attack"); //공격을 못하도록 설정한다.
                StartCoroutine(Disappearing());
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
