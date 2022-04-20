using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatStorrage : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] int health;
    [SerializeField] int strength;
    [SerializeField] float speed;
    [SerializeField] float spawn;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void SetHealth(int hp)
    {
        health = hp;
    }

    // Get the stored health stat
    public int GetHealth()
    {
        return health;
    }

    //Set the stored strength stat
    public void SetStrength(int str)
    {
        strength = str;
    }

    // Get the stored strength stat
    public int GetStrength()
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
}
