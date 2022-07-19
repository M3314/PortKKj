using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScripts : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;

    public GameObject[] weapons;
    public GameObject RightHand;
    public GameObject currentWeaponPosition;

    // Start is called before the first frame update
    void Start()
    {
        totalWeapons = RightHand.transform.childCount;
        weapons = new GameObject[totalWeapons];
        
        for (int i = 0; i < totalWeapons; i++)
        {
            weapons[i] = RightHand.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
        currentWeaponPosition = weapons[0];
        currentWeaponIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            if(currentWeaponIndex < totalWeapons -1)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                weapons[currentWeaponIndex].SetActive(true);
                currentWeaponPosition = weapons[currentWeaponIndex];

            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            if (currentWeaponIndex > 0)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                weapons[currentWeaponIndex].SetActive(true);
                currentWeaponPosition = weapons[currentWeaponIndex];
            }
        }
    }
}
