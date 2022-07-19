using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSpawn : MonoBehaviour
{
    public GameObject Weapons = null;
    public GameObject Pistols = null;
    public GameObject WeaponShotguns = null;
    public GameObject WeaponSynthe = null;

    void Awake()
    {
        if (DontDestroyobject.instance.WeaponSelected == 1)
        {
            Weapons = Instantiate(Resources.Load("Weapons Sei/New Folder/Sword")) as GameObject;
            Weapons.transform.parent = GameObject.Find("WeaponSocket").transform;
            Weapons.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            Weapons.transform.localPosition = Vector3.zero;
            Weapons.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            if (SceneManager.GetActiveScene().name == "Cha Info, Inven(Back Menu)") //�κ��丮 ����â���� ���� Į�� �ȶߵ���,
            {
                Destroy(gameObject);
            }
  

        }

        if (DontDestroyobject.instance.WeaponSelected == 2)
        {
            WeaponSynthe = Instantiate(Resources.Load("Weapons Sei/New Folder/Synthe")) as GameObject;
            WeaponSynthe.transform.parent = GameObject.Find("WeaponSocket").transform;
            WeaponSynthe.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            WeaponSynthe.transform.localPosition = Vector3.zero;
            WeaponSynthe.transform.localScale = new Vector3(-1.8f, 1.8f, 1.8f);
            if (SceneManager.GetActiveScene().name == "Cha Info, Inven(Back Menu)")
            {
                Destroy(gameObject);
            }
  
        }
        if (DontDestroyobject.instance.WeaponSelected == 3)
        {
            Pistols = Instantiate(Resources.Load("Weapons Sei/New Folder/Pistol")) as GameObject;
            Pistols.transform.parent = GameObject.Find("WeaponSocketGuns").transform;
            Pistols.transform.localPosition = Vector3.zero;
            Pistols.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            Pistols.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            if (SceneManager.GetActiveScene().name == "Cha Info, Inven(Back Menu)")
            {
                Destroy(gameObject);
            }
        }
        if (DontDestroyobject.instance.WeaponSelected == 4)
        {
            WeaponShotguns = Instantiate(Resources.Load("Weapons Sei/New Folder/Shot Gun")) as GameObject;
            WeaponShotguns.transform.parent = GameObject.Find("WeaponSocketShotGuns").transform;
            WeaponShotguns.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            WeaponShotguns.transform.localPosition = Vector3.zero;
            WeaponShotguns.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            if (SceneManager.GetActiveScene().name == "Cha Info, Inven(Back Menu)")
            {
                Destroy(gameObject);
            }
        }
        else
            return;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
