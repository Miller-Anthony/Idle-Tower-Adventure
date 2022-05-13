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
    private int gold;
    private int adventurerLevel;
    private int adventurerCount;
    private int clearedFloorLevel;
    private int fighterLevel;
    private int barbarianLevel;
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
        if (File.Exists(Application.persistentDataPath + "\\Save.txt"))
        {
            //variable to be used later
            GameObject holder;

            //Get data from the save file
            string[] data = File.ReadAllLines(Application.persistentDataPath + "\\Save.txt");

            //Parse save data
            highestFloor = int.Parse(data[0]);
            topFloor = int.Parse(data[1]);
            gold = int.Parse(data[2]);
            adventurerLevel = int.Parse(data[3]);
            fighterLevel = int.Parse(data[4]);
            barbarianLevel = int.Parse(data[5]);
            adventurerCount =int.Parse(data[6]);
            clearedFloorLevel = int.Parse(data[7]);
            swordLoot = int.Parse(data[8]);
            shieldLoot = int.Parse(data[9]);
            walletLoot = int.Parse(data[10]);
            chestCount = int.Parse(data[11].Substring(0, 3));
            
            //grab all the chests
            for (int i = 0; i < chestCount; i++)
            {
                chestList[i] = int.Parse(data[11].Substring(5 + (6 * i), 5));
            }

            //spawn all the floors needed
            for (int i = 1; i < topFloor - 1; i++)
            {
                holder = factory.BuildNextFloor(true);
                factory = holder.GetComponentInChildren<RoomFactory>();
                factory.Load();
            }

            if(topFloor > 1)
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
            adventurerCountButton.LoadLevels(adventurerCount - 5);
            clearedFloorButton.LoadLevels((clearedFloorLevel - 1) / 10);
            swordController.Setlooted(swordLoot);
            shieldController.Setlooted(shieldLoot);
            walletController.Setlooted(walletLoot);

        }
        gameObject.GetComponent<LoadManager>().enabled = false;
    }
}
