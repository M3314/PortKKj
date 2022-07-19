using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipsup : MonoBehaviour
{

    public GameObject Upequips;
    public GameObject Downequips;
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
        bool isActive = Upequips.activeSelf;

        Upequips.SetActive(!isActive);
        Downequips.SetActive(false);
    }
}
