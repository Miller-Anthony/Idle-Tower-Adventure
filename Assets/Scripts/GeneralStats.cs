using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStats : MonoBehaviour
{
    [SerializeField] BigNumber gold;
    [SerializeField] UIController ui;
    [SerializeField] int topFloor = 1;   //Stores the top floor 
    [SerializeField] int bottomFloor;    //Stores the bottom floor 
    [SerializeField] int maxAdventurers; //maximum number of adventurers that can be summoned at any given time.
    [SerializeField] float skilledChance; //chance a skilled adventurer will spawn
    [SerializeField] PowerManager pManager; //power manager for max number of adventurers
    [SerializeField] FloorTracker fTracker;
    [SerializeField] MercenaryManager mManager;
    [SerializeField] LootTracker loot;

    private int highestFloor = 1;
    private int numAdventurers;          //the number of adventurers currantly summoned

    // Start is called before the first frame update
    void Start()
    {
        gold = new BigNumber(0);
        numAdventurers = 0;
        skilledChance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Add a given amount of gold
    public void AddGold(BigNumber value)
    {
        gold += value;
        ui.UpdateGold(gold);
    }

    // Subtract a gien amount of gold
    public void SubtractGold(BigNumber value)
    {
        gold -= value;
        ui.UpdateGold(gold);
    }

    //return the amount of gold currently held
    public BigNumber CheckGold()
    {
        return gold;
    }

    //increment the top floor to the next floor
    public void NextFloor()
    {
        topFloor++;
        ui.UpdateTopFloor(topFloor);
        if(topFloor > highestFloor)
        {
            highestFloor = topFloor;
        }
    }

    //get the current top floor of the tower
    public int GetTopFloor()
    {
        return topFloor;
    }

    //Get the highest floor of the tower ever reached
    public int GetHighestFloor()
    {
        return highestFloor;
    }

    //set the highest floor ever reached
    public void SetHighestFloor(int hFloor)
    {
        highestFloor = hFloor;
    }

    //get the current bottom floor of the tower
    public int GetBottomFloor()
    {
        return bottomFloor;
    }

    //set the bottom flor of the tower
    public void SetBottomFloor(int floor)
    {
        bottomFloor = floor;
    }

    //Get the chance a skilled adventurer will be summoned instead
    public float GetSkilledChance()
    {
        return skilledChance % loot.GetController("loadedDice").GetTotalBonus();
    }

    //Set the chance a skilled adventurer will be summoned instead
    public void SetSkilledChance(float chance)
    {
        skilledChance = chance;
    }

    //Get the total amount of adventurers that can be summoned at any given time
    public int GetMaxAdventurers()
    {
        return maxAdventurers + loot.GetController("tomeOfCharisma").GetTotalBonus().ToInt() + pManager.GetAutoLimit();
    }

    //Set how many adventurers can be summoned at a given time
    public void SetMaxAdventurers(int max)
    {
        maxAdventurers = max;
        ui.UpdateAdventurerCount(numAdventurers, maxAdventurers);
    }

    //Get the number of adventurers currently summoned
    public int GetNumAdventurers()
    {
        return numAdventurers;
    }

    //Increase the count of how many adventurers are currently summoned
    public void SummonAdventurer()
    {
        numAdventurers++;
        ui.UpdateAdventurerCount(numAdventurers, maxAdventurers);
    }

    //decrease the number of adventurers that are currently summoned
    public void DestroyAdventurer()
    {
        numAdventurers--;
        ui.UpdateAdventurerCount(numAdventurers, maxAdventurers);
    }

    //add gold for the amount of offline time
    public void OfflineGold(int loadYear, int loadMonth, int loadDay, int loadHour, int loadMin, int loadSec)
    {
        //get needed info for calculations
        RoomController room = fTracker.GetTopFloor().GetComponent<RoomController>();
        BigNumber topGold = room.GetEnemyGold();
        BigNumber topHealth = room.GetEnemyHealth();
        BigNumber totalAttack = mManager.GetTotalStrength();
        BigNumber curentHealth = topHealth;
        BigNumber currentGold = new BigNumber(0);

        //load time from save file and calculate the time passed
        System.DateTime oldTime = new System.DateTime(loadYear, loadMonth, loadDay, loadHour, loadMin, loadSec, 0, System.DateTimeKind.Utc);
        System.TimeSpan holder = System.DateTime.UtcNow.Subtract(oldTime);

        /*
         * calculation to use after BigNumber is finnished
        double count = holder.TotalSeconds / 4;
        int attackCount = topHealth / totalAttack;
        count = count / attackCount;
        AddGold(topGold * count);
        */

        //for every 4 seconds of idle time, have an attack happen
        for (double i = 0; i < holder.TotalSeconds; i += 4)
        {
            //the attack
            curentHealth -= totalAttack;

            //if the atack killed the top floor, increase kill count and reset the health
            if(curentHealth <= 0)
            {
                curentHealth = topHealth;
                currentGold += topGold;
            }
        }

        AddGold(currentGold % loot.GetController("investments").GetTotalBonus());

        //add popup for the amount of gold gained
    }
}
