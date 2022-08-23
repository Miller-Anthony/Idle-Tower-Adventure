using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadManager : MonoBehaviour
{
    //Places to load data to
    [SerializeField] GeneralStats genStats;
    [SerializeField] UpgradeButtonController adventurerButton;
    [SerializeField] UpgradeButtonController fighterButton;
    [SerializeField] UpgradeButtonController barbarianButton;
    [SerializeField] UpgradeButtonController rogueButton;
    [SerializeField] UpgradeButtonController rangerButton;
    [SerializeField] UpgradeButtonController monkButton;
    [SerializeField] UpgradeButtonController clericButton;
    [SerializeField] UpgradeButtonController bardButton;
    [SerializeField] UpgradeButtonController wizzardButton;
    [SerializeField] UpgradeButtonController warlockButton;
    [SerializeField] UpgradeButtonController sorcererButton;
    [SerializeField] UpgradeButtonController paladinButton;
    [SerializeField] UpgradeButtonController druidButton;
    [SerializeField] MiscUpgradeButtonController adventurerCountButton;
    [SerializeField] MiscUpgradeButtonController clearedFloorButton;
    [SerializeField] MiscUpgradeButtonController clearedFloorAutoButton;
    [SerializeField] MiscUpgradeButtonController skilledAdventurerController;
    [SerializeField] MiscUpgradeButtonController hireRateController;
    [SerializeField] MiscUpgradeButtonController improveGearController;
    [SerializeField] MiscUpgradeButtonController strengthInNumbersController;
    [SerializeField] MiscUpgradeButtonController hastePotionController;
    [SerializeField] MiscUpgradeButtonController increasedBountyController;
    [SerializeField] MiscUpgradeButtonController teleportController;
    [SerializeField] MiscUpgradeButtonController autoSpawnerController;
    [SerializeField] LootTracker loot;
    [SerializeField] ChestTracker chests;
    [SerializeField] RoomFactory factory;

    //data to load
    private int highestFloor;
    private int topFloor;
    private BigNumber gold;
    private int fighterLevel;
    private int barbarianLevel;
    private int rogueLevel;
    private int rangerLevel;
    private int monkLevel;
    private int clericLevel;
    private int bardLevel;
    private int wizzardLevel;
    private int warlockLevel;
    private int sorcererLevel;
    private int paladinLevel;
    private int druidLevel;
    private int adventurerLevel;
    private int adventurerCount;
    private int clearedFloorLevel;
    private int clearedFloorAutoLevel;
    private float skilledChance;
    private float spawnPercent;
    private float improveGearLevel;
    private float strengthInNumbersLevel;
    private int hastePotionLevel;
    private int increasedBountyLevel;
    private int teleportLevel;
    private int autoSpawnerLevel;
    private int swordLoot;
    private int longSwordLoot;
    private int spearLoot;
    private int daggerLoot;
    private int shieldLoot;
    private int helmetLoot;
    private int breastplateLoot;
    private int gauntletsLoot;
    private int magnifyingGlassLoot;
    private int tomeOfLuckLoot;
    private int gemPouchLoot;
    private int walletLoot;
    private int alchemyKitLoot;
    private int largeVialLoot;
    private int highQualityIngredientsLoot;
    private int ringOfWishesLoot;
    private int amuletOfTimeLoot;
    private int glovesOfMidasLoot;
    private int manaPotionLoot;
    private int magicFocusLoot;
    private int tomeOfIntelegenceLoot;
    private int summonersRobeLoot;
    private int summonersRingLoot;
    private int summonersStaffLoot;
    private int tomeOfCharismaLoot;
    private int loadedDiceLoot;
    private int tomeOfStrengthLoot;
    private int swiftBootsLoot;
    private int tomeOfDexterityLoot;
    private int poisonVialLoot;
    private int tomeOfEnduranceLoot;
    private int sharpeningStoneLoot;
    private int investmentsLoot;
    private int adventuringVoucherLoot;
    private int dungeonMapLoot;
    private int portalStoneLoot;
    private int pendantOfTheDawnLoot;
    private int year;
    private int month;
    private int day;
    private int hour;
    private int minute;
    private int second;
    private int chestCount;
    private int[] chestList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoadGame();
    }

    public void LoadGame()
    {
        try
        {
            if (File.Exists(Application.persistentDataPath + "\\Save.txt"))
            {
                //variable to be used later
                GameObject holder;

                //Get data from the save file
                string[] data = File.ReadAllLines(Application.persistentDataPath + "\\Save.txt");

                //Parse save data
                highestFloor = int.Parse(data[0]);
                topFloor = int.Parse(data[1]);
                gold = new BigNumber(int.Parse(data[2]));
                adventurerLevel = int.Parse(data[3]);
                fighterLevel = int.Parse(data[4]);
                barbarianLevel = int.Parse(data[5]);
                rogueLevel = int.Parse(data[6]);
                rangerLevel = int.Parse(data[7]);
                monkLevel = int.Parse(data[8]);
                clericLevel = int.Parse(data[9]);
                bardLevel = int.Parse(data[10]);
                wizzardLevel = int.Parse(data[11]);
                warlockLevel = int.Parse(data[12]);
                sorcererLevel = int.Parse(data[13]);
                paladinLevel = int.Parse(data[14]);
                druidLevel = int.Parse(data[15]);
                adventurerCount = int.Parse(data[16]);
                clearedFloorLevel = int.Parse(data[17]);
                clearedFloorAutoLevel = int.Parse(data[18]);
                skilledChance = float.Parse(data[19]);
                spawnPercent = float.Parse(data[20]);
                improveGearLevel = float.Parse(data[21]);
                strengthInNumbersLevel = float.Parse(data[22]);
                hastePotionLevel = int.Parse(data[23]);
                increasedBountyLevel = int.Parse(data[24]);
                teleportLevel = int.Parse(data[25]);
                autoSpawnerLevel = int.Parse(data[26]);
                swordLoot = int.Parse(data[27]);
                longSwordLoot = int.Parse(data[28]);
                spearLoot = int.Parse(data[29]);
                daggerLoot = int.Parse(data[30]);
                shieldLoot = int.Parse(data[31]);
                helmetLoot = int.Parse(data[32]);
                breastplateLoot = int.Parse(data[33]);
                gauntletsLoot = int.Parse(data[34]);
                magnifyingGlassLoot = int.Parse(data[35]);
                tomeOfLuckLoot = int.Parse(data[36]);
                gemPouchLoot = int.Parse(data[37]);
                walletLoot = int.Parse(data[38]);
                alchemyKitLoot = int.Parse(data[39]);
                largeVialLoot = int.Parse(data[40]);
                highQualityIngredientsLoot = int.Parse(data[41]);
                ringOfWishesLoot = int.Parse(data[42]);
                amuletOfTimeLoot = int.Parse(data[43]);
                glovesOfMidasLoot = int.Parse(data[44]);
                manaPotionLoot = int.Parse(data[45]);
                magicFocusLoot = int.Parse(data[46]);
                tomeOfIntelegenceLoot = int.Parse(data[47]);
                summonersRobeLoot = int.Parse(data[48]);
                summonersRingLoot = int.Parse(data[49]);
                summonersStaffLoot = int.Parse(data[50]);
                tomeOfCharismaLoot = int.Parse(data[51]);
                loadedDiceLoot = int.Parse(data[52]);
                tomeOfStrengthLoot = int.Parse(data[53]);
                swiftBootsLoot = int.Parse(data[54]);
                tomeOfDexterityLoot = int.Parse(data[55]);
                poisonVialLoot = int.Parse(data[56]);
                tomeOfEnduranceLoot = int.Parse(data[57]);
                sharpeningStoneLoot = int.Parse(data[58]);
                investmentsLoot = int.Parse(data[59]);
                adventuringVoucherLoot = int.Parse(data[60]);
                dungeonMapLoot = int.Parse(data[61]);
                portalStoneLoot = int.Parse(data[62]);
                pendantOfTheDawnLoot = int.Parse(data[63]);
                year = int.Parse(data[64].Substring(0, 4));
                month = int.Parse(data[64].Substring(5, 2));
                day = int.Parse(data[64].Substring(8, 2));
                hour = int.Parse(data[64].Substring(11, 2));
                minute = int.Parse(data[64].Substring(14, 2));
                second = int.Parse(data[64].Substring(17, 2));
                chestCount = int.Parse(data[65].Substring(0, 3));

                chestList = new int[chestCount];

                //grab all the chests
                for (int i = 0; i < chestCount; i++)
                {
                    chestList[i] = int.Parse(data[65].Substring(5 + (6 * i), 5));
                }

                //spawn all the floors needed
                for (int i = 1; i < topFloor - 1; i++)
                {
                    holder = factory.BuildNextFloor(true);
                    factory = holder.GetComponentInChildren<RoomFactory>();
                    factory.Load();
                }

                if (topFloor > 1)
                {
                    holder = factory.BuildNextFloor();
                    factory = holder.GetComponentInChildren<RoomFactory>();
                    factory.Load();
                }

                //Load the save data into the game
                genStats.SetHighestFloor(highestFloor);
                genStats.AddGold(gold);
                adventurerButton.LoadLevels(adventurerLevel - 1);
                fighterButton.LoadLevels(fighterLevel);
                barbarianButton.LoadLevels(barbarianLevel);
                rogueButton.LoadLevels(rogueLevel);
                rangerButton.LoadLevels(rangerLevel);
                monkButton.LoadLevels(monkLevel);
                clericButton.LoadLevels(clericLevel);
                bardButton.LoadLevels(bardLevel);
                wizzardButton.LoadLevels(wizzardLevel);
                warlockButton.LoadLevels(warlockLevel);
                sorcererButton.LoadLevels(sorcererLevel);
                paladinButton.LoadLevels(paladinLevel);
                druidButton.LoadLevels(druidLevel);
                adventurerCountButton.LoadLevels(adventurerCount - 5);
                clearedFloorButton.LoadLevels((clearedFloorLevel - 1) / 10);
                clearedFloorAutoButton.LoadLevels(-(clearedFloorAutoLevel - 19));
                
                if(skilledChance == 0)
                {
                    skilledAdventurerController.LoadLevels((int)skilledChance);
                }
                else 
                {
                    float num = (skilledChance * 100);
                    num -= 5;
                    num *= 2;
                    skilledAdventurerController.LoadLevels((int)++num);
                }

                spawnPercent -= 1;
                spawnPercent *= 100;
                hireRateController.LoadLevels((int)spawnPercent);

                improveGearLevel -= 1;
                improveGearLevel *= 10;
                improveGearController.LoadLevels((int)improveGearLevel);

                strengthInNumbersLevel *= 100;
                strengthInNumbersController.LoadLevels((int)strengthInNumbersLevel);

                hastePotionController.LoadLevels(hastePotionLevel);
                increasedBountyController.LoadLevels(increasedBountyLevel);
                teleportController.LoadLevels(teleportLevel);
                autoSpawnerController.LoadLevels(autoSpawnerLevel);
                loot.GetController("sword").Setlooted(swordLoot);
                loot.GetController("longSword").Setlooted(longSwordLoot);
                loot.GetController("spear").Setlooted(spearLoot);
                loot.GetController("dagger").Setlooted(daggerLoot);
                loot.GetController("shield").Setlooted(shieldLoot);
                loot.GetController("helmet").Setlooted(helmetLoot);
                loot.GetController("breastplate").Setlooted(breastplateLoot);
                loot.GetController("gauntlets").Setlooted(gauntletsLoot);
                loot.GetController("magnifyingGlass").Setlooted(magnifyingGlassLoot);
                loot.GetController("tomeOfLuck").Setlooted(tomeOfLuckLoot);
                loot.GetController("gemPouch").Setlooted(gemPouchLoot);
                loot.GetController("wallet").Setlooted(walletLoot);
                loot.GetController("alchemyKit").Setlooted(alchemyKitLoot);
                loot.GetController("largeVial").Setlooted(largeVialLoot);
                loot.GetController("highQualityIngredients").Setlooted(highQualityIngredientsLoot);
                loot.GetController("ringOfWishes").Setlooted(ringOfWishesLoot);
                loot.GetController("amuletOfTime").Setlooted(amuletOfTimeLoot);
                loot.GetController("glovesOfMidas").Setlooted(glovesOfMidasLoot);
                loot.GetController("manaPotion").Setlooted(manaPotionLoot);
                loot.GetController("magicFocus").Setlooted(magicFocusLoot);
                loot.GetController("tomeOfIntelegence").Setlooted(tomeOfIntelegenceLoot);
                loot.GetController("summonersRobe").Setlooted(summonersRobeLoot);
                loot.GetController("summonersRing").Setlooted(summonersRingLoot);
                loot.GetController("summonersStaff").Setlooted(summonersStaffLoot);
                loot.GetController("tomeOfCharisma").Setlooted(tomeOfCharismaLoot);
                loot.GetController("loadedDice").Setlooted(loadedDiceLoot);
                loot.GetController("tomeOfStrength").Setlooted(tomeOfStrengthLoot);
                loot.GetController("swiftBoots").Setlooted(swiftBootsLoot);
                loot.GetController("tomeOfDexterity").Setlooted(tomeOfDexterityLoot);
                loot.GetController("poisonVial").Setlooted(poisonVialLoot);
                loot.GetController("tomeOfEndurance").Setlooted(tomeOfEnduranceLoot);
                loot.GetController("sharpeningStone").Setlooted(sharpeningStoneLoot);
                loot.GetController("investments").Setlooted(investmentsLoot);
                loot.GetController("adventuringVoucher").Setlooted(adventuringVoucherLoot);
                loot.GetController("dungeonMap").Setlooted(dungeonMapLoot);
                loot.GetController("portalStone").Setlooted(portalStoneLoot);
                loot.GetController("pendantOfTheDawn").Setlooted(pendantOfTheDawnLoot);
                genStats.OfflineGold(year, month, day, hour, minute, second);
            }
            gameObject.GetComponent<LoadManager>().enabled = false;
        }
        catch
        {
            gameObject.GetComponent<LoadManager>().enabled = false;
        }
        
    }

    
}
