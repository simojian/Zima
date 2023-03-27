using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanels : MonoBehaviour
{
    public RectTransform uiTransform;
    private Vector3 startPos;
    public float moveToPos = 1000f;

    public bool reveal = false;
    public bool bottom = false;
    

    private void Start()
    {
        uiTransform = gameObject.GetComponent<RectTransform>();

        startPos = uiTransform.position;
        
            if (bottom) uiTransform.position += new Vector3(0, -moveToPos, 0);
         else uiTransform.position += new Vector3(moveToPos, 0, 0);
        
        
    }

    public void Reveal()
    {
        reveal = true;
    }

    public void movement()
    {
            if (bottom) uiTransform.position = new Vector3( uiTransform.position.x, Mathf.Lerp(uiTransform.position.y, startPos.y, 0.01f), uiTransform.position.z);
         else uiTransform.position = new Vector3(Mathf.Lerp(uiTransform.position.x, startPos.x, 0.01f), uiTransform.position.y, uiTransform.position.z);
    }

    private void Update()
    {
        if(reveal) movement();
    }
}
