using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiscUpgradeButtonController : MonoBehaviour
{
    [SerializeField] GeneralStats genStats;
    [SerializeField] MercenaryManager mManager;
    [SerializeField] BigNumber cost;
    [SerializeField] MiscUpgradeController panel;
    [SerializeField] FloorTracker floors;
    [SerializeField] AutoFloorClearManager autoClear;
    [SerializeField] GameObject autoClearUpgradeButton;
    [SerializeField] SaveManager save;
    [SerializeField] StatStorrage adventurerStats;
    [SerializeField] PowerManager pManager;

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
            case "clearFloorAuto":
                cost = new BigNumber(123456);
                break;
            case "skilledAdventurer":
                cost = new BigNumber(100);
                break;
            case "hireRate":
                cost = new BigNumber(500);
                break;
            case "improveGear":
                cost = new BigNumber(123456);
                break;
            case "strengthInNumbers":
                cost = new BigNumber(100);
                break;
            case "hastePotion":
                cost = new BigNumber(100);
                break;
            case "increasedBounty":
                cost = new BigNumber(100);
                break;
            case "teleport":
                cost = new BigNumber(100);
                break;
            case "autoSpawner":
                cost = new BigNumber(100);
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
            cost = cost * 11.0f;

            switch (tag)
            {
                case "adventurerCount":
                    UpgradeAdventurerCount();
                    break;
                case "clearFloor":
                    floors.ClearFloors();
                    if(genStats.GetBottomFloor() > 50)
                    {
                        gameObject.GetComponent<Button>().interactable = false;
                    }    
                    break;
                case "clearFloorAuto":
                    if (!autoClearUpgradeButton.activeInHierarchy)
                    {
                        autoClearUpgradeButton.SetActive(true);
                    }
                    autoClear.Upgrade();
                    break;
                case "skilledAdventurer":
                    if(genStats.GetSkilledChance() == 0)
                    {
                        genStats.SetSkilledChance(0.05f);
                    }
                    else
                    {
                        genStats.SetSkilledChance(genStats.GetSkilledChance() + 0.005f);
                    }
                    break;
                case "hireRate":
                    mManager.ChangeSpawnTime(0.01f);
                    break;
                case "improveGear":
                    mManager.ChangeGearValue(0.1f);
                    break;
                case "strengthInNumbers":
                    adventurerStats.ChangeStrengthPercent(0.01f);
                    break;
                case "hastePotion":
                    pManager.LevelUp(tag);
                    break;
                case "increasedBounty":
                    pManager.LevelUp(tag);
                    break;
                case "teleport":
                    pManager.LevelUp(tag);
                    break;
                case "autoSpawner":
                    pManager.LevelUp(tag);
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
                case "clearFloorAuto":
                    if(!autoClearUpgradeButton.activeInHierarchy)
                    {
                        autoClearUpgradeButton.SetActive(true);
                    }
                    autoClear.Upgrade();
                    break;
                case "skilledAdventurer":
                    if (genStats.GetSkilledChance() == 0)
                    {
                        genStats.SetSkilledChance(0.05f);
                    }
                    else
                    {
                        genStats.SetSkilledChance(genStats.GetSkilledChance() + 0.005f);
                    }
                    break;
                case "hireRate":
                    mManager.ChangeSpawnTime(0.01f);
                    break;
                case "improveGear":
                    mManager.ChangeGearValue(0.1f);
                    break;
                case "strengthInNumbers":
                    adventurerStats.ChangeStrengthPercent(0.01f);
                    break;
                case "hastePotion":
                    pManager.LevelUp(tag);
                    break;
                case "increasedBounty":
                    pManager.LevelUp(tag);
                    break;
                case "teleport":
                    pManager.LevelUp(tag);
                    break;
                case "autoSpawner":
                    pManager.LevelUp(tag);
                    break;
                default:
                    break;
            }
        }

        //update the Adventurer UI text
        panel.UpdateText(cost);
    }
}
