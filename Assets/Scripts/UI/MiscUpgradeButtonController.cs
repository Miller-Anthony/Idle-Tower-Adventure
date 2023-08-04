using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class MiscUpgradeButtonController : MonoBehaviour
{
    [SerializeField] GeneralStats genStats;
    [SerializeField] MercenaryManager mManager;
    [SerializeField] BigInteger cost;
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
                cost = new BigInteger(1000);
                break;
            case "clearFloor":
                cost = new BigInteger(25000);
                break;
            case "clearFloorAuto":
                cost = new BigInteger(25000000);
                break;
            case "skilledAdventurer":
                cost = new BigInteger(500000);
                break;
            case "hireRate":
                cost = new BigInteger(50000);
                break;
            case "improveGear":
                cost = new BigInteger(80000);
                break;
            case "strengthInNumbers":
                cost = new BigInteger(2000000);
                break;
            case "hastePotion":
                cost = new BigInteger(25000);
                break;
            case "increasedBounty":
                cost = new BigInteger(1000000);
                break;
            case "teleport":
                cost = new BigInteger(500000000);
                break;
            case "autoSpawner":
                cost = new BigInteger(555555555555);
                break;
            case "rebirth":
                cost = new BigInteger(1111111111);
                break;
            default:
                break;
        }
        
        //update the UI cost text
        panel.UpdateText(cost);
    }

    public void UpgradeAdventurerCount()
    {
        genStats.SetMaxAdventurers(genStats.GetMaxAdventurers() + 1);
    }

    

    public void OnButtonPress()
    {
        if (genStats.CheckGold() >= cost)
        {
            switch(tag)
            {
                case "clearFloor":
                    if (genStats.GetTopFloor() - 20 < genStats.GetBottomFloor())
                    {
                        return;
                    }
                    break;
                case "clearFloorAuto":
                    if (genStats.GetTopFloor() < 80)
                    {
                        return;
                    }
                    break;
                default:
                    break;
            }
            
            //subtract the amount of money used to but the upgrade and increase the cost of the next one
            genStats.SubtractGold(cost);
            cost = cost * 10;

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
                    
                    if(mManager.GetSpawnPercent() >= 1.25f)
                    {
                        gameObject.GetComponent<Button>().interactable = false;
                    }
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
            cost = cost * 10;

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

                    if (mManager.GetSpawnPercent() >= 1.25f)
                    {
                        gameObject.GetComponent<Button>().interactable = false;
                    }
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
