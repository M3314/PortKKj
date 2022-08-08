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
    public Animator myAnim; //ĳ���� �ִϸ����� ���� 
    int AttackType; //���� Ÿ�� ���� 
    public static ChaData instance; //DontDestroyOnLoad (���� �Ѿ�� ������ ���� �ʵ��� ������)
    public ShotGun ShotGunBulletFire; //���� �ִϸ��̼� ������ �߰���.
    public Pistol PistolBulletFire; //���� ����
    public float moveSpeed = 5.0f; // �̵� ����
    public GameObject ShotGunBullet = null; //���� �Ѿ� ����
    public GameObject PistolBullet = null; //���� �Ѿ� ����
    public Transform ShotGunFirePosition; //���� �Ѿ��� ������ ��ġ
    public Transform PistolFirePosition; //���� �Ѷ��� ������ ��ġ
    public WeaponData playerWeaponChangeData = null; //���� ������ 
    public PlayerWeaponData syntheweaponDamage; //�� ������ (������ ����)
    public PlayerWeaponData swordweaponDamage; //Į ������ (������ ����)
    public bool attacked = false; //������ ���⸦ ����Ҷ� ����Ѵ�.

    void AttackTrue()
    {
        attacked = true;
    }
    void AttackFalse()
    {
        attacked = false;
    }

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
        if (SceneManager.GetActiveScene().name == "Cha Info, Inven(Back Menu)")
        {
            moveSpeed = 0 * Time.deltaTime;
        }
    }

    public void WeaponAttackKey()
    {
        if (playerWeaponChangeData.myWeaponType == WEAPONTYPE.SWORD)
        {
            AttackSword();
            myAnim.SetTrigger("initialization");
        }
        if (playerWeaponChangeData.myWeaponType == WEAPONTYPE.SYNTHE)
        {
            AttackSynthe();
            myAnim.SetTrigger("initialization");
        }
        if (playerWeaponChangeData.myWeaponType == WEAPONTYPE.SHOTGUN)
        {
            ShotGunAttack();
            myAnim.SetTrigger("IdleChange2");
        }
        if(playerWeaponChangeData.myWeaponType == WEAPONTYPE.PISTOL)
        {
            PistolAttack();
            myAnim.SetTrigger("PistolIdleChange2");
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
            Debug.Log("WŰ�� �������ϴ�. ���� �̵�");
            if (SceneManager.GetActiveScene().name == "Cha Info, Inven(Back Menu)")
            {
                moveSpeed = 0;
                myAnim.SetBool("RUN", false);
                transform.position = new Vector3(0, -5f, 0);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("SŰ�� �������ϴ�. �Ʒ��� �̵�");
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            myAnim.SetBool("RUN", true);
            if (SceneManager.GetActiveScene().name == "Cha Info, Inven(Back Menu)")
            {
                moveSpeed = 0;
                myAnim.SetBool("RUN", false);
                transform.position = new Vector3(0, -5f, 0);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("AŰ�� �������ϴ�. �·� �̵�");
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            myAnim.SetBool("RUN", true);
            if (SceneManager.GetActiveScene().name == "Cha Info, Inven(Back Menu)")
            {
                moveSpeed = 0;
                myAnim.SetBool("RUN", false);
                transform.position = new Vector3(0, -5f, 0);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("DŰ�� �������ϴ�. ��� �̵�");
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
            myAnim.SetBool("RUN", true);
            if (SceneManager.GetActiveScene().name == "Cha Info, Inven(Back Menu)")
            {
                moveSpeed = 0;
                myAnim.SetBool("RUN", false);
                transform.position = new Vector3(0, -5f , 0);
            }
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
            myAnim.SetBool("SwordAttacking", false);
     //       Debug.Log(swordweaponDamage.GetDamage(SwordInfo.Swordmylevel));
        }

    }

    void ShotGunBulletTimer()
    {
        if (gameObject.transform.localScale == new Vector3(-0.3f, 0.3f, 0.3f))
            Instantiate(ShotGunBullet, ShotGunFirePosition.transform.position, Quaternion.AngleAxis(0, Vector3.forward)); //�Ѿ��� ���������� �߻��ϰ�
        else if (gameObject.transform.localScale == new Vector3(0.3f, 0.3f, 0.3f))
            Instantiate(ShotGunBullet, ShotGunFirePosition.transform.position, Quaternion.AngleAxis(180, Vector3.forward)); //�Ѿ��� �������� �߻��ϰ�
    }

    void PistolBulletTimer()
    {
        if (gameObject.transform.localScale == new Vector3(-0.3f, 0.3f, 0.3f))
            Instantiate(PistolBullet, PistolFirePosition.transform.position, Quaternion.AngleAxis(0, Vector3.forward)); //�Ѿ��� ���������� �߻��ϰ�
        else if (gameObject.transform.localScale == new Vector3(0.3f, 0.3f, 0.3f))
            Instantiate(PistolBullet, PistolFirePosition.transform.position, Quaternion.AngleAxis(180, Vector3.forward)); //�Ѿ��� �������� �߻��ϰ�
    }

    public void AttackSynthe()
    {
        if (!myAnim.GetBool("SyntheAttacking") && Input.GetKey(KeyCode.J))
        {
            Debug.Log("JŰ�� �Է��߽��ϴ�. �������մϴ�");
            myAnim.SetInteger("AttackType", AttackType++ % 2);
            myAnim.SetTrigger("SyntheAttack"); moveSpeed = 0.0f;
            //      Debug.Log(syntheweaponDamage.GetDamage(Seidata.myLevel));
        }

    }

    public void ShotGunAttack()
    {
        if (!myAnim.GetBool("ShotGunAttacking") && Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("JŰ�� �Է��߽��ϴ�. �������� �����մϴ�");
            ShotGunBulletFire = GameObject.Find("Shot Gun(Clone)").GetComponent<ShotGun>();
            myAnim.SetTrigger("ShotGunAttack");
            myAnim.SetBool("RUN", false);
            moveSpeed = 0.0f;
            ShotGunBulletFire.myRenderer.sortingOrder = 4;
            myAnim.SetTrigger("IdleChange");

            Invoke("ShotGunBulletTimer", 0.35f);

        }
    }
    public void PistolAttack()
    {
        if (!myAnim.GetBool("PistolAttacking") && Input.GetKeyDown(KeyCode.J))
        {
            PistolBulletFire = GameObject.Find("Pistol(Clone)").GetComponent<Pistol>();
            Debug.Log("JŰ�� �Է��߽��ϴ�. ���Ѱ����մϴ�");
            myAnim.SetTrigger("PistolAttack");
            myAnim.SetBool("RUN", false);
            moveSpeed = 0.0f;
            PistolBulletFire.myRenderer.sortingOrder = 4;
            myAnim.SetTrigger("PistolIdleChange");
            Invoke("PistolBulletTimer", 0.2f);
        }
    }

    public void DoubleInput()
    {
        moveSpeed = 5.0f;
        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack2(Sword)"))
        {
            myAnim.SetBool("RUN", false);
            moveSpeed = 0.0f;
        }

        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("ShotGun Attack"))
        {
            myAnim.SetBool("RUN", false);
            moveSpeed = 0.0f;
      //      myAnim.ResetTrigger("ShotGunAttacking");
        }

        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Synthe Attack 1"))
        {
            myAnim.SetBool("RUN", false);
            moveSpeed = 0.0f;
   //         myAnim.ResetTrigger("SyntheAttacking");
        }
        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Synthe Attack 2"))
        {
            myAnim.SetBool("RUN", false);
            moveSpeed = 0.0f;
  //          myAnim.ResetTrigger("SyntheAttacking");
        }
        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("PistolAttack"))
        {
            myAnim.SetBool("RUN", false);
            moveSpeed = 0.0f;
            myAnim.ResetTrigger("PistolAttacking");
        }

        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            myAnim.SetBool("RUN", false);
            moveSpeed = 0.0f;
            myAnim.ResetTrigger("ShotGunAttack");
            myAnim.ResetTrigger("SwordAttack");
            myAnim.ResetTrigger("SyntheAttack");
            myAnim.ResetTrigger("PistolAttack");
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



