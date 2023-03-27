using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class toolTip : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public LayoutElement layoutElement;
    public int charLimit;

    private void Update()
    {

        int textLenght = textField.text.Length;

        layoutElement.enabled = (textLenght > charLimit) ? true : false;
    }
}
