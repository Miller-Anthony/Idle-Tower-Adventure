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
            case "breastplate":
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
            case "alchemyKit":
                bonus = new BigNumber(30);
                break;
            case "largeVial":
                bonus = new BigNumber(80);
                break;
            case "highQualityIngredients":
                bonus = new BigNumber(30);
                break;
            case "ringOfWishes":
                bonus = new BigNumber(30);
                break;
            case "amuletOfTime":
                bonus = new BigNumber(30);
                break;
            case "glovesOfMidas":
                bonus = new BigNumber(30);
                break;
            case "manaPotion":
                bonus = new BigNumber(30);
                break;
            case "magicFocus":
                bonus = new BigNumber(30);
                break;
            case "tomeOfIntelegence":
                bonus = new BigNumber(5);
                break;
            case "summonersRobe":
                bonus = new BigNumber(5);
                break;
            case "summonersRing":
                bonus = new BigNumber(30);
                break;
            case "summonersStaff":
                bonus = new BigNumber(15);
                break;
            case "tomeOfCharisma":
                bonus = new BigNumber(30);
                break;
            case "lodedDice":
                bonus = new BigNumber(80);
                break;
            case "tomeOfStrength":
                bonus = new BigNumber(30);
                break;
            case "swiftBoots":
                bonus = new BigNumber(30);
                break;
            case "tomeOfDexterity":
                bonus = new BigNumber(30);
                break;
            case "poisonVial":
                bonus = new BigNumber(30);
                break;
            case "tomeOfEndurance":
                bonus = new BigNumber(30);
                break;
            case "sharpeningStone":
                bonus = new BigNumber(30);
                break;
            case "investments":
                bonus = new BigNumber(30);
                break;
            case "adventuringVoucher":
                bonus = new BigNumber(30);
                break;
            case "dungeonMap":
                bonus = new BigNumber(30);
                break;
            case "portalStone":
                bonus = new BigNumber(1);
                break;
            case "pendantOfTheDawn":
                bonus = new BigNumber(1);
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
            case "largeVial":
                return new BigNumber(100) + (bonus * looted);
            case "ringOfWishes":
                return new BigNumber(100) - (bonus * looted);
            case "amuletOfTime":
                return new BigNumber(100) + (bonus * looted);
            case "manaPotion":
                return new BigNumber(100) - (bonus * looted);
            case "magicFocus":
                return new BigNumber(100) + (bonus * looted);
            case "summonersRobe":
                return new BigNumber(100) - (bonus * looted);
            case "sommonersRing":
                return new BigNumber(100) + (bonus * looted);
            case "tomeOfCharisma":
                return new BigNumber(0) + (bonus * looted);
            case "tomeOfDexterity":
                return new BigNumber(100) - (bonus * looted);
            case "poisonVial":
                return new BigNumber(100) - (bonus * looted);
            case "tomeOfEndurance":
                return new BigNumber(100) - (bonus * looted);
            case "sharpeningStone":
                return new BigNumber(100) - (bonus * looted);
            case "adventuringVoucher":
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
