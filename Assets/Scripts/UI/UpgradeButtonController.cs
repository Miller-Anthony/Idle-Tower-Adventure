using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonController : MonoBehaviour
{
    [SerializeField] StatStorrage stats;
    [SerializeField] GeneralStats genStats;
    [SerializeField] BigNumber cost;
    [SerializeField] UpgradePanelController panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStart()
    {
        switch (tag)
        {
            case "adventurer":
                cost = new BigNumber(10);
                break;
            case "fighter":
                cost = new BigNumber(10);
                break;
            case "barbarian":
                cost = new BigNumber(1111);
                break;
            case "rogue":
                cost = new BigNumber(11);
                break;
            case "ranger":
                cost = new BigNumber(11);
                break;
            case "monk":
                cost = new BigNumber(11);
                break;
            case "cleric":
                cost = new BigNumber(11);
                break;
            case "bard":
                cost = new BigNumber(11);
                break;
            case "wizzard":
                cost = new BigNumber(11);
                break;
            case "warlock":
                cost = new BigNumber(11);
                break;
            case "sorcerer":
                cost = new BigNumber(11);
                break;
            case "paladin":
                cost = new BigNumber(11);
                break;
            case "druid":
                cost = new BigNumber(11);
                break;
            default:
                break;
        }
    }

    public void Upgrade()
    {
        // Increase the fighter's level
        stats.SetLevel(stats.GetLevel() + 1);

        //if the first level, dont change the stats
        if (stats.GetLevel() == 1)
        {
            return;
        }

        //get the int stats of the fighter to modefy
        BigNumber dmg = stats.LevelStrength();
        BigNumber hp = stats.LevelHealth();

        //calculate and set the damage and health stat increase
        stats.SetStrength((dmg * 1.05f) + 1);
        stats.SetHealth((hp * 1.1f) + 1);


        //set the new speed stat (needs to be updated later to not increase every level)
        if (stats.GetLevel() % 50 == 0)
        {
            stats.SetSpeed(stats.GetSpeed() * 1.1f);
        }
    }

    public void OnButtonPress()
    {
        if (genStats.CheckGold() >= cost)
        {
            //subtract the amount of money used to but the upgrade and increase the cost of the next one
            genStats.SubtractGold(cost);
            cost = cost * 1.1f;

            Upgrade();

            //update the Adventurer UI text
            panel.UpdateText(cost);
        }
    }

    public void LoadLevels(int levels)
    {
        //for the number of levels, level up the given NPC
        for(int i = 0; i < levels; i++)
        {
            cost = cost * 1.1f;

            Upgrade();
        }

        //update the Adventurer UI text
        panel.UpdateText(cost);
    }
}
