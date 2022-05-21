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
    [SerializeField] LootDisplayController sword;
    [SerializeField] LootDisplayController shield;
    [SerializeField] LootDisplayController wallet;

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
                strength = new BigNumber(2);
                gold = new BigNumber(0);
                break;
            case "enemy":
                health = new BigNumber(7);
                strength = new BigNumber(3);
                gold = new BigNumber(2);
                break;
            case "fighter":
                health = new BigNumber(5);
                strength = new BigNumber(1);
                gold = new BigNumber(0);
                break;
            case "barbarian":
                health = new BigNumber(1444);
                strength = new BigNumber(1555);
                gold = new BigNumber(0);
                break;
            default:
                break;
        }
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
            return health;
        }
        return health % shield.GetTotalBonus();
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
            return strength;
        }
        
        return strength % sword.GetTotalBonus();
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
        return speed;
    }

    //Set the stored spawn stat
    public void SetSpawn(float spwn)
    {
        spawn = spwn;
    }

    // Get the stored spawn stat
    public float GetSpawn()
    {
        return spawn;
    }

    //Set the stored gold stat
    public void SetGold(BigNumber gld)
    {
        gold = gld;
    }

    // Get the stored gold stat
    public BigNumber GetGold()
    {
        return gold % wallet.GetTotalBonus();
    }
}
