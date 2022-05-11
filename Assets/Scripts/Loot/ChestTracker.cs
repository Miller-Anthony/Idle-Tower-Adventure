using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTracker : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] LootTracker loot;

    private Queue<GameObject> chestQueue;

    // Start is called before the first frame update
    void Start()
    {
        chestQueue = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetQueueSize()
    {
        return chestQueue.Count;
    }

    public void AddChest(GameObject chest)
    {
        if(chestQueue.Count == 0)
        {
            button.SetActive(true);
        }
        
        chestQueue.Enqueue(chest);
    }

    public void LootChest()
    {
        loot.AddLoot(chestQueue.Dequeue().GetComponent<ChestManager>().GetFloor());

        if(chestQueue.Count == 0)
        {
            button.SetActive(false);
        }
    }

    
}
