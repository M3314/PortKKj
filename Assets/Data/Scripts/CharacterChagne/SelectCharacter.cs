using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SelectCharacter : MonoBehaviour
{

    private SelectCharacter SelectCharacterseiruna; //����
    private CharacterChangeManager m_chachange; //���� �Լ��� ĳ���͸� �߰��� 
    GameObject myCharacter;
    public Transform selectposition; //ĳ���Ͱ� ��ȯ�Ǵ� ��� 

    private int ChabetaPrevious;
    // Start is called before the first frame update
    void Start()
    {
        m_chachange = GameObject.Find("CharacterSelect").GetComponent<CharacterChangeManager>();
        GameObject DefaultbetaCharacter = m_chachange.CharacterSelect[0];
       myCharacter =  Instantiate(DefaultbetaCharacter, selectposition);

        ChabetaPrevious = 0;
    }


    public void ChangeCharacter(int ChabetaIndex)
    {

        if (ChabetaIndex != ChabetaPrevious)
        {
            Debug.Log("�÷��̾� ����");
            GameObject CharacterImage = m_chachange.CharacterSelect[ChabetaIndex];
            Instantiate(CharacterImage, selectposition);
            Destroy(selectposition.GetChild(0).gameObject);
            ChabetaPrevious = ChabetaIndex;
        }
    }
    
    /*
    public void ScreenChange()
    {
  //      SceneManager.LoadScene("Cha Info, Inven(Back Menu)");

        if(SceneManager.GetActiveScene().name == "Level scense level 1")
        {
            Destroy(gameObject);
        }

        if (SceneManager.GetActiveScene().name == "In Game 1-1")
        {
            DontDestroyOnLoad(gameObject);
        }

        if (SceneManager.GetActiveScene().name == "Cha Info, Inven(Back Menu)")
        {
            DontDestroyOnLoad(gameObject);
        }

        if(SceneManager.GetActiveScene().name == "Title")
        {
            Destroy(gameObject);
        }


    }
    */
}
