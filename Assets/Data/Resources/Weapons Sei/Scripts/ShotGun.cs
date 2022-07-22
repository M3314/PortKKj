using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public WEAPONTYPE myWeaponType = WEAPONTYPE.SHOTGUN;
    public PlayerWeaponData myweapondatas;
    public GameObject Bullet;
    public GameObject[] emptyShell;
    public int Shotgunlevel;
    private static ShotGun shotgun_instance = null;

    // Start is called before the first frame update
    void Start()
    {
        WeaponSelect();
        Bullet = Instantiate(Resources.Load("Weapons Sei/New Folder/ShotgunBullet")) as GameObject;
    }

    private void Awake()
    {
        if (shotgun_instance != this)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int GetLevel()
    {
        return Shotgunlevel += 1;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void WeaponSelect()
    {
        DontDestroyobject.instance.WeaponSelected = 4;
    }

}
