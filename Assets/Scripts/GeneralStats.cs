using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStats : MonoBehaviour
{
    [SerializeField] int gold;
    [SerializeField] UIController ui;
    [SerializeField] int topFloor = 1;   //Stores the top floor 
    [SerializeField] int bottomFloor;    //Stores the bottom floor 
    [SerializeField] int maxAdventurers; //maximum number of adventurers that can be summoned at any given time.

    private int highestFloor = 1;
    private int numAdventurers;          //the number of adventurers currantly summoned

    // Start is called before the first frame update
    void Start()
    {
        gold = 0;
        numAdventurers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Add a given amount of gold
    public void AddGold(int value)
    {
        gold += value;
        ui.UpdateGold(gold);
    }

    // Subtract a gien amount of gold
    public void SubtractGold(int value)
    {
        gold -= value;
        ui.UpdateGold(gold);
    }

    public int CheckGold()
    {
        return gold;
    }

    public void NextFloor()
    {
        topFloor++;
        ui.UpdateTopFloor(topFloor);
        if(topFloor > highestFloor)
        {
            highestFloor = topFloor;
        }
    }

    public int GetTopFloor()
    {
        return topFloor;
    }

    public int GetHighestFloor()
    {
        return highestFloor;
    }

    public int GetBottomFloor()
    {
        return bottomFloor;
    }

    public void SetBottomFloor(int floor)
    {
        bottomFloor = floor;
    }

    public int GetMaxAdventurers()
    {
        return maxAdventurers;
    }

    public void SetMaxAdventurers(int max)
    {
        maxAdventurers = max;
        ui.UpdateAdventurerCount(numAdventurers, maxAdventurers);
    }

    public int GetNumAdventurers()
    {
        return numAdventurers;
    }

    public void SummonAdventurer()
    {
        numAdventurers++;
        ui.UpdateAdventurerCount(numAdventurers, maxAdventurers);
    }

    public void DestroyAdventurer()
    {
        numAdventurers--;
        ui.UpdateAdventurerCount(numAdventurers, maxAdventurers);
    }
}
