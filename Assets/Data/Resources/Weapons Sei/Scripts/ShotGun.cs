using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public WEAPONTYPE myWeaponType = WEAPONTYPE.SHOTGUN;
    public PlayerWeaponData myweapondatas;
    public Transform FirePosition; //총알이 나가는 위치 
    SpriteRenderer _renderer = null;

   public SpriteRenderer myRenderer
    {
        get
        {
            if (_renderer == null)
            {
                _renderer = this.GetComponent<SpriteRenderer>();
            }
            return _renderer;
        }
    }

    public int Shotgunlevel;
    private static ShotGun shotgun_instance = null;

    // Start is called before the first frame update
    void Start()
    {
        WeaponSelect();
     //   myRenderer.sortingOrder = 1;
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
        FirePosition = Instantiate(Resources.Load("Weapons Sei/New Folder/ShotGunBullet")) as Transform;
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
