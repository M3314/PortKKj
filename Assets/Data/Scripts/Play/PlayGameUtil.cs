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
    public float HP; //ü�� 
    public float AttackDelay;
    public float AP; //��ųƮ�� (��ų ��? ����) 
    public float EX; //����ġ 
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
