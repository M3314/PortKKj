using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public enum Characters
{
    Runa, Sei
}

public class ChaData : MonoBehaviour
{
    Animator myAnim;
    int AttackType = 0;
    public static ChaData instance;
    public ShotGun ShotGunBulletFire; //샷건 애니메이션 때문에 추가함.
    public float moveSpeed = 5.0f;
    public GameObject ShotGunBullet = null;
    public Transform ShotGunFirePosition;
    public WeaponData playerWeaponChangeData = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            return;
    }

    public Characters characterscurrentss;

    public void Start()
    {
        myAnim = GetComponent<Animator>();
        ShotGunBulletFire.myRenderer.sortingOrder = 4;
    }

    public void Update()
    {

    }
    public void FixedUpdate()
    {
       // DoubleInput();
        WeaponAttackKey();
        Move();
    }



    public void WeaponAttackKey()
    {
        if (playerWeaponChangeData.myWeaponType == WEAPONTYPE.SWORD)
        {
            AttackSword();
        }
        if (playerWeaponChangeData.myWeaponType == WEAPONTYPE.SYNTHE)
        {
            AttackSynthe();
        }
        if (playerWeaponChangeData.myWeaponType == WEAPONTYPE.SHOTGUN)
        {
            ShotGunAttack();
            myAnim.SetTrigger("IdleChange2");
        }
    }
    public void Move()
    {
        if (Input.GetKey(KeyCode.J))
            return;
        transform.localPosition = ClampPosition(transform.localPosition);
        myAnim.SetBool("RUN", false);
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            myAnim.SetBool("RUN", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            myAnim.SetBool("RUN", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            myAnim.SetBool("RUN", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
            myAnim.SetBool("RUN", true);
        }
    }

    public Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3
        (
            Mathf.Clamp(position.x, -20.0f, 18.5f), Mathf.Clamp(position.y, -8.8f, 2.6f), 0  //맵 거리 이동 제한 
        );
    }


    public void AttackSword()
    {
        if (!myAnim.GetBool("SwordAttacking") && Input.GetKey(KeyCode.J))
        {
            Debug.Log("J키를 입력했습니다. 칼로 근접공격합니다");
            myAnim.SetInteger("AttackType", AttackType++ % 2);
            myAnim.SetTrigger("SwordAttack");
            myAnim.SetBool("RUN", false);
            return;
            GetComponent<Sword>().OnAttack();
        }
//        CancelInvoke("Move");
    }

    void ShotGunBulletTimer()
    {
        Instantiate(ShotGunBullet, ShotGunFirePosition.transform.position, Quaternion.AngleAxis(0, Vector3.forward));
    }

    void ShotGunBulletBackTimer()
    {
        Instantiate(ShotGunBullet, ShotGunFirePosition.transform.position, Quaternion.AngleAxis(0, Vector3.back));
    }

    public void AttackSynthe()
    {
        if (!myAnim.GetBool("SyntheAttacking") && Input.GetKey(KeyCode.J))
        {
            Debug.Log("J키를 입력했습니다. 낫공격합니다");
            myAnim.SetInteger("AttackType", AttackType++ % 2);
            myAnim.SetTrigger("SyntheAttack");
        }

    }

    public void ShotGunAttack()
    {
        if (!myAnim.GetBool("ShotGunAttacking") && Input.GetKey(KeyCode.J))
        {
            Debug.Log("J키를 입력했습니다. 샷건으로 공격합니다");
    //        ShotGunBulletFire = GameObject.Find("Shot Gun(Clone)").GetComponent<ShotGun>();
            ShotGunBulletFire = GameObject.Find("Shot Gun").GetComponent<ShotGun>(); //잠깐 테스트용으로 만든거임. 
            myAnim.SetTrigger("ShotGunAttack");
     
            ShotGunBulletFire.myRenderer.sortingOrder = 4;
            Invoke("ShotGunBulletTimer", 0.35f);
            myAnim.SetTrigger("IdleChange");

            if (gameObject.transform.localScale == new Vector3(0.3f, 0.3f, 0.3f))
            {
                Invoke("ShotGunBulletBackTimer", 0.35f);
            }
        }
        return;
    }
    public void PistolAttack()
    {

    }

    public void DoubleInput()
    {
        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack1 (Sword)"))
        {
            myAnim.SetBool("Run", false);
            moveSpeed = 0.0f;
        }
        else
            moveSpeed = 5.0f;

        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack2(Sword)"))
        {
            myAnim.SetBool("Run", false);
            moveSpeed = 0.0f;
        }

        if (myAnim.GetCurrentAnimatorStateInfo(1).IsName("ShotGun Attack"))
        {
            myAnim.SetBool("Run", false);
            moveSpeed = 0.0f;
        }
        else
            moveSpeed = 5.0f;
    }

}



