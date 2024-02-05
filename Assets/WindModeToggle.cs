using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WindModeToggle : MonoBehaviour
{
    // Start is called before the first frame update
    Toggle toggle1;
    static public bool isWindMode;

    void Start()
    {

        toggle1 = GetComponent<Toggle>();
        Debug.Log(isWindMode);
        toggle1.isOn = isWindMode;
    }


    public void onClicktheToogle()
    {
        if (!toggle1.isOn)
        {
            isWindMode = false;

        }
        else if (toggle1.isOn)
        {
            isWindMode = true;
        }
        Debug.Log(isWindMode);

    }
}

