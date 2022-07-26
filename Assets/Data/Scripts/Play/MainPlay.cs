using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlay : MonoBehaviour
{
    public enum STATE
    {
        PLAY, GAMEOVER
    }
    public STATE mystate = STATE.PLAY;
    public Transform Player = null;
    public Transform Enemy = null;
    public ChaData CharacterMoveAttackData;
    public Sei Seidata;
    public Runa Runadata;
    public GameObject GameOverPopup;
    public GameObject ClearPopup;
    public StageData[] StageList;
    [SerializeField] float timeGap = 0.0f;
    [SerializeField] int CurStage = 0;
    int CurIndex = 0;
    public float playTime = 0.0f;
    public PlayerData myplayerdata;
    public int myLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (DontDestroyobject.instance.Chaselected == 1)
        {
            Player = GameObject.Find("SeiKo_32(Clone)").transform;
            Seidata = GameObject.Find("SeiKo_32(Clone)").GetComponent<Sei>();
            myplayerdata = Instantiate(Resources.Load("InGameData/SeiPlayerData")) as PlayerData;
            CharacterMoveAttackData = GameObject.Find("SeiKo_32(Clone)").GetComponent<ChaData>();
        }
        if (DontDestroyobject.instance.Chaselected == 2)
        {
            Player = GameObject.Find("RUNA_2(Clone)").transform;
            Runadata = GameObject.Find("RUNA_2(Clone)").GetComponent<Runa>();
      //     myplayerdata = Instantiate(Resources.Load("InGameData/RunaPlayerData")) as PlayerData; //¾ÆÁ÷ ¾È¸¸µë
            CharacterMoveAttackData = GameObject.Find("RUNA_2(Clone)").GetComponent<ChaData>();
        }
        ChangeState(STATE.PLAY);
        CurIndex = 0;
        timeGap = StageList[CurStage].GetTimeGap();
    }


    public void OnRestart()
    {
        ChangeState(STATE.PLAY);
        Seidata.mystate = Sei.STATE.PLAY;
    }

    // Update is called once per frame
    void Update()
    {
        StateProcess();
    }

    void CreateEnemy(EnemyType enemys)
    {
        switch (enemys)
        {
            case EnemyType.NONE:
                if (++CurStage == StageList.Length)
                {
                    ChangeState(STATE.GAMEOVER);
                }
                else
                {
                    CurIndex = 0;
                    playTime = timeGap = StageList[CurStage].GetTimeGap();
                }
                break;

            case EnemyType.SWORD:
                break;
            case EnemyType.SPEAR:
                break;
            case EnemyType.RIFLE:
                break;
        }
    }

        void ChangeState(STATE s)
        {
            if (mystate == s) return;
            mystate = s;
            switch (mystate)
            {
                case STATE.PLAY:
                myLevel = DontDestroyobject.instance.LevelInfo;
                //   Seidata._curHP = myseiData.PlayerHPSet(myLevel);
                GameOverPopup.SetActive(false);
                Seidata.HPChange = myplayerdata.PlayerHPSet(myLevel);
                Seidata.myAnim.SetTrigger("Start");
                break;
                case STATE.GAMEOVER:
                CharacterMoveAttackData.moveSpeed = 0.0f;
                CharacterMoveAttackData.myAnim.SetBool("RUN", false);
                break;
            }
        }

        void StateProcess()
        {
            switch (mystate)
            {
                case STATE.PLAY:
                    playTime += Time.deltaTime;
                    if (playTime >= timeGap)
                    {
                        playTime = 0.0f;
                    }
                    break;
                case STATE.GAMEOVER:
                    break;
            }
        }
    }
