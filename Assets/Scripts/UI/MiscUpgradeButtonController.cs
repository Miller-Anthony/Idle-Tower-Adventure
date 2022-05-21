using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscUpgradeButtonController : MonoBehaviour
{
    [SerializeField] GeneralStats genStats;
    [SerializeField] BigNumber cost;
    [SerializeField] MiscUpgradeController panel;
    [SerializeField] FloorTracker floors;
    [SerializeField] SaveManager save;

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
            case "adventurerCount":
                cost = new BigNumber(100);
                break;
            case "clearFloor":
                cost = new BigNumber(500);
                break;
            case "rebirth":
                cost = new BigNumber(123456);
                break;
            default:
                break;
        }
    }

    public void UpgradeAdventurerCount()
    {
        genStats.SetMaxAdventurers(genStats.GetMaxAdventurers() + 1);
    }

    

    public void OnButtonPress()
    {
        if (genStats.CheckGold() >= cost)
        {
            if(tag == "clearFloor" && genStats.GetTopFloor() - 20 < genStats.GetBottomFloor())
            {
                return;
            }
            //subtract the amount of money used to but the upgrade and increase the cost of the next one
            genStats.SubtractGold(cost);
            cost = cost * 10.0f;

            switch (tag)
            {
                case "adventurerCount":
                    UpgradeAdventurerCount();
                    break;
                case "clearFloor":
                    floors.ClearFloors();
                    break;
                case "rebirth":
                    save.Rebirth();
                    break;
                default:
                    break;
            }

            //update the Adventurer UI text
            panel.UpdateText(cost);
        }
    }

    //load the amount of upgrades bought for the given upgrade
    public void LoadLevels(int levels)
    {
        //for the numbers of levels, level up the upgrade
        for (int i = 0; i < levels; i++)
        {
            cost = cost * 10.0f;

            switch (tag)
            {
                case "adventurerCount":
                    UpgradeAdventurerCount();
                    break;
                case "clearFloor":
                    floors.ClearFloors();
                    break;
                default:
                    break;
            }
        }

        //update the Adventurer UI text
        panel.UpdateText(cost);
    }
}
