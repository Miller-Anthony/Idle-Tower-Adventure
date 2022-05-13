using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTracker : MonoBehaviour
{
    //odjects that can be added to the list
    [SerializeField] LootDisplayController sword;
    [SerializeField] LootDisplayController shield;
    [SerializeField] LootDisplayController wallet;

    //chance to get each item
    [SerializeField] float swordChance;
    [SerializeField] float shieldChance;
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
        LootDisplayController holder = wallet;

        //set the loot from the chest
        if(num < swordChance)
        {
            holder = sword;
        }
        else if(num < swordChance + shieldChance)
        {
            holder = shield;
        }

        holder.AddLoot();
        holder.UpdateText();
    }
}
