using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipsDown : MonoBehaviour
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
        bool isActive = Downequips.activeSelf;

        Downequips.SetActive(!isActive);
        Upequips.SetActive(false);
    }
}
