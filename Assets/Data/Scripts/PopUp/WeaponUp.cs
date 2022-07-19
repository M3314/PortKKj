using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUp : MonoBehaviour
{

    public GameObject Upweapons;
    public GameObject Downweapons;
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
        bool isActive = Upweapons.activeSelf;

        Upweapons.SetActive(!isActive);
        Downweapons.SetActive(false);

    }
}
