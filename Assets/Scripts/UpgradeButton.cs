using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public string itemName = "Unkown";
    public int numberOwned = 0;
    public int baseCost = 5;
    public int purchaseCost = 1;
    public int maxBuy = 10;
    public TMP_Text numberText, costText, nameText;
    public ClickOnLeaf upgradeObject;
    public Button upgradeButton;
    
    public bool finished = false;
    
    // Start is called before the first frame update
    void Start()
    {
        InnitUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (upgradeObject.nutCount >= purchaseCost && (numberOwned < maxBuy))
        {
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
        }

        if (numberOwned >= maxBuy)
        {
            numberText.text = "MAX";
            finished = true;
        }
    }

    public void InnitUI()
    {
        purchaseCost = Calculation.ExponentialRise(baseCost, numberOwned);
        gameObject.name = itemName;
        nameText.text = itemName;
        numberText.text = numberOwned.ToString() + " / " + maxBuy.ToString();
        costText.text = "Cost: " + purchaseCost.ToString();
    }

    public void PurchaseItem()
    {
            upgradeObject.nutCount -= purchaseCost;
            numberOwned++;
            InnitUI();
    }
    
    public void UpgradeAmount()
    {
        upgradeObject.removeOnClick *= 2;
    }

    public void UpgradeSpawn()
    {
        upgradeObject.nutSpawnChance += 0.3f;
    }

    public void UpgradeCooldown()
    {
        upgradeObject.maxCoolDown -= 0.2f;
    }

    public void UpgradeAutoclick()
    {
        upgradeObject.AutoLeafInnit();
    }

    public void UpgradeDecay()
    {
        upgradeObject.NutDecayUpgrade();
    }
}
