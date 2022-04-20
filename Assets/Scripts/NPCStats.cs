using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStats : MonoBehaviour
{
    [SerializeField] int level;    //the level of the NPC (used to calculate enemy spawn position)
    [SerializeField] int strength; //how much damage the NPC does
    [SerializeField] int health;   //how much health the NPC has
    [SerializeField] float speed;  //how fast the NPC moves (only for moving NPCs) 
    [SerializeField] float spawn;  //how quick enemies spawn (only needed for enemies)
    [SerializeField] int gold;     //how much gold you get from the enemy (only needed for enemies)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Returns the level of the NPC
    public int GetLevel()
    {
        return level;
    }

    // Set the level of the NPC to something specific
    public void SetLevel(int correction)
    {
        level = correction;
    }

    // Add an amount of levels to the NPC
    public void AddLevel(int addition)
    {
        level += addition;
    }

    // Subtract an amount of levels to the NPC
    public void SubtractLevel(int subtraction)
    {
        level -= subtraction;
    }

    // Returns the strength of the NPC
    public int GetStrength()
    {
        return strength;
    }

    // Set the strength of the NPC to something specific
    public void SetStrength(int correction)
    {
        strength = correction;
    }

    // Add an amount of strength to the NPC
    public void AddStrength(int addition)
    {
        strength += addition;
    }

    // Subtract an amount of strength to the NPC
    public void SubtractStrength(int subtraction)
    {
        strength -= subtraction;
    }

    // Returns the health of the NPC
    public int GetHealth()
    {
        return health;
    }

    // Set the health of the NPC to something specific
    public void SetHealth(int correction)
    {
        health = correction;
    }

    // Add an amount of health to the NPC
    public void AddHealth(int addition)
    {
        health += addition;
    }

    // Subtract an amount of health to the NPC
    public void SubtractHealth(int subtraction)
    {
        health -= subtraction;
    }

    // Returns the speed of the NPC
    public float GetSpeed()
    {
        return speed;
    }

    // Set the speed of the NPC to something specific
    public void SetSpeed(float correction)
    {
        speed = correction;
    }

    // Add an amount of speed to the NPC
    public void AddSpeed(float addition)
    {
        speed += addition;
    }

    // Subtract an amount of speed to the NPC
    public void SubtractSpeed(float subtraction)
    {
        speed -= subtraction;
    }

    // Returns the spawn of the NPC
    public float GetSpawn()
    {
        return spawn;
    }

    // Set the spawn of the NPC to something specific
    public void SetSpawn(float correction)
    {
        spawn = correction;
    }

    // Add an amount of sapwn to the NPC
    public void AddSpawn(float addition)
    {
        spawn += addition;
    }

    // Subtract an amount of spawn to the NPC
    public void SubtractSpawn(float subtraction)
    {
        spawn -= subtraction;
    }

    // Returns the gold of the NPC
    public int GetGold()
    {
        return gold;
    }

    // Set the gold of the NPC to something specific
    public void SetGold(int correction)
    {
        gold = correction;
    }

    // Add an amount of gold to the NPC
    public void AddGold(int addition)
    {
        gold += addition;
    }

    // Subtract an amount of gold to the NPC
    public void SubtractGold(int subtraction)
    {
        gold -= subtraction;
    }
}
