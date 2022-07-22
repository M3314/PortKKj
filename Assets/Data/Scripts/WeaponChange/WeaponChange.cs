using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponChange : MonoBehaviour
{
    public WeaponData myWeaponData = null;
    public Sword myswordlevels = null;
    public Synthe mysynthelevels = null;
    public ShotGun myShotGunLevels = null;
    public ShotGunBullet myShotGunBulletLevels = null;
    public ChaData Weaponlists = null;
    private ManagerWeapon m_weapons;
    private WeaponChange weaponchangee;
    GameObject myWeapon;
    public Transform WeaponImage;
    
    private int PreviousWeapon;
    // Start is called before the first frame update
    void Start()
    {
        m_weapons = GameObject.Find("WeaponManager").GetComponent<ManagerWeapon>();
        GameObject DefaultWeapon = m_weapons.Weapons[0];
        myWeapon = Instantiate(DefaultWeapon, WeaponImage);

        PreviousWeapon = 0;
    }
    public void ChangeWeapon(int weaponIndex)
    {
        if (weaponIndex != PreviousWeapon)
        {
            Debug.Log("Weapon Select");
            GameObject WeaponsImage = m_weapons.Weapons[weaponIndex];
            Instantiate(WeaponsImage, WeaponImage);
            Destroy(WeaponImage.GetChild(0).gameObject);
            PreviousWeapon = weaponIndex;

        }
    }
    
}
