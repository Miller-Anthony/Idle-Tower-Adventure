using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootDisplayController : MonoBehaviour
{
    [SerializeField] Text lootedText;
    [SerializeField] Text bonusText;

    [SerializeField] int looted;
    [SerializeField] int maxLootable; // 0 = unlimited
    [SerializeField] BigNumber bonus;

    //internal stats for figuring out loot chance
    [SerializeField] float startingWeight;
    [SerializeField] int startingFloor;

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
            case "sword":
                bonus = new BigNumber(30);
                break;
            case "longSword":
                bonus = new BigNumber(80);
                break;
            case "spear":
                bonus = new BigNumber(30);
                break;
            case "dagger":
                bonus = new BigNumber(30);
                break;
            case "shield":
                bonus = new BigNumber(30);
                break;
            case "helmet":
                bonus = new BigNumber(30);
                break;
            case "breastPlate":
                bonus = new BigNumber(30);
                break;
            case "gauntlets":
                bonus = new BigNumber(30);
                break;
            case "magnifyingGlass":
                bonus = new BigNumber(30);
                break;
            case "tomeOfLuck":
                bonus = new BigNumber(30);
                break;
            case "gemPouch":
                bonus = new BigNumber(30);
                break;
            case "wallet":
                bonus = new BigNumber(15);
                break;
            default:
                break;
        }
    }

    //Set the amount looted
    public void Setlooted(int amount)
    {
        looted = amount;
        UpdateText();
    }

    // Get the amount looted
    public int GetLooted()
    {
        return looted;
    }

    public void AddLoot()
    {
        looted++;
    }

    //Set the bonus amount each item gives
    public void SetBonus(BigNumber bns)
    {
        bonus = bns;
    }

    // Get the bonus amount each item gives
    public BigNumber GetBonus()
    {
        return bonus;
    }

    // Get the total bonus granted from the item
    public BigNumber GetTotalBonus()
    {
        switch(tag)
        {
            case "alchemistKit":
                return new BigNumber(100) - (bonus * looted);
            default:
                return bonus * looted;
        }
    }

    //get the loots starting weight
    public float GetStartingWeight()
    {
        return startingWeight;
    }

    //get the loots starting floor
    public int GetStartingFloor()
    {
        return startingFloor;
    }

    public float GetWeight(int floor)
    {
        // If the loot should not spawn yet return no weight
        if (startingFloor < floor || looted == maxLootable)
        {
            return 0;
        }

        int difference = floor - startingFloor;

        if(difference <= 200)
        {
            return startingWeight + difference;
        }
        else 
        {
            //y = s + x - x^2
            float holder = startingWeight + difference - ((difference - 200) * (difference - 200));

            if(holder < 10)
            {
                holder = 10;
            }
            return holder;
        }  
    }

    //updates the text to 
    public void UpdateText()
    {
        lootedText.text = looted.ToString();
        bonusText.text = (bonus * looted) + "%";
    }
}
