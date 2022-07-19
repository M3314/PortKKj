using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public struct PlayerCharacterStat
{
    public float HP; //체력 
    public float AttackDelay;
    public float AP; //스킬트리 (스킬 빠? 정도) 
    public float EX; //경험치 
}


public class PlayGameUtil : MonoBehaviour
{

    public PlayerData[] playerDatas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
