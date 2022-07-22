using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public WEAPONTYPE myWeaponType = WEAPONTYPE.SHOTGUN;
    public PlayerWeaponData myweapondatas;
    public GameObject[] emptyShell; //�Ѿ��� ������ ź�ǰ� ���������� (�������� ������ ������) 
    public GameObject Bullet; //���� �Ѿ�
    public Transform ShotGunMuzzle; //�Ѿ��� ������ ��ġ 
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
        Instantiate(Bullet, ShotGunMuzzle.transform.position, Quaternion.AngleAxis(0, Vector3.forward));
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
