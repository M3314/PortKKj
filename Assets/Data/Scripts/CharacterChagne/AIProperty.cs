using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIProperty : MonoBehaviour
{
    public GameObject Enemy;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player감지가 되었습니다.");
        }
    }

}
