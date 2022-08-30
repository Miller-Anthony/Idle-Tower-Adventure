using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatStorrage : MonoBehaviour
{
    //stats
    [SerializeField] int level;
    [SerializeField] BigNumber health;
    [SerializeField] BigNumber strength;
    [SerializeField] float speed;
    [SerializeField] float spawn;
    [SerializeField] BigNumber gold;

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
                health = new BigNumber(3);
                strength = new BigNumber(1);
                gold = new BigNumber(0);
                break;
            case "enemy":
                health = new BigNumber(7);
                strength = new BigNumber(3);
                gold = new BigNumber(2);
                break;
            case "cleric":
                health = new BigNumber(5);
                strength = new BigNumber(1);
                gold = new BigNumber(0);
                break;
            case "fighter":
                health = new BigNumber(20);
                strength = new BigNumber(10);
                gold = new BigNumber(0);
                break;
            case "barbarian":
                health = new BigNumber(150);
                strength = new BigNumber(35);
                gold = new BigNumber(0);
                break;
            case "rogue":
                health = new BigNumber(1000);
                strength = new BigNumber(90);
                gold = new BigNumber(0);
                break;
            case "ranger":
                health = new BigNumber(16666);
                strength = new BigNumber(300);
                gold = new BigNumber(0);
                break;
            case "monk":
                health = new BigNumber(278450);
                strength = new BigNumber(1100);
                gold = new BigNumber(0);
                break;
            case "bard":
                health = new BigNumber(12000000);
                strength = new BigNumber(4700);
                gold = new BigNumber(0);
                break;
            case "wizzard":
                health = new BigNumber(518000000);
                strength = new BigNumber(25000);
                gold = new BigNumber(0);
                break;
            case "warlock":
                health = new BigNumber(57960000000);
                strength = new BigNumber(154600);
                gold = new BigNumber(0);
                break;
            case "sorcerer":
                health = new BigNumber(6489000000000);
                strength = new BigNumber(1214660);
                gold = new BigNumber(0);
                break;
            case "paladin":
                health = new BigNumber(188300000000000);
                strength = new BigNumber(11111111);
                gold = new BigNumber(0);
                break;
            case "druid":
                health = new BigNumber(546800000000000000);
                strength = new BigNumber(129000000);
                gold = new BigNumber(0);
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
    public void SetHealth(BigNumber hp)
    {
        health = hp;
    }

    // Get the stored health stat
    public BigNumber GetHealth()
    {
        if (tag == "enemy")
        {
            return health % loot.GetController("sharpeningStone").GetTotalBonus();
        }

        BigNumber holder = health;

        holder %= loot.GetController("shield").GetTotalBonus();
        holder %= loot.GetController("helmet").GetTotalBonus();

        if (level >= 1000)
        {
            holder %= loot.GetController("breastplate").GetTotalBonus();
        }

        holder *= gearPercent;
        holder += loot.GetController("gauntlets").GetTotalBonus();

        return holder;
    }

    public BigNumber LevelHealth()
    {
        return health;
    }

    //Set the stored strength stat
    public void SetStrength(BigNumber str)
    {
        strength = str;
    }

    // Get the stored strength stat
    public BigNumber GetStrength()
    {
        if(tag == "enemy")
        {
            return strength % loot.GetController("tomeOfEndurance").GetTotalBonus();
        }

        BigNumber holder = strength;
        holder %= loot.GetController("sword").GetTotalBonus();
        holder %= loot.GetController("longSword").GetTotalBonus();

        if(level >= 1000)
        {
            holder %= loot.GetController("spear").GetTotalBonus();
        }

        holder *= gearPercent;
        
        if(strengthPercent != 0)
        {
            holder += mManager.GetTotalStrength(strengthPercent);
        }

        holder += loot.GetController("dagger").GetTotalBonus();

        return holder;
    }

    public BigNumber LevelStrength()
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
        return speed * pManager.GetHasteSpeed() % loot.GetController("swiftBoots").GetTotalBonus();
    }

    //Set the stored spawn stat
    public void SetSpawn(float spwn)
    {
        spawn = spwn;
    }

    // Get the stored spawn stat
    public float GetSpawn()
    {
        return (spawn * spawnPercent) / pManager.GetHasteRate() % loot.GetController("tomeOfDexterity").GetTotalBonus();
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
    public void SetGold(BigNumber gld)
    {
        gold = gld;
    }

    // Get the stored gold stat
    public BigNumber GetGold()
    {
        return gold % loot.GetController("magnifyingGlass").GetTotalBonus() * pManager.GetBountyRate();
    }
}
