using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public WEAPONTYPE myWeaponType = WEAPONTYPE.SHOTGUN;
    public PlayerWeaponData myweapondatas;
    public GameObject[] emptyShell;
    public GameObject Bullet;
    public Transform ShotGunMuzzle;

    public int Shotgunlevel;
    private static ShotGun shotgun_instance = null;

    // Start is called before the first frame update
    void Start()
    {
        WeaponSelect();
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

    public void FireBullet()
    {
        Bullet = Instantiate(Bullet, ShotGunMuzzle.position, ShotGunMuzzle.rotation);
        Bullet = Instantiate(Resources.Load("Weapons Sei/New Folder/ShotgunBullet")) as GameObject;

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
