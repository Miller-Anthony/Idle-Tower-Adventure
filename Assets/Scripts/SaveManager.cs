using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    //places to get save data from
    [SerializeField] GeneralStats genStats;
    [SerializeField] StatStorrage adventurerStats;
    [SerializeField] StatStorrage fighterStats;
    [SerializeField] StatStorrage barbarianStats;
    [SerializeField] MiscUpgradeController adventurerCountController;
    [SerializeField] MiscUpgradeController clearedFloorController;

    //Additional places to load data to
    [SerializeField] UpgradeButtonController adventurerButton;
    [SerializeField] UpgradeButtonController fighterButton;
    [SerializeField] UpgradeButtonController barbarianButton;
    [SerializeField] MiscUpgradeButtonController adventurerCountButton;
    [SerializeField] MiscUpgradeButtonController clearedFloorButton;

    //data to save and load
    private int highestFloor;
    private int topFloor;
    private int gold;
    private int adventurerLevel;
    private int adventurerCount;
    private int clearedFloorLevel;
    private int fighterLevel;
    private int barbarianLevel;

    //stuff to track when to save
    private float saveTimer = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        saveTimer -= Time.deltaTime;
        
        if(saveTimer <= 0)
        {
            SaveGame();
        }
    }

    public void SaveGame()
    {
        //gather all data needed to be saved
        highestFloor = genStats.GetHighestFloor();
        topFloor = genStats.GetTopFloor();
        gold = genStats.CheckGold();
        adventurerLevel = adventurerStats.GetLevel();
        fighterLevel = fighterStats.GetLevel();
        barbarianLevel = barbarianStats.GetLevel();
        adventurerCount = genStats.GetMaxAdventurers();
        clearedFloorLevel = genStats.GetBottomFloor();  //don't like this and need to change it to be how many times the upgrade happened

        //Format save data
        string path = Application.persistentDataPath + "\\Save.txt";
        string data = highestFloor + "\n";
        data = data + topFloor + "\n";
        data = data + gold + "\n";
        data = data + adventurerLevel + "\n";
        data = data + fighterLevel + "\n";
        data = data + barbarianLevel + "\n";
        data = data + adventurerCount + "\n";
        data = data + clearedFloorLevel + "\n";

        //write the save data to the save file
        File.WriteAllText(path, data);
    }

    public void LoadGame()
    {
        if(File.Exists(Application.persistentDataPath + "\\Save.txt"))
        {
            //Get data from the save file
            string[] data = File.ReadAllLines(Application.persistentDataPath + "\\Save.txt");

            //Parse save data
            highestFloor = (int)int.Parse(data[0]);
            topFloor = (int)int.Parse(data[1]);
            gold = (int)int.Parse(data[2]);
            adventurerLevel = (int)int.Parse(data[3]);
            fighterLevel = (int)int.Parse(data[4]);
            barbarianLevel = (int)int.Parse(data[5]);
            adventurerCount = (int)int.Parse(data[6]);
            clearedFloorLevel = (int)int.Parse(data[7]);

            //Load the save data into the game
            genStats.SetHighestFloor(highestFloor);
            //spawn all the floors needed
            genStats.AddGold(gold);
            adventurerButton.LoadLevels(adventurerLevel - 1);
            fighterButton.LoadLevels(fighterLevel);
            barbarianButton.LoadLevels(barbarianLevel);
            adventurerCountButton.LoadLevels(adventurerCount - 5);
            clearedFloorButton.LoadLevels((clearedFloorLevel - 1) / 10);
        }
    }
}
