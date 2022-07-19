using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIProperty : MonoBehaviour
{
    Animator _anim = null;
    protected Animator myAnim
    {
        get
        {
            if(_anim == null)
            {
                _anim = this.GetComponentInChildren<Animator>();
            }
            return _anim;
        }
    }
    [SerializeField] EnemyData enemysdata = null;
    protected EnemyData myData
    {
        get => enemysdata;
    }

   float? CurHP = null;

    protected bool UpdateHP(float data)
    {
        if(CurHP == null)
        {
           CurHP = enemysdata.GetMaxHP();
        }
        CurHP += data;
        if(CurHP < 0.0f)
        {
            CurHP = 0.0f;
            return false;
        }
        return true;
    }

}
