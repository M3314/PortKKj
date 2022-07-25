using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnum : MonoBehaviour

{ 
    public enum STATE
{
        NONE, SWORD, SPEAR, RIFLE
}

    public STATE myEnemyInfoState = STATE.NONE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
