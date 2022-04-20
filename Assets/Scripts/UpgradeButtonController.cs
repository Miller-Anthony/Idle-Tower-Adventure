using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonController : MonoBehaviour
{
    [SerializeField] StatStorrage stats;
    [SerializeField] GeneralStats genStats;
    [SerializeField] int cost;
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
        stats.SetStrength(Mathf.FloorToInt((dmg * 1.1f) + 1));
        stats.SetHealth(Mathf.FloorToInt((hp * 1.1f) + 1));
        

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

        //calculate and set the damage and health stat increase
        
        stats.SetStrength(Mathf.FloorToInt((dmg * 1.05f) + 1));
        stats.SetHealth(Mathf.FloorToInt((hp * 1.1f) + 1));
        

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
            genStats.SubtractGold(cost);
            cost = (int)(cost * 1.1f);

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
