using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class myExStarBar : MonoBehaviour
{
    public Slider myEX;
    public Sei seiCharacterData = null;
    public Runa RunaCharacterData = null;
    public PlayerData PlayerdatasSetting = null;

    // Start is called before the first frame update
    void Start()
    {
        if (DontDestroyobject.instance.Chaselected == 1)
        {
       //     seiCharacterData = GameObject.Find("SeiKo_32").GetComponent<Sei>(); // 스테이지 1에서 잠깐 테스트용으로 만들어놨음, 인게임상에서 null이 떠도 신경 쓰지 않아도 되는 부분입니다. 
            seiCharacterData = GameObject.Find("SeiKo_32(Clone)").GetComponent<Sei>();
            PlayerdatasSetting = Instantiate(Resources.Load("InGameData/SeiPlayerData")) as PlayerData;
        }

        if (DontDestroyobject.instance.Chaselected == 2)
        {
            RunaCharacterData = GameObject.Find("RUNA_2(Clone)").GetComponent<Runa>();
            PlayerdatasSetting = Instantiate(Resources.Load("InGameData/RunaPlayerData")) as PlayerData;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DontDestroyobject.instance.Chaselected == 1)
        {
            myEX.maxValue = PlayerdatasSetting.PlayerEXSet(seiCharacterData.myLevel);
            myEX.value = (seiCharacterData.EXChange);
        }
        if (DontDestroyobject.instance.Chaselected == 2)
        {
            myEX.maxValue = PlayerdatasSetting.PlayerEXSet(RunaCharacterData.myLevel);
            myEX.value = (RunaCharacterData.EXChange);
        }
    }
}
