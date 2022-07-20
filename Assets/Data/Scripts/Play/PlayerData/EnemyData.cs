using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyData", order = int.MinValue +2)]
public class EnemyData : ScriptableObject
{
    [SerializeField] public int MaxHP; //최대체력
    [SerializeField] int MaxEX; //플레이어한테 EX (경험치) 주기 전용
    [SerializeField] int MaxAP; //플레이어한테 스킬 AP 주기 전용 
    [SerializeField] int MaxAttack; //적군 공격력 
    [SerializeField] int ScoreGold; //골드 


    public int GetMaxHP() => MaxHP;

    public int GetEX() => MaxEX;

    public int GetAP() => MaxAP;

    public int MaxEnemyAttack() => MaxAttack;

    public int GetScore() => ScoreGold;


}
