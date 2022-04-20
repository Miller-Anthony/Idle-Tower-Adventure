using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonController : MonoBehaviour
{
    [SerializeField] StatStorrage stats;
    [SerializeField] GeneralStats genStats;
    [SerializeField] float cost;
    [SerializeField] UpgradePanelController panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeAdventurer()
    {
        //get the int stats of the adventurer to modefy
        int dmg = stats.GetStrength();
        int hp = stats.GetHealth();

        //calculate and set the damage stat increase
        if (Mathf.FloorToInt((float)dmg * 1.1f) < dmg + 1)
        {
            dmg++;
            stats.SetStrength(dmg);
        }
        else
        {
            stats.SetStrength(Mathf.FloorToInt((float)dmg * 1.1f));
        }

        //calculate and set the health stat increase
        if (Mathf.FloorToInt((float)hp * 1.1f) < hp + 1)
        {
            hp++;
            stats.SetHealth(hp);
        }
        else
        {
            stats.SetHealth(Mathf.FloorToInt((float)hp * 1.1f));
        }

        //set the new speed stat (needs to be updated later to not increase every level)
        if (stats.GetLevel() % 50 == 0)
        {
            stats.SetSpeed(stats.GetSpeed() * 1.1f);
        }

        // Increase the Adventurers level
        stats.SetLevel(stats.GetLevel() + 1);
    }

    public void UpgradeFighter()
    {
        //get the int stats of the fighter to modefy
        int dmg = stats.GetStrength();
        int hp = stats.GetHealth();

        //calculate and set the damage stat increase
        if (Mathf.FloorToInt((float)dmg * 1.1f) < dmg + 1)
        {
            dmg++;
            stats.SetStrength(dmg);
        }
        else
        {
            stats.SetStrength(Mathf.FloorToInt((float)dmg * 1.1f));
        }

        //calculate and set the health stat increase
        if (Mathf.FloorToInt((float)hp * 1.1f) < hp + 1)
        {
            hp++;
            stats.SetHealth(hp);
        }
        else
        {
            stats.SetHealth(Mathf.FloorToInt((float)hp * 1.1f));
        }

        //set the new speed stat (needs to be updated later to not increase every level)
        if (stats.GetLevel() % 50 == 0)
        {
            stats.SetSpeed(stats.GetSpeed() * 1.1f);
        }

        // Increase the fighter's level
        stats.SetLevel(stats.GetLevel() + 1);
    }

    public void OnButtonPress()
    {
        if(genStats.CheckGold() >= cost)
        {
            //subtract the amount of money used to but the upgrade and increase the cost of the next one
            genStats.SubtractGold((int)cost);
            cost *= 1.1f;

            switch(gameObject.tag)
            {
                case "adventurer":
                    UpgradeAdventurer();
                    break;
                case "fighter":
                    UpgradeFighter();
                    break;
                default:
                    break;
            }

            //update the Adventurer UI text
            panel.UpdateText((int)cost);
        }
    }
}
