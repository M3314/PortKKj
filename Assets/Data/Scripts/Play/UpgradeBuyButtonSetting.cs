using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeBuyButtonSetting : MonoBehaviour
{
    public TMP_Text GoldText;
    int Gold = 0;
    // Start is called before the first frame update
    void Start()
    {
        GoldText.text = "350";
    }

public void PressBuyButton()
    {
    //    Gold =nu
        GoldText.text = Gold.ToString();
    }
}
