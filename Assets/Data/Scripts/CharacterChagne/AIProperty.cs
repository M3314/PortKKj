using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIProperty : MonoBehaviour
{
    public SwordEnemy Enemy;
    public Sei Seidatas = null;
    public Runa RunaDatas = null;

    public void Start()
    {
        if (DontDestroyobject.instance.Chaselected == 1)
        {
            Seidatas = GameObject.Find("SeiKo_32(Clone)").GetComponent<Sei>();
        }

        if (DontDestroyobject.instance.Chaselected == 2)
        {
            RunaDatas = GameObject.Find("RUNA_2(Clone)").GetComponent<Runa>();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player감지가 되었습니다.");
            Enemy.myAnim.SetTrigger("Attack");

            if(Enemy.HPChange == 0)
            {
                Enemy.myAnim.ResetTrigger("Attack");
                Enemy.myAnim.SetBool("Run", false);
                Enemy.moveSpeed = 0.0f;
            }
        }
    }

}
