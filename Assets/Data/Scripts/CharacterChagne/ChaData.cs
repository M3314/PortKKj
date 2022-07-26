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
    public Animator myAnim;
    int AttackType;
    public static ChaData instance;
    public ShotGun ShotGunBulletFire; //���� �ִϸ��̼� ������ �߰���.
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
        DoubleInput(); AttackDouble();
        WeaponAttackKey();
        Move();
    }



    public void WeaponAttackKey()
    {
        if (playerWeaponChangeData.myWeaponType == WEAPONTYPE.SWORD)
        {
            AttackSword();
            //    moveSpeed = 0.0f;
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
            Mathf.Clamp(position.x, -20.0f, 18.5f), Mathf.Clamp(position.y, -8.8f, 2.6f), 0  //�� �Ÿ� �̵� ���� 
        );
    }

    public void AttackSword()
    {
        if (!myAnim.GetBool("SwordAttacking") && Input.GetKey(KeyCode.J))
        {
            Debug.Log("JŰ�� �Է��߽��ϴ�. Į�� ���������մϴ�");
            myAnim.SetInteger("AttackType", AttackType++ % 2);
            myAnim.SetTrigger("SwordAttack");
            moveSpeed = 0.0f;
            myAnim.SetBool("RUN", false);
            myAnim.SetBool("SwordAttacking", true);
        }

    }

    void ShotGunBulletTimer()
    {
        if (gameObject.transform.localScale == new Vector3(-0.3f, 0.3f, 0.3f))
            Instantiate(ShotGunBullet, ShotGunFirePosition.transform.position, Quaternion.AngleAxis(0, Vector3.forward)); //�Ѿ��� ���������� �߻��ϰ�
        else if (gameObject.transform.localScale == new Vector3(0.3f, 0.3f, 0.3f))
            Instantiate(ShotGunBullet, ShotGunFirePosition.transform.position, Quaternion.AngleAxis(180, Vector3.forward)); //�Ѿ��� �������� �߻��ϰ�
    }

    public void AttackSynthe()
    {
        if (!myAnim.GetBool("SyntheAttacking") && Input.GetKey(KeyCode.J))
        {
            Debug.Log("JŰ�� �Է��߽��ϴ�. �������մϴ�");
            myAnim.SetInteger("AttackType", AttackType++ % 2);
            myAnim.SetTrigger("SyntheAttack");
        }

    }

    public void ShotGunAttack()
    {
        if (!myAnim.GetBool("ShotGunAttacking") && Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("JŰ�� �Է��߽��ϴ�. �������� �����մϴ�");
            ShotGunBulletFire = GameObject.Find("Shot Gun(Clone)").GetComponent<ShotGun>();
            //  ShotGunBulletFire = GameObject.Find("Shot Gun").GetComponent<ShotGun>(); //��� �׽�Ʈ������ �������. 
            myAnim.SetTrigger("ShotGunAttack");
            myAnim.SetBool("RUN", false);
            moveSpeed = 0.0f;
            ShotGunBulletFire.myRenderer.sortingOrder = 4;
            myAnim.SetTrigger("IdleChange");

            Invoke("ShotGunBulletTimer", 0.35f);

        }
        myAnim.GetBool("ShotGunAttacking");
    }
    public void PistolAttack()
    {

    }

    public void DoubleInput()
    {
        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack2(Sword)"))
        {
            myAnim.SetBool("RUN", false);
            moveSpeed = 0.0f;
        }
        else
            moveSpeed = 5.0f;

        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("ShotGun Attack"))
        {
            myAnim.SetBool("RUN", false);
            moveSpeed = 0.0f;
            myAnim.ResetTrigger("ShotGunAttacking");
        }

        if (myAnim.GetCurrentAnimatorStateInfo(1).IsName("Dead"))
        {
            myAnim.SetBool("RUN", false);
            moveSpeed = 0.0f;
            myAnim.ResetTrigger("ShotGunAttack");
            myAnim.ResetTrigger("SwordAttack");
            myAnim.ResetTrigger("SyntheAttack");
        }

    }

    public void AttackDouble()
    {
        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack"))
        {
            moveSpeed = 0.0f;
            myAnim.SetBool("RUN", false);
        }
    }

}



