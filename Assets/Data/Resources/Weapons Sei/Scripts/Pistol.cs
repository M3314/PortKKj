using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pistol : MonoBehaviour
{
    public WEAPONTYPE myWeaponType = WEAPONTYPE.PISTOL;
    public PlayerWeaponData myweapondatas;
    public Transform FirePosition;
    public int PistolLevel;
    private static Pistol pistol_instance = null;
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
    // Start is called before the first frame update
    void Start()
    {
        WeaponSelect();
    }

    private void Awake()
    {
        if (pistol_instance != this)
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
        return PistolLevel += 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FireBullet()
    {
        FirePosition = Instantiate(Resources.Load("Weapons Sei/New Folder/PistolBullet")) as Transform;
    }

    void WeaponSelect()
    {
        DontDestroyobject.instance.WeaponSelected = 3;
    }

}
