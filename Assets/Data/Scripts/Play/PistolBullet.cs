using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public PlayerWeaponData PistolBulletData;
    public float Damage;
    public float AttackDelay;
    public int PistolLevelSetting;
    public float Speed = 10.0f;
    private PistolBullet pistolbullet_instance = null;
    // Start is called before the first frame update
    void Start()
    {
        Damage = PistolBulletData.GetDamage(PistolLevelSetting);
    }

    public int Getlevel()
    {
        return PistolLevelSetting += 1;
    }

    private void Awake()
    {
        if (pistolbullet_instance != this)
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
        float moveX = Speed * Time.deltaTime;
        transform.Translate(Vector3.right * moveX);
        Destroy(this.gameObject, 5.0f);
    }

    public void OnAttack()
    {
        Damage = PistolBulletData.GetDamage(PistolLevelSetting);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
