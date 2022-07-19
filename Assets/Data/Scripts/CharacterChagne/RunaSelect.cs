using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunaSelect : MonoBehaviour
{
    public TMPro.TMP_Text myLabelname;
    public Button pushButton;
    
    // Start is called before the first frame update
    void Start()
    {
       myLabelname.text = "Runa";

    }

    // Update is called once per frame


    public void testSetActive()
    {

        myLabelname.text = "Runa";
    }


}
