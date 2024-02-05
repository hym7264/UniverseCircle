using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUpDown : MonoBehaviour
{
    public RectTransform uiGroup;

    public void Enter()
    {
        uiGroup.anchoredPosition = Vector3.zero;
    }

    // Update is called once per frame
    public void Exit()
    {
        uiGroup.anchoredPosition = Vector3.down*1500;

    }
}
