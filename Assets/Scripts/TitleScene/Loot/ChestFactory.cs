using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestFactory : MonoBehaviour
{
    [SerializeField] float spawnChance;
    [SerializeField] int minFloorSpawn;
    [SerializeField] GameObject chest;
    [SerializeField] LootTracker loot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //tell weither a chest should spawn or not
    public bool SpawnCheck(int floor)
    {
        bool answer = false;

        if (floor >= minFloorSpawn) //top floor loads before the floors generate, so it will spawn chests on lower floors when loading
        {
            float num = Random.Range(0.0f, 100.0f);

            if (num <= spawnChance % loot.GetController("dungeonMap").GetTotalBonus())
            {
                answer = true;
            }
        }

        return answer;
    }

    public GameObject SpawnChest(GameObject pos, int floor)
    {
        //create the chest and move it to where it needs to be
        GameObject holder = Instantiate(chest);
        holder.transform.position = pos.transform.position;

        //calculate and set the scale of the chest
        Vector3 scale = holder.transform.localScale;
        scale.x *= 1.5f * Screen.width / Screen.height;
        scale.y *= 1.5f * Screen.width / Screen.height;
        holder.transform.localScale = scale;

        //set the chests data
        holder.GetComponent<ChestManager>().SetFloor(floor);

        return holder;
    }
}
