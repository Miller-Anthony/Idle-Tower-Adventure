using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    //places to get save data from
    [SerializeField] GeneralStats genStats;
    [SerializeField] FloorTracker floors;
    [SerializeField] StatStorrage adventurerStats;
    [SerializeField] StatStorrage fighterStats;
    [SerializeField] StatStorrage barbarianStats;
    [SerializeField] StatStorrage rogueStats;
    [SerializeField] StatStorrage rangerStats;
    [SerializeField] StatStorrage monkStats;
    [SerializeField] StatStorrage clericStats;
    [SerializeField] StatStorrage bardStats;
    [SerializeField] StatStorrage wizzardStats;
    [SerializeField] StatStorrage warlockStats;
    [SerializeField] StatStorrage sorcererStats;
    [SerializeField] StatStorrage paladinStats;
    [SerializeField] StatStorrage druidStats;
    [SerializeField] MiscUpgradeController adventurerCountController;
    [SerializeField] MiscUpgradeController clearedFloorController;
    [SerializeField] MiscUpgradeController clearedFloorAutoController;
    [SerializeField] MiscUpgradeController skilledAdventurerController;
    [SerializeField] MiscUpgradeController hireRateController;
    [SerializeField] MiscUpgradeController improveGearController;
    [SerializeField] MiscUpgradeController strengthInNumbersController;
    [SerializeField] MiscUpgradeController hastePotionController;
    [SerializeField] MiscUpgradeController increasedBountyController;
    [SerializeField] MiscUpgradeController teleportController;
    [SerializeField] MiscUpgradeController autoSpawnerController;
    [SerializeField] LootDisplayController swordController;
    [SerializeField] LootDisplayController shieldController;
    [SerializeField] LootDisplayController walletController;
    [SerializeField] ChestTracker chestList;

    //data to save
    private int highestFloor;
    private int topFloor;
    private BigNumber gold;
    private int adventurerLevel;
    private int adventurerCount;
    private int clearedFloorLevel;
    private int clearedFloorAutoLevel;
    private float skilledAdventurerChance;
    private float hireRatePercent;
    private float improveGearLevel;
    private float strengthInNumbersLevel;
    private int hastePotionLevel;
    private int increasedBountyLevel;
    private int teleportLevel;
    private int autoSpawnerLevel;
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
    private int[] chests;

    //stuff to track when to save
    private float saveTime = 10.0f;
    private float saveTimer;

    // Start is called before the first frame update
    void Start()
    {
        saveTimer = saveTime;
    }

    // Update is called once per frame
    void Update()
    {
        saveTimer -= Time.deltaTime;
        
        if(saveTimer <= 0)
        {
            SaveGame();
            saveTimer = saveTime;
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
        rogueLevel = rogueStats.GetLevel();
        rangerLevel = rangerStats.GetLevel();
        monkLevel = monkStats.GetLevel();
        clericLevel = clericStats.GetLevel();
        bardLevel = bardStats.GetLevel();
        wizzardLevel = wizzardStats.GetLevel();
        warlockLevel = warlockStats.GetLevel();
        sorcererLevel = sorcererStats.GetLevel();
        paladinLevel = paladinStats.GetLevel();
        druidLevel = druidStats.GetLevel();
        adventurerCount = genStats.GetMaxAdventurers();
        clearedFloorLevel = genStats.GetBottomFloor();  //don't like this and need to change it to be how many times the upgrade happened
        clearedFloorAutoLevel = floors.GetMinQueueSize();
        skilledAdventurerChance = genStats.GetSkilledChance();
        hireRatePercent = fighterStats.GetSpawnPercent();
        improveGearLevel = fighterStats.GetGearPercent();
        strengthInNumbersLevel= adventurerStats.GetStrengthPercent();
        hastePotionLevel = 0;
        increasedBountyLevel = 0;
        teleportLevel = 0;
        autoSpawnerLevel = 0;
        chests = chestList.Save();

        //Format save data
        string path = Application.persistentDataPath + "\\Save.txt";
        string data = highestFloor + "\n";
        data = data + topFloor + "\n";
        data = data + gold.SaveString() + "\n";
        data = data + adventurerLevel + "\n";
        data = data + fighterLevel + "\n";
        data = data + barbarianLevel + "\n";
        data = data + rogueLevel + "\n";
        data = data + rangerLevel + "\n";
        data = data + monkLevel + "\n";
        data = data + clericLevel + "\n";
        data = data + bardLevel + "\n";
        data = data + wizzardLevel + "\n";
        data = data + warlockLevel + "\n";
        data = data + sorcererLevel + "\n";
        data = data + paladinLevel + "\n";
        data = data + druidLevel + "\n";
        data = data + adventurerCount + "\n";
        data = data + clearedFloorLevel + "\n";
        data = data + clearedFloorAutoLevel + "\n";
        data = data + skilledAdventurerChance + "\n";
        data = data + hireRatePercent + "\n";
        data = data + improveGearLevel + "\n";
        data = data + strengthInNumbersLevel + "\n";
        data = data + hastePotionLevel + "\n";
        data = data + increasedBountyLevel + "\n";
        data = data + teleportLevel + "\n";
        data = data + autoSpawnerLevel + "\n";
        data = data + swordController.GetLooted() + "\n";
        data = data + shieldController.GetLooted() + "\n";
        data = data + walletController.GetLooted() + "\n";
        data = data + chests.Length.ToString().PadLeft(3);

        for (int i = 0; i < chests.Length; i++)
        {
            data = data + " " + chests;
        }


        //write the save data to the save file
        File.WriteAllText(path, data);
    }

    public void Rebirth()
    {
        //gather all data needed to be saved
        highestFloor = genStats.GetHighestFloor();
        topFloor = 1;
        gold = new BigNumber(0);
        adventurerLevel = 1;
        fighterLevel = 0;
        barbarianLevel = 0;
        rogueLevel = 0;
        rangerLevel = 0;
        monkLevel = 0;
        clericLevel = 0;
        bardLevel = 0;
        wizzardLevel = 0;
        warlockLevel = 0;
        sorcererLevel = 0;
        paladinLevel = 0;
        druidLevel = 0;
        adventurerCount = 0;
        clearedFloorLevel = 1;
        clearedFloorAutoLevel = 19;
        skilledAdventurerChance = 0;
        hireRatePercent = 1;
        improveGearLevel = 1;
        strengthInNumbersLevel = 0;
        hastePotionLevel = 0;
        increasedBountyLevel = 0;
        teleportLevel = 0;
        autoSpawnerLevel = 0;
        chests = chestList.Save();

        //Format save data
        string path = Application.persistentDataPath + "\\Save.txt";
        string data = highestFloor + "\n";
        data = data + topFloor + "\n";
        data = data + gold.SaveString() + "\n";
        data = data + adventurerLevel + "\n";
        data = data + fighterLevel + "\n";
        data = data + barbarianLevel + "\n";
        data = data + rogueLevel + "\n";
        data = data + rangerLevel + "\n";
        data = data + monkLevel + "\n";
        data = data + clericLevel + "\n";
        data = data + bardLevel + "\n";
        data = data + wizzardLevel + "\n";
        data = data + warlockLevel + "\n";
        data = data + sorcererLevel + "\n";
        data = data + paladinLevel + "\n";
        data = data + druidLevel + "\n";
        data = data + adventurerCount + "\n";
        data = data + clearedFloorLevel + "\n";
        data = data + clearedFloorAutoLevel + "\n";
        data = data + skilledAdventurerChance + "\n";
        data = data + hireRatePercent + "\n";
        data = data + improveGearLevel + "\n";
        data = data + strengthInNumbersLevel + "\n";
        data = data + hastePotionLevel + "\n";
        data = data + increasedBountyLevel + "\n";
        data = data + teleportLevel + "\n";
        data = data + autoSpawnerLevel + "\n";
        data = data + swordController.GetLooted() + "\n";
        data = data + shieldController.GetLooted() + "\n";
        data = data + walletController.GetLooted() + "\n";
        data = data + chests.Length.ToString().PadLeft(3);

        for (int i = 0; i < chests.Length; i++)
        {
            data = data + " " + chests.ToString().PadLeft(5);
        }

        //write the save data to the save file
        File.WriteAllText(path, data);

        //reload the scene to strat the new tower
        SceneManager.LoadScene("MainGameScene");
    }
}
