using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDown : MonoBehaviour
{

    public GameObject Downweapons;
    public GameObject Upweapons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpLayerOnActive()
    {
        bool isActive = Downweapons.activeSelf;

        Downweapons.SetActive(!isActive);
        Upweapons.SetActive(false);


    }
}
