using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectingg : MonoBehaviour
{
    public Characters character;
    Animator Anim;
    public SelectCharacter[] chars;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();

    }
    /*
   void OnSelect()
    {
        
    }

    void OnDeSelect()
    {
        Debug.Log("º±≈√ æ»µ .");
    }
    */
    private void OnMouseUpAsButton()
    {
        ChaData.instance.characterscurrentss = character;

    }


}
