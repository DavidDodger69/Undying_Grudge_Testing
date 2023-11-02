using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Controller : MonoBehaviour
{
    public SoulIcon SoulIcon;
    public int Upgrades_Unlocked = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shift") && SoulIcon.enemyRaiseCount == SoulIcon.maxEnemies)
        {
            UnlockUpgrade();
        }
    }

    void UnlockUpgrade()
    {

    }
}
