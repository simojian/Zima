using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGuide : MonoBehaviour
{

    public MovePanels[] groupPanels;
    public UiReveal[] uiPanels;

    public MovePanels EndGameButton;

    public ClickOnLeaf gameLogic;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameLogic.nutCount >= 1) groupPanels[0].Reveal();
        if(gameLogic.nutCount >= 3) groupPanels[1].Reveal();
        
        if(gameLogic.nutCount >= 3) uiPanels[0].Reveal();
        if(gameLogic.leafCount <= gameLogic.startLeafCount - 100) uiPanels[1].Reveal();
        if(gameLogic.leafCount <= gameLogic.startLeafCount - 50) uiPanels[2].Reveal();
        if(gameLogic.leafCount <= gameLogic.startLeafCount - 500) uiPanels[3].Reveal();
        if(gameLogic.leafCount <= gameLogic.startLeafCount - 1500) uiPanels[4].Reveal();

        if (gameLogic.leafCount <= 0)
        {
            EndGameButton.Reveal();
        }
    }
}
