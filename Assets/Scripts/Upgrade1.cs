using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade1 : MonoBehaviour
{
    public ClickOnLeaf upgradeObject;
    
    public void UpgradeAmount()
    {
        upgradeObject.removeOnClick *= 2;
    }

    public void UpgradeSpawn()
    {
        upgradeObject.nutSpawnChance += 0.1f;
    }

    public void UpgradeCooldown()
    {
        upgradeObject.maxCoolDown -= 0.1f;
    }
}
