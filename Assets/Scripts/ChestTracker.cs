using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTracker : MonoBehaviour
{
    [SerializeField] float spawnChance;
    [SerializeField] int minFloorSpawn;
    [SerializeField] GeneralStats genStats;

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
        chestQueue.Enqueue(chest);
    }

    public GameObject LootChest()
    {
        return chestQueue.Dequeue();
    }

    //tell weither a chest should spawn or not
    public bool ChestSpawn()
    {
        bool answer = false;

        if (genStats.GetTopFloor() >= minFloorSpawn)
        {
            float num = Random.Range(0.0f, 100.0f);

            if (num <= spawnChance)
            {
                answer = true;
            }
        }

        return answer;
    }
}
