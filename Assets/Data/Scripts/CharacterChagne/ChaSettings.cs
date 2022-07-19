using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class ChaSettings : MonoBehaviour
{
    private SelectCharacter chaalphaCha;

    void Start()
    {
        chaalphaCha = GameObject.Find("SelectingCharacter").GetComponent<SelectCharacter>();
   
    }

    // Update is called once per frame
    public void CharacterChangeButton()
    {
        GameObject CharacterImagee = EventSystem.current.currentSelectedGameObject;
        int tempBtnIndex = CharacterImagee.transform.GetSiblingIndex();

           Debug.Log(CharacterImagee + " : " + tempBtnIndex);
        chaalphaCha.ChangeCharacter(tempBtnIndex);
        ChaData.instance.characterscurrentss = (Characters)tempBtnIndex;
        
        return;
    }


}
