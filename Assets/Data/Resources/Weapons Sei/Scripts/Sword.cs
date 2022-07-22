using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sword : MonoBehaviour
{ 
    public WEAPONTYPE myWeaponType = WEAPONTYPE.SWORD;
    public PlayerWeaponData myweapondatas;
    public float Damage;
    public int mylevel;
    private static Sword sword_instance = null;

    
    void Start()
    {
        mylevel = 1;
        WeaponSelect();
        Damage = myweapondatas.GetDamage(mylevel);
        //     mylevel = GetComponent<WeaponData>().Getmylevel();
    }

    private void Awake()
    {
        if (sword_instance != this)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void WeaponSelect()
    {
        DontDestroyobject.instance.WeaponSelected = 1;
    }
    public int Getlevel()
    {
        return mylevel += 1;
    }

    public void OnAttack()
    {
        Damage = myweapondatas.GetDamage(mylevel);
    }

}
