using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTracker : MonoBehaviour
{
    //odjects that can be added to the list
    [SerializeField] LootDisplayController swordController;
    [SerializeField] LootDisplayController longSwordController;
    [SerializeField] LootDisplayController shieldController;
    [SerializeField] LootDisplayController helmetController;
    [SerializeField] LootDisplayController magnifyingGlassController;
    [SerializeField] LootDisplayController walletController;

    //chance to get each item
    [SerializeField] float swordChance;
    [SerializeField] float longSwordChance;
    [SerializeField] float shieldChance;
    [SerializeField] float helmetChance;
    [SerializeField] float magnifyingGlassChance;
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
}
