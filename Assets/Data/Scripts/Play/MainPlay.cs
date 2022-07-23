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

    // Start is called before the first frame update
    void Start()
    {
        if(DontDestroyobject.instance.Chaselected == 1)
        {   
            Player = GameObject.Find("SeiKo_32(Clone)").transform;
        }
        if (DontDestroyobject.instance.Chaselected == 2)
        {
            Player = GameObject.Find("RUNA_2(Clone)").transform;
        }

        ChangeState(STATE.PLAY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeState (STATE s)
    {
        if (mystate == s) return;
        mystate = s;
        switch(mystate)
        {
            case STATE.PLAY:
                break;
            case STATE.GAMEOVER:
                break;
        }
    }
}
