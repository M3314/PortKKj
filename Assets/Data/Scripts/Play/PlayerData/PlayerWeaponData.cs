using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerWeaponData", menuName = "PlayerWeaponData", order = int.MaxValue)]
public class PlayerWeaponData : ScriptableObject
{
    [SerializeField] int[] WeaponDamage;
    [SerializeField] int[] WeaponUpgradePrices;
    [SerializeField] public int WeaponBuyPrices;

    public int MaxLevel { get => WeaponUpgradePrices.Length; }
    public int GetDamage(int lv) => WeaponDamage[lv];
    public int GetPrice(int lv) => WeaponUpgradePrices[lv];
    public int GetBuy() => WeaponBuyPrices;
}
