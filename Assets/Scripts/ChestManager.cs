using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [SerializeField] float spawnChance;
    [SerializeField] int minFloorSpawn;
    [SerializeField] GeneralStats genStats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChestSpawn()
    {
        bool answer = false;

        if(genStats.GetTopFloor() >= minFloorSpawn)
        {
            float num = Random.Range(0.0f, 100.0f);

            if(num <= spawnChance)
            {
                answer = true;
            }
        }
                
        return answer;
    }
}
