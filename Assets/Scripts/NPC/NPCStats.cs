using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class NPCStats : MonoBehaviour
{
    [SerializeField] int level;    //the level of the NPC (used to calculate enemy spawn position)
    [SerializeField] BigInteger strength; //how much damage the NPC does
    [SerializeField] BigInteger health;   //how much health the NPC has
    [SerializeField] float speed;  //how fast the NPC moves (only for moving NPCs) 
    [SerializeField] float spawn;  //how quick enemies spawn (only needed for enemies)
    [SerializeField] BigInteger gold;     //how much gold you get from the enemy (only needed for enemies)
    [SerializeField] GameObject healthBar; //the healthbar of an enemy
    [SerializeField] Transform currentHealthBar; //the current health represented graphically
    [SerializeField] LootTracker loot;

    private BigInteger currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        loot = GameObject.Find("LootTracker").GetComponent<LootTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Get the level of the NPC
    /// </summary>
    /// <returns>the level of the NPC</returns>
    public int GetLevel()
    {
        return level;
    }

    /// <summary>
    /// Set the level of the NPC to something specific
    /// </summary>
    /// <param name="correction">the corrected level of the NPC</param>
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
    public BigInteger GetStrength()
    {
        return strength;
    }

    // Set the strength of the NPC to something specific
    public void SetStrength(BigInteger correction)
    {
        strength = correction;
    }

    // Add an amount of strength to the NPC
    public void AddStrength(BigInteger addition)
    {
        strength += addition;
    }

    // Subtract an amount of strength to the NPC
    public void SubtractStrength(BigInteger subtraction)
    {
        strength -= subtraction;
    }

    // Returns the current health of the NPC
    public BigInteger GetCurrentHealth()
    {
        return currentHealth;
    }

    // Set the current health of the NPC to something specific
    public void SetCurrentHealth(BigInteger correction)
    {
        currentHealth = correction;
        if (currentHealth >= health)
        {
            currentHealth = health;
            if (tag == "enemy")
            {
                healthBar.SetActive(false);
                return;
            }
        }

        if (tag == "enemy")
        {
            healthBar.SetActive(true);
            UnityEngine.Vector3 holder = currentHealthBar.localScale;
            holder.x = PercentHealth();
            currentHealthBar.localScale = holder;
        }
    }

    // Returns the maximum health of the NPC
    public BigInteger GetMaxHealth()
    {
        return currentHealth;
    }

    // Set the maximum health of the NPC to something specific
    public void SetMaxHealth(BigInteger correction)
    {
        health = correction;
    }

    // Add an amount of health to the NPC
    public void Heal(BigInteger addition)
    {
        currentHealth += addition;
        if (currentHealth >= health)
        {
            currentHealth = health;
            if (tag == "enemy")
            {
                healthBar.SetActive(false);
                return;
            }
        }

        if (tag == "enemy")
        {
            UnityEngine.Vector3 holder = currentHealthBar.localScale;
            holder.x = PercentHealth();
            currentHealthBar.localScale = holder;
        }
    }

    // Subtract an amount of health to the NPC
    public void Damage(BigInteger subtraction)
    {
        currentHealth -= subtraction;

        if(tag == "enemy")
        {
            healthBar.SetActive(true);
        }

        if (tag == "enemy")
        {
            UnityEngine.Vector3 holder = currentHealthBar.localScale;
            holder.x = PercentHealth();
            currentHealthBar.localScale = holder;
        }
    }

    //regenerate a portion of maximum health
    //only called for enemies
    public void RegenHealth()
    {
        BigInteger basePercent = (health * 2) / 100;
        BigInteger regenAmount = basePercent * loot.GetController("poisonVial").GetTotalBonus() / 100;
        if(regenAmount < 1)
        {
            regenAmount = 1;
        }
        currentHealth += regenAmount;
        if(currentHealth >= health)
        {
            currentHealth = health;
            healthBar.SetActive(false);
            return;
        }

        UnityEngine.Vector3 holder = currentHealthBar.localScale;
        holder.x = PercentHealth();
        currentHealthBar.localScale = holder;
    }

    //return the percent health left of the NPC as a float
    public float PercentHealth()
    {
        return ((float)(currentHealth * 100 / health)) / 100;
    }

    //returns true if current health is at maximum
    public bool IsFullHealth()
    {
        if(health == currentHealth)
        {
            return true;
        }
        return false;
    }

    //return true if the NPC has no health left
    public bool IsDead()
    {
        if(currentHealth <= 0)
        {
            return true;
        }
        return false;
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
    public BigInteger GetGold()
    {
        return gold;
    }

    // Set the gold of the NPC to something specific
    public void SetGold(BigInteger correction)
    {
        gold = correction;
    }

    // Add an amount of gold to the NPC
    public void AddGold(BigInteger addition)
    {
        gold += addition;
    }

    // Subtract an amount of gold to the NPC
    public void SubtractGold(BigInteger subtraction)
    {
        gold -= subtraction;
    }
}
