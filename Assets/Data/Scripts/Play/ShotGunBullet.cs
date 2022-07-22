using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : MonoBehaviour
{
    public PlayerWeaponData ShotGunBulletData;
    public float Damage;
    public int ShotGunlevelSetting;
    private ShotGunBullet shotgunbullet_instance = null;
    // Start is called before the first frame update
    void Start()
    {
        Damage = ShotGunBulletData.GetDamage(ShotGunlevelSetting);
    }

    public int Getlevel()
    {
        return ShotGunlevelSetting += 1;
    }

    private void Awake()
    {
        if (shotgunbullet_instance != this)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttack()
    {
        Damage = ShotGunBulletData.GetDamage(ShotGunlevelSetting);
    }
}
