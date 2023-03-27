using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public Button buttonComponent;

    public GameObject gameLogic;

    public Texture2D cursorTexture;

    public Color targetColor = new Color(0, 0, 0, 0);

    private ClickOnLeaf cLScript;

    private float cooldownTimer;
    public float maxCooldown = 1.0f;

    private float cooldownDivider;
    public int timerStagesTotal = 12;
    public int timerStage = 0;

    

    public Image imgComponet;
    public Sprite[] treeStages = new Sprite[4];
    public float leafStages;
    public int currentStage = 0;

    private float colorLerpT;

    private void Start()
    {
        buttonComponent = gameObject.GetComponent<Button>();

        cLScript = gameLogic.GetComponent<ClickOnLeaf>();

        imgComponet = gameObject.GetComponent<Image>();

        leafStages = cLScript.startLeafCount / treeStages.Length;
        
        
    }

    public void Update()
    {
        if (cLScript.leafCount <= 0)
        {
            Destroy(buttonComponent.gameObject);
        }
        
        maxCooldown = cLScript.maxCoolDown;if (cooldownTimer >= 0.0f)
                                                       {
                                                           cooldownTimer -= 1 * Time.deltaTime;
                                           
                                                           buttonComponent.interactable = false;
                                           
                                                           timerStage = (int)(cooldownTimer / cooldownDivider);
                                           
                                                       }
                                                       else
                                                       {
                                                           buttonComponent.interactable = true;
                                           
                                                           timerStage = 12;
                                                       }


        cooldownDivider = maxCooldown / timerStagesTotal;


        if (maxCooldown > 0)
        {
            
            if (maxCooldown < 0.05f)
            {
                timerStage = 12;
            }
        }
        else
        {
            buttonComponent.interactable = true;
        }


        currentStage = Mathf.CeilToInt(cLScript.leafCount / leafStages) - 1;

        imgComponet.sprite = treeStages[currentStage];

        colorLerpT = (float) cLScript.leafCount / cLScript.startLeafCount;

        imgComponet.color = Color.Lerp(targetColor, Color.white, colorLerpT);

        


    }

    public void CoolDownInnit()
    {
        cooldownTimer = maxCooldown;
    }

    /*public void OnMouseEnter()
    {
        isOnCrown = true;
    }

    public void OnMouseExit()
    {
        isOnCrown = false;
    }*/
}
