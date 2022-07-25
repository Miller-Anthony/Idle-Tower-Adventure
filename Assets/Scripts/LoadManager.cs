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
    [SerializeField] LootDisplayController swordController;
    [SerializeField] LootDisplayController longSwordController;
    [SerializeField] LootDisplayController shieldController;
    [SerializeField] LootDisplayController helmetController;
    [SerializeField] LootDisplayController magnifyingGlassController;
    [SerializeField] LootDisplayController walletController;
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
    private int shieldLoot;
    private int helmetLoot;
    private int magnifyingGlassLoot;
    private int walletLoot;
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
                gold = new BigNumber(double.Parse(data[2]), int.Parse(data[3]));
                adventurerLevel = int.Parse(data[4]);
                fighterLevel = int.Parse(data[5]);
                barbarianLevel = int.Parse(data[6]);
                rogueLevel = int.Parse(data[7]);
                rangerLevel = int.Parse(data[8]);
                monkLevel = int.Parse(data[9]);
                clericLevel = int.Parse(data[10]);
                bardLevel = int.Parse(data[11]);
                wizzardLevel = int.Parse(data[12]);
                warlockLevel = int.Parse(data[13]);
                sorcererLevel = int.Parse(data[14]);
                paladinLevel = int.Parse(data[15]);
                druidLevel = int.Parse(data[16]);
                adventurerCount = int.Parse(data[17]);
                clearedFloorLevel = int.Parse(data[18]);
                clearedFloorAutoLevel = int.Parse(data[19]);
                skilledChance = float.Parse(data[20]);
                spawnPercent = float.Parse(data[21]);
                improveGearLevel = float.Parse(data[22]);
                strengthInNumbersLevel = float.Parse(data[23]);
                hastePotionLevel = int.Parse(data[24]);
                increasedBountyLevel = int.Parse(data[25]);
                teleportLevel = int.Parse(data[26]);
                autoSpawnerLevel = int.Parse(data[27]);
                swordLoot = int.Parse(data[28]);
                longSwordLoot = int.Parse(data[29]);
                shieldLoot = int.Parse(data[30]);
                helmetLoot = int.Parse(data[31]);
                magnifyingGlassLoot = int.Parse(data[32]);
                walletLoot = int.Parse(data[33]);
                year = int.Parse(data[34].Substring(0, 4));
                month = int.Parse(data[34].Substring(5, 2));
                day = int.Parse(data[34].Substring(8, 2));
                hour = int.Parse(data[34].Substring(11, 2));
                minute = int.Parse(data[34].Substring(14, 2));
                second = int.Parse(data[34].Substring(17, 2));
                chestCount = int.Parse(data[35].Substring(0, 3));

                chestList = new int[chestCount];

                //grab all the chests
                for (int i = 0; i < chestCount; i++)
                {
                    chestList[i] = int.Parse(data[35].Substring(5 + (6 * i), 5));
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
                swordController.Setlooted(swordLoot);
                shieldController.Setlooted(shieldLoot);
                walletController.Setlooted(walletLoot);
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
