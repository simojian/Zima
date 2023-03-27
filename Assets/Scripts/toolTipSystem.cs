using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolTipSystem : MonoBehaviour
{
    private static toolTipSystem current;

    public toolTip tooltip;

    public void Awake()
    {
        current = this;
    }

    public static void Show()
    {
        current.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        current.tooltip.gameObject.SetActive(false);
    }
}
