using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwordEnemy : MonoBehaviour
{
    public enum State
    {
        CREATE, BATTLE, DEAD, GAMEOVER
    }
    UnityAction<int> dieAction = null;
    public PlayerWeaponData myDamageData;
    [SerializeField] public ChaData EnemyTarget;
    public float moveSpeed = 2.0f;
    public EnemyData SwordEnemyData;
    public State myEnemyState = State.CREATE;
    public float attackDelay = 1.5f;
    protected int mylevel;
    public float Damage;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(State.BATTLE);
    }

    // Update is called once per frame
    void Update()
    {
        DoubleInput();
    }

    Animator _anim = null;
    protected Animator myAnim
    {
        get
        {
            if (_anim == null)
            {
                _anim = this.GetComponentInChildren<Animator>();
            }
            return _anim;
        }
    }
    public Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3
        (
            Mathf.Clamp(position.x, -20.0f, 18.5f), Mathf.Clamp(position.y, -8.8f, 2.6f), 0  //맵 거리 이동 제한 
        );
    }
    float? CurHP = null;

    public bool UpdateHP(float data)
    {
        if (CurHP == null)
        {
            CurHP = SwordEnemyData.GetMaxHP();
        }
        CurHP += data;
        if (CurHP < 0.0f)
        {
            CurHP = 0.0f;
            return false;
        }
        return true;
    }

    public bool IsLive()
    {
        return myEnemyState == State.BATTLE;
    }

    public void SetTarget(Transform target)
    {
        myAnim.SetBool("Run", true);
        ChangeState(State.BATTLE);
    }

    public void OnDamage()
    {
        if (myEnemyState == State.DEAD) return;
        Damage = SwordEnemyData.MaxHP - myDamageData.GetDamage(mylevel);
        if (SwordEnemyData.MaxHP <= 0.0f)
        {
            ChangeState(State.DEAD);
        }
        else
        {
            //   StartCoroutine(ColorChange(Color.red, 0.5f));
        }
    }

    IEnumerator ColorChange(Color col, float t)
    {
        Color old = this.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].GetColor("_Color");
        this.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetColor("_Color", col);
        yield return new WaitForSeconds(t);
        this.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetColor("_Color", old);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerWeapon"))
        {
    //        Debug.Log("Player에게 공격 받고있습니다.");
            other.gameObject.GetComponent<Sword>()?.OnAttack();
            Damage = SwordEnemyData.MaxHP - myDamageData.GetDamage(mylevel);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myAnim.SetBool("Run", true); //플레이어가 감지 범위를 벗어 났을때 뛰도록 한다. (플레이어 맹추격)
        }
    }

    public void DoubleInput()
    {
        if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            myAnim.SetBool("Run", false);
            moveSpeed = 0.0f;
        }
        else moveSpeed = 2.0f;
    }

    void ChangeState(State s)
    {
        if (myEnemyState == s) return;
        myEnemyState = s;
        switch (myEnemyState)
        {
            case State.CREATE:
                break;
            case State.BATTLE:
                Vector3 dir = EnemyTarget.transform.position - transform.position;

                dir.Normalize();

                transform.position += dir * moveSpeed * Time.deltaTime;
                myAnim.SetBool("Run", true);
                //myAnim.SetTrigger("Attack");
                break;
            case State.DEAD:
                StopAllCoroutines();
                dieAction?.Invoke(SwordEnemyData.GetScore());
                myAnim.SetTrigger("Dead");
                myAnim.SetBool("Run", false);
                //myAnim.ResetTrigger("Attack");
                // StartCorutine(Disappearing());
                break;
            case State.GAMEOVER:
         //       myAnim.SetTrigger("");
                break;
        }
    }

    void StateProcess()
    {
        switch (myEnemyState)
        {
            case State.CREATE:
                break;
            case State.BATTLE:
                break;
            case State.DEAD:
                break;
            case State.GAMEOVER:
                break;
        }
    }
}
