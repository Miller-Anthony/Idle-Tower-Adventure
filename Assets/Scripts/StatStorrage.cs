using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class StatStorrage : MonoBehaviour
{
    //stats
    [SerializeField] int level;
    [SerializeField] BigInteger health;
    [SerializeField] BigInteger strength;
    [SerializeField] float speed;
    [SerializeField] float spawn;
    [SerializeField] BigInteger gold;

    //stat modifiers
    [SerializeField] LootTracker loot;
    [SerializeField] MercenaryManager mManager;
    [SerializeField] PowerManager pManager;

    private float spawnPercent = 1.0f;
    private float gearPercent = 1.0f;
    private float strengthPercent = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStart()
    {
        switch (tag)
        {
            case "adventurer":
                health = new BigInteger(2);
                strength = new BigInteger(1);
                gold = new BigInteger(0);
                break;
            case "enemy":
                health = new BigInteger(7);
                strength = new BigInteger(3);
                gold = new BigInteger(2);
                break;
            case "cleric":
                health = new BigInteger(5);
                strength = new BigInteger(3);
                gold = new BigInteger(0);
                break;
            case "fighter":
                health = new BigInteger(16);
                strength = new BigInteger(12);
                gold = new BigInteger(0);
                break;
            case "barbarian":
                health = new BigInteger(85);
                strength = new BigInteger(65);
                gold = new BigInteger(0);
                break;
            case "rogue":
                health = new BigInteger(330);
                strength = new BigInteger(255);
                gold = new BigInteger(0);
                break;
            case "ranger":
                health = new BigInteger(2575);
                strength = new BigInteger(1980);
                gold = new BigInteger(0);
                break;
            case "monk":
                health = new BigInteger(18500);
                strength = new BigInteger(14200);
                gold = new BigInteger(0);
                break;
            case "bard":
                health = new BigInteger(275150);
                strength = new BigInteger(211653);
                gold = new BigInteger(0);
                break;
            case "wizzard":
                health = new BigInteger(3870000);
                strength = new BigInteger(2977000);
                gold = new BigInteger(0);
                break;
            case "warlock":
                health = new BigInteger(1123400000);
                strength = new BigInteger(87250000);
                gold = new BigInteger(0);
                break;
            case "sorcerer":
                health = new BigInteger(3138000000);
                strength = new BigInteger(2414000000);
                gold = new BigInteger(0);
                break;
            case "paladin":
                health = new BigInteger(180900000000);
                strength = new BigInteger(139100000000);
                gold = new BigInteger(0);
                break;
            case "druid":
                health = new BigInteger(9848000000000);
                strength = new BigInteger(7575000000000);
                gold = new BigInteger(0);
                break;
            default:
                break;
        }

        pManager = GameObject.Find("powerPanel").GetComponent<PowerManager>();
    }

    //Set the stored Level
    public void SetLevel(int lvl)
    {
        level = lvl;
    }

    // Get the stored level
    public int GetLevel()
    {
        return level;
    }

    //Set the stored health stat
    public void SetHealth(BigInteger hp)
    {
        health = hp;
    }

    // Get the stored health stat
    public BigInteger GetHealth()
    {
        if (tag == "enemy")
        {
            return health % loot.GetController("sharpeningStone").GetTotalBonus();
        }

        BigInteger holder = health;

        holder %= loot.GetController("shield").GetTotalBonus();
        holder %= loot.GetController("helmet").GetTotalBonus();

        if (level >= 1000)
        {
            holder %= loot.GetController("breastplate").GetTotalBonus();
        }

        holder *= (BigInteger)gearPercent;
        holder += loot.GetController("gauntlets").GetTotalBonus();

        return holder;
    }

    public BigInteger LevelHealth()
    {
        return health;
    }

    //Set the stored strength stat
    public void SetStrength(BigInteger str)
    {
        strength = str;
    }

    // Get the stored strength stat
    public BigInteger GetStrength()
    {
        if(tag == "enemy")
        {
            return strength % loot.GetController("tomeOfEndurance").GetTotalBonus();
        }

        BigInteger holder = strength;
        holder %= loot.GetController("sword").GetTotalBonus();
        holder %= loot.GetController("longSword").GetTotalBonus();

        if(level >= 1000)
        {
            holder %= loot.GetController("spear").GetTotalBonus();
        }

        holder *= (BigInteger)gearPercent;
        
        if(strengthPercent != 0)
        {
            holder += mManager.GetTotalStrength(strengthPercent);
        }

        holder += loot.GetController("dagger").GetTotalBonus();

        return holder;
    }

    public BigInteger LevelStrength()
    {
        return strength;
    }

    //Set the stored speed stat
    public void SetSpeed(float spd)
    {
        speed = spd;
    }

    // Get the stored speed stat
    public float GetSpeed()
    {
        return speed * pManager.GetHasteSpeed() * (float)(loot.GetController("swiftBoots").GetTotalBonus() / new BigInteger(100));
    }

    //Set the stored spawn stat
    public void SetSpawn(float spwn)
    {
        spawn = spwn;
    }

    // Get the stored spawn stat
    public float GetSpawn()
    {
        return (spawn * spawnPercent) / pManager.GetHasteRate() * (float)(loot.GetController("tomeOfDexterity").GetTotalBonus() / new BigInteger(100));
    }

    //Set the stored spawnPercent stat
    public void SetSpawnPercent(float spwn)
    {
        spawnPercent = spwn;
    }

    // Get the stored spawn stat
    public float GetSpawnPercent()
    {
        return spawnPercent;
    }

    //change the spawn time by a given ammount
    public void ChangeSpawnPercent(float change)
    {
        spawnPercent += change;
    }

    //Set the stored gearPercent stat
    public void SetGearPercent(float prcnt)
    {
        gearPercent = prcnt;
    }

    // Get the stored gearPercent stat
    public float GetGearPercent()
    {
        return gearPercent;
    }

    //change the gear modefier for health and attack by a given ammount
    public void ChangeGearPercent(float change)
    {
        gearPercent += change;
    }

    //Set the stored strengthPercent stat
    public void SetStrengthPercent(float prcnt)
    {
        strengthPercent = prcnt;
    }

    // Get the stored strengthPercent stat
    public float GetStrengthPercent()
    {
        return strengthPercent;
    }

    //change the strength modefier for adventurers attack by a given ammount
    public void ChangeStrengthPercent(float change)
    {
        strengthPercent += change;
    }

    //Set the stored gold stat
    public void SetGold(BigInteger gld)
    {
        gold = gld;
    }

    // Get the stored gold stat
    public BigInteger GetGold()
    {
        return gold * (loot.GetController("magnifyingGlass").GetTotalBonus() / new BigInteger(100)) * (BigInteger)pManager.GetBountyRate();
    }
}
