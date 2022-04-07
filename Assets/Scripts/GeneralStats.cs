using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStats : MonoBehaviour
{
    [SerializeField] int gold;
    [SerializeField] UIController ui;
    [SerializeField] int topFloor = 1;   //Stores the top floor 

    [SerializeField] int adventurerHealth;
    [SerializeField] int adventurerDamage;
    [SerializeField] float adventurerSpeed;

    private int highestFloor = 1;

    // Start is called before the first frame update
    void Start()
    {
        gold = 0;
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

    //Set the adventurers health stat
    public void SetAdventurerHealth(int hp)
    {
        adventurerHealth = hp;
    }

    // Get the adventurers health stat
    public int GetAdventurerHealth()
    {
        return adventurerHealth;
    }

    //Set the adventurers damage stat
    public void SetAdventurerDamage(int dmg)
    {
        adventurerDamage = dmg;
    }

    // Get the adventurers damage stat
    public int GetAdventurerDamage()
    {
        return adventurerDamage;
    }

    //Set the adventurers speed stat
    public void SetAdventurerSpeed(float spd)
    {
        adventurerSpeed = spd;
    }

    // Get the adventurers speed stat
    public float GetAdventurerSpeed()
    {
        return adventurerSpeed;
    }
   
}
