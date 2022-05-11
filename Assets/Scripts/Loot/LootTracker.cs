using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTracker : MonoBehaviour
{
    //odjects that can be added to the list
    [SerializeField] GameObject sword;
    [SerializeField] GameObject shield;
    [SerializeField] GameObject wallet;

    //chance to get each item
    [SerializeField] float swordChance;
    [SerializeField] float shieldChance;
    [SerializeField] float walletChance;

    private List<GameObject> lootList;

    // Start is called before the first frame update
    void Start()
    {
        lootList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLoot(int floor)
    {
        float num = Random.Range(0.0f, 100.0f);
        GameObject holder = wallet;

        if(num < swordChance)
        {
            holder = sword;
        }
        else if(num < shieldChance)
        {
            holder = shield;
        }
        
        //check to see if the object is in the list
        //if it is, increment its level
        //if it is not, add it to the list
        lootList.Add(holder);
    }
}
