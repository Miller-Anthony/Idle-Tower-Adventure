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

            //spawn all the floors needed
            for (int i = 1; i < topFloor; i++)
            {
                GameObject holder = factory.BuildNextFloor();
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
        }
        gameObject.GetComponent<LoadManager>().enabled = false;
    }
}
