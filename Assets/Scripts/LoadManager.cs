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
    [SerializeField] LootDisplayController swordController;
    [SerializeField] LootDisplayController shieldController;
    [SerializeField] LootDisplayController walletController;
    [SerializeField] ChestTracker chests;
    [SerializeField] RoomFactory factory;

    //data to load
    private int highestFloor;
    private int topFloor;
    private BigNumber gold;
    private int clearedFloorLevel;
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
    private int swordLoot;
    private int shieldLoot;
    private int walletLoot;
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
                gold = new BigNumber(decimal.Parse(data[2]), int.Parse(data[3]));
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
                swordLoot = int.Parse(data[19]);
                shieldLoot = int.Parse(data[20]);
                walletLoot = int.Parse(data[21]);
                chestCount = int.Parse(data[22].Substring(0, 3));

                chestList = new int[chestCount];

                //grab all the chests
                for (int i = 0; i < chestCount; i++)
                {
                    chestList[i] = int.Parse(data[12].Substring(5 + (6 * i), 5));
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
                swordController.Setlooted(swordLoot);
                shieldController.Setlooted(shieldLoot);
                walletController.Setlooted(walletLoot);

            }
            gameObject.GetComponent<LoadManager>().enabled = false;
        }
        catch
        {
            gameObject.GetComponent<LoadManager>().enabled = false;
        }
        
    }
}
