using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTracker : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] LootTracker loot;

    private Queue<int> chestQueue;

    // Start is called before the first frame update
    void Start()
    {
        chestQueue = new Queue<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetQueueSize()
    {
        return chestQueue.Count;
    }

    public void AddChest(int chestFloor)
    {
        if(chestQueue.Count == 0)
        {
            button.SetActive(true);
        }
        
        chestQueue.Enqueue(chestFloor);
    }

    public void LootChest()
    {
        loot.AddLoot(chestQueue.Dequeue());

        if(chestQueue.Count == 0)
        {
            button.SetActive(false);
        }
    }

    public int[] Save()
    {
        //make list
        int[] save = new int[chestQueue.Count];

        //populate list
        for (int i = 0; i < chestQueue.Count; i++)
        {
            save[i] = chestQueue.Dequeue();
            chestQueue.Enqueue(save[i]);
        }

        return save;
    }

    public void Load(int[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            chestQueue.Enqueue(data[i]);
        }
    }
}
