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

    //data to save
    private int highestFloor;
    private int topFloor;
    private int gold;
    private int adventurerLevel;
    private int adventurerCount;
    private int clearedFloorLevel;
    private int fighterLevel;
    private int barbarianLevel;

    //stuff to track when to save
    private float saveTimer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
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

    
}
