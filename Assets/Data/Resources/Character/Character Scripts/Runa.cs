using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runa : MonoBehaviour
{
    public int myLevel;

    // Start is called before the first frame update
    void Start()
    { 
        CharacterSelect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CharacterSelect()
    {
        DontDestroyobject.instance.Chaselected = 2;
    }

}
