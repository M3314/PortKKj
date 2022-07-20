using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyData", order = int.MinValue +2)]
public class EnemyData : ScriptableObject
{
    [SerializeField] public int MaxHP; //�ִ�ü��
    [SerializeField] int MaxEX; //�÷��̾����� EX (����ġ) �ֱ� ����
    [SerializeField] int MaxAP; //�÷��̾����� ��ų AP �ֱ� ���� 
    [SerializeField] int MaxAttack; //���� ���ݷ� 
    [SerializeField] int ScoreGold; //��� 


    public int GetMaxHP() => MaxHP;

    public int GetEX() => MaxEX;

    public int GetAP() => MaxAP;

    public int MaxEnemyAttack() => MaxAttack;

    public int GetScore() => ScoreGold;


}
