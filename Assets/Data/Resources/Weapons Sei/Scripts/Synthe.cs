using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synthe : MonoBehaviour
{
    public WEAPONTYPE myWeaponType = WEAPONTYPE.SYNTHE;
    public PlayerWeaponData myweapondatas;
    private static Synthe synthe_instance = null;
    public float Damage;
    public int Synthemylevel;


    void Start()
    {
        WeaponSelect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if (synthe_instance != this)
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
        DontDestroyobject.instance.WeaponSelected = 2;
    }
    public int Getlevel()
    {
        return Synthemylevel += 1;
    }

    public void OnAttack()
    {
        this.Damage = myweapondatas.GetDamage(Synthemylevel);
    }
}
