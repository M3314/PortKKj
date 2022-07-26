using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    NONE, SWORD, SPEAR, RIFLE
}
[CreateAssetMenu(fileName = "StageData", menuName = "StageData", order = int.MinValue + 1)]

public class StageData : ScriptableObject
{
    [SerializeField] EnemyType[] EnemyList;
    [SerializeField] float timeGap = 2.0f; //�����ð� ���� ���� �ϰ� ��.
    public float GetTimeGap() => timeGap;

    public EnemyType GetEnemy(int i) =>
        i == EnemyList.Length ? EnemyType.NONE : EnemyList[i];
}
