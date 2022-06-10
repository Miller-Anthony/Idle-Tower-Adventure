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
        return skilledChance;
    }

    //Set the chance a skilled adventurer will be summoned instead
    public void SetSkilledChance(float chance)
    {
        skilledChance = chance;
    }

    //Get the total amount of adventurers that can be summoned at any given time
    public int GetMaxAdventurers()
    {
        return maxAdventurers;
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
}
