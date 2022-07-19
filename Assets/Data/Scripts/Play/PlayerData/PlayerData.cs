using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData", order = int.MinValue + 1)]
[Serializable]
public class PlayerData : ScriptableObject
{
    public int[] PlayerHP;
    public int[] PlayerEX;
    public int[] PlayerAP;

    public int MaxLevel { get => PlayerHP.Length; }

    public int PlayerHPSet(int lv) => PlayerHP[lv];
    public int PlayerEXSet(int lv) => PlayerEX[lv];
    public int PlayerAPSet(int lv) => PlayerAP[lv];
}
