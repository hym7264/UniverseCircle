using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GodModeToggle : MonoBehaviour
{
    // Start is called before the first frame update
    Toggle toggle;
    static public bool isGodMode;
    
    void Start()
    {

        toggle = GetComponent<Toggle>();
        Debug.Log(isGodMode);
        toggle.isOn = isGodMode;
    }


    public void onClickToogle()
    {
        if (!toggle.isOn)
        {
            isGodMode = false;

        }
        else if (toggle.isOn)
        {
            isGodMode = true;
        }
        Debug.Log(isGodMode);

    }
}
