using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pistol : MonoBehaviour
{
    public WEAPONTYPE myWeaponType = WEAPONTYPE.PISTOL;
    public PlayerWeaponData myweapondatas;
    // Start is called before the first frame update
    void Start()
    {
        WeaponSelect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WeaponSelect()
    {
        DontDestroyobject.instance.WeaponSelected = 3;
    }

}
