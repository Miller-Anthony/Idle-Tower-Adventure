using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class LootDisplayController : MonoBehaviour
{
    [SerializeField] Text titleText;
    [SerializeField] Text lootedText;
    [SerializeField] Text bonusText;
    [SerializeField] Text descriptionText;
    [SerializeField] Image image;

    [SerializeField] int looted;
    [SerializeField] int maxLootable; // 0 = unlimited
    [SerializeField] BigInteger bonus;

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
                bonus = new BigInteger(30);
                break;
            case "longSword":
                bonus = new BigInteger(80);
                break;
            case "spear":
                bonus = new BigInteger(40);
                break;
            case "dagger":
                bonus = new BigInteger(150);
                break;
            case "shield":
                bonus = new BigInteger(30);
                break;
            case "helmet":
                bonus = new BigInteger(80);
                break;
            case "breastplate":
                bonus = new BigInteger(40);
                break;
            case "gauntlets":
                bonus = new BigInteger(150);
                break;
            case "magnifyingGlass":
                bonus = new BigInteger(30);
                break;
            case "tomeOfLuck":
                bonus = new BigInteger(1);
                break;
            case "gemPouch":
                bonus = new BigInteger(20);
                break;
            case "wallet":
                bonus = new BigInteger(1000);
                break;
            case "alchemyKit":
                bonus = new BigInteger(5);
                break;
            case "largeVial":
                bonus = new BigInteger(5);
                break;
            case "highQualityIngredients":
                bonus = new BigInteger(15);
                break;
            case "ringOfWishes":
                bonus = new BigInteger(5);
                break;
            case "amuletOfTime":
                bonus = new BigInteger(5);
                break;
            case "glovesOfMidas":
                bonus = new BigInteger(15);
                break;
            case "manaPotion":
                bonus = new BigInteger(5);
                break;
            case "magicFocus":
                bonus = new BigInteger(5);
                break;
            case "tomeOfIntelegence":
                bonus = new BigInteger(15);
                break;
            case "summonersRobe":
                bonus = new BigInteger(5);
                break;
            case "summonersRing":
                bonus = new BigInteger(5);
                break;
            case "summonersStaff":
                bonus = new BigInteger(15);
                break;
            case "tomeOfCharisma":
                bonus = new BigInteger(1);
                break;
            case "loadedDice":
                bonus = new BigInteger(10);
                break;
            case "tomeOfStrength":
                bonus = new BigInteger(15);
                break;
            case "swiftBoots":
                bonus = new BigInteger(1);
                break;
            case "tomeOfDexterity":
                bonus = new BigInteger(1);
                break;
            case "poisonVial":
                bonus = new BigInteger(5);
                break;
            case "tomeOfEndurance":
                bonus = new BigInteger(5);
                break;
            case "sharpeningStone":
                bonus = new BigInteger(5);
                break;
            case "investments":
                bonus = new BigInteger(10);
                break;
            case "adventuringVoucher":
                bonus = new BigInteger(1);
                break;
            case "dungeonMap":
                bonus = new BigInteger(1);
                break;
            case "portalStone":
                bonus = new BigInteger(1);
                break;
            case "pendantOfTheDawn":
                bonus = new BigInteger(1);
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
    public void SetBonus(BigInteger bns)
    {
        bonus = bns;
    }

    // Get the bonus amount each item gives
    public BigInteger GetBonus()
    {
        return bonus;
    }

    // Get the total bonus granted from the item
    public BigInteger GetTotalBonus()
    {
        switch(tag)
        {
            case "dagger":
                return new BigInteger(0) + (bonus * looted);
            case "gauntlets":
                return new BigInteger(0) + (bonus * looted);
            case "wallet":
                return new BigInteger(0) + (bonus * looted);
            case "alchemistKit":
                return new BigInteger(100) - (bonus * looted);
            case "largeVial":
                return new BigInteger(100) + (bonus * looted);
            case "ringOfWishes":
                return new BigInteger(100) - (bonus * looted);
            case "amuletOfTime":
                return new BigInteger(100) + (bonus * looted);
            case "manaPotion":
                return new BigInteger(100) - (bonus * looted);
            case "magicFocus":
                return new BigInteger(100) + (bonus * looted);
            case "summonersRobe":
                return new BigInteger(100) - (bonus * looted);
            case "sommonersRing":
                return new BigInteger(100) + (bonus * looted);
            case "tomeOfCharisma":
                return new BigInteger(0) + (bonus * looted);
            case "tomeOfDexterity":
                return new BigInteger(100) - (bonus * looted);
            case "poisonVial":
                return new BigInteger(100) - (bonus * looted);
            case "tomeOfEndurance":
                return new BigInteger(100) - (bonus * looted);
            case "sharpeningStone":
                return new BigInteger(100) - (bonus * looted);
            case "adventuringVoucher":
                return new BigInteger(100) - (bonus * looted);
            default:
                return 100 + bonus * looted;
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
        if (startingFloor > floor || looted == maxLootable)
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

    public string GetTitle()
    {
        return titleText.text;
    }

    public string GetDescription()
    {
        return descriptionText.text;
    }

    public Image GetImage()
    {
        return image;
    }

    //updates the text to 
    public void UpdateText()
    {
        lootedText.text = looted.ToString();
        bonusText.text = (bonus * looted) + "%";
    }
}
