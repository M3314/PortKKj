using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public WEAPONTYPE myWeaponType = WEAPONTYPE.SHOTGUN;
    public PlayerWeaponData myweapondatas;
    public GameObject[] emptyShell; //총알이 나가면 탄피가 나오도록함 (랜덤으로 나오게 설정함) 
    public GameObject Bullet; //샷건 총알
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
      //  Instantiate(Bullet, FirePosition.transform.position, Quaternion.AngleAxis(0, Vector3.forward));
        FirePosition = Instantiate(Resources.Load("Weapons Sei/New Folder/ShotGunBullet")) as Transform;
        Bullet = Instantiate(Resources.Load("Weapons Sei/New Folder/ShotGunBullet")) as GameObject;
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
