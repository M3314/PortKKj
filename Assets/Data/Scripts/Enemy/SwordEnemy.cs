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
    [SerializeField] public ChaData EnemyTarget;
    public float moveSpeed = 2.0f;
    public EnemyData SwordEnemyData;
    public State myEnemyState = State.CREATE;
    public float attackDelay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState(State.BATTLE);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = EnemyTarget.transform.position - transform.position;

        dir.Normalize();

        transform.position += dir * moveSpeed * Time.deltaTime;


        if (dir == Vector3.left)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }

        if (dir == Vector3.right)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

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

    protected bool UpdateHP(float data)
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

    public void OnDamage(float damage)
    {
        if (!IsLive()) return;
        if (!UpdateHP(-damage))
        {
            ChangeState(State.DEAD);
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerWeapon"))
        {
    //        Debug.Log("Player에게 공격 받고있습니다.");
            other.gameObject.GetComponent<Sword>()?.OnAttack();
        }
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
