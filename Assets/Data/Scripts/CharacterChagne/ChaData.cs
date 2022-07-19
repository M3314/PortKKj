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
    public float moveSpeed = 5.0f;
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
    }

    public void Update()
    {

    }
    public void FixedUpdate()
    {
        WeaponAttackKey();
        Move(); 
        if(myAnim.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack"))
        {
            myAnim.SetBool("Run", false);
            moveSpeed = 0.0f;
        }
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
        }
    }
    public void Move()
    {

        transform.localPosition = ClampPosition(transform.localPosition);
        myAnim.SetBool("RUN", false);
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W 키를 눌렀습니다. 위로 이동합니다.");
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            myAnim.SetBool("RUN", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S 키를 눌렀습니다. 아래로 이동합니다.");
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            myAnim.SetBool("RUN", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A키를 입력했습니다. 서쪽으로 이동합니다.");
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            myAnim.SetBool("RUN", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D키를 입력했습니다. 동쪽으로 이동합니다.");
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
            //CancelInvoke("Move");
        }
//        CancelInvoke("Move");
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
            myAnim.SetTrigger("ShotGunAttack");
            CancelInvoke("Move");
        }
    }
    public void PistolAttack()
    {

    }

    public void DoubleInput()
    {

    }

}



