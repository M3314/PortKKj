using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroyobject : MonoBehaviour
{
    public  static DontDestroyobject instance = null;

    public void Start()
    {

    }

    public void Update()
    {

    }


    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
     else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    public int Chaselected = 0;
    public int WeaponSelected = 0;
    public int GoldInfo = 350;
    public int LevelInfo = 1;
    public int weaponlevelinfo = 1;

}
