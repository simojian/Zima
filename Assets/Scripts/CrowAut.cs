using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowAut : MonoBehaviour
{
    public ClickOnLeaf gameLogic;

    private float timer;
    void Update()
    {
        
        
        if (gameLogic.autoAmount > 0)
        {
            timer += Time.deltaTime;

            if (timer >= gameLogic.currentTimeAuto)
            {
                gameLogic.leafCount -= gameLogic.autoRemove;
                
                timer = 0;
            }
        }
    }
}
