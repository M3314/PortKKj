using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Players;

    private void Awake()
    {
        if (DontDestroyobject.instance.Chaselected == 1)
        {
            Players = Instantiate(Resources.Load("Character/SeiKo_32")) as GameObject;
        }

        if (DontDestroyobject.instance.Chaselected == 2)
        {
            Players = Instantiate(Resources.Load("Character/RUNA_2")) as GameObject;
        }
        
        else return;
    }
    void Update()
    {

    }
}
