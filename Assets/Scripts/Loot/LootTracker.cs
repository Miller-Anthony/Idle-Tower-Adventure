using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTracker : MonoBehaviour
{
    //odjects that can be added to the list
    [SerializeField] LootDisplayController swordController;
    [SerializeField] LootDisplayController longSwordController;
    [SerializeField] LootDisplayController spearController;
    [SerializeField] LootDisplayController daggerController;
    [SerializeField] LootDisplayController shieldController;
    [SerializeField] LootDisplayController helmetController;
    [SerializeField] LootDisplayController breastPlateController;
    [SerializeField] LootDisplayController gauntletsController;
    [SerializeField] LootDisplayController magnifyingGlassController;
    [SerializeField] LootDisplayController tombOfLuckController;
    [SerializeField] LootDisplayController gemPouchController;
    [SerializeField] LootDisplayController walletController;

    //chance to get each item
    [SerializeField] float swordChance;
    [SerializeField] float longSwordChance;
    [SerializeField] float spaerChance;
    [SerializeField] float daggerChance;
    [SerializeField] float shieldChance;
    [SerializeField] float helmetChance;
    [SerializeField] float breastPlateChance;
    [SerializeField] float gauntletsChance;
    [SerializeField] float magnifyingGlassChance;
    [SerializeField] float tombOfLuckChance;
    [SerializeField] float gemPouchChance;
    [SerializeField] float walletChance;

    //private List<LootDisplayController> lootList;

    // Start is called before the first frame update
    void Start()
    {
        //lootList = new List<LootDisplayController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLoot(int floor)
    {
        float num = Random.Range(0.0f, swordChance + shieldChance + walletChance);
        LootDisplayController holder = walletController;

        //set the loot from the chest
        if(num < swordChance)
        {
            holder = swordController;
        }
        else if(num < swordChance + shieldChance)
        {
            holder = shieldController;
        }

        holder.AddLoot();
        holder.UpdateText();
    }

    public void GetWeight(float weight, int StartingFloor, int currentFloor)
    {
        //calculate the weight
        //have a starting weight and a starting floor and current floor
        //get difference between the current floor and the chests starting floor
        //if (x <= 200)
        //weight + x
        //else if (x > 200)
        //weight + x - (x-200)^2
    }
}
