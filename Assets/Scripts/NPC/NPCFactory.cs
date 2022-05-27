using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFactory : MonoBehaviour
{
    [SerializeField] GeneralStats general;
    [SerializeField] StatStorrage adventurerStats;
    [SerializeField] StatStorrage fighterStats;
    [SerializeField] StatStorrage barbarianStats;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemyChest;
    [SerializeField] GameObject adventurer;
    [SerializeField] GameObject fighter;
    [SerializeField] GameObject barbarian;
    [SerializeField] FloorTracker tracker;

    [SerializeField] float chestChance;

    private float fighterTimer = 0;
    private float barbarianTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fighterTimer < fighterStats.GetSpawn() && fighterStats.GetLevel() > 0 && tag != "adventurer")
        {
            fighterTimer += Time.deltaTime;

            if (fighterTimer >= fighterStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("fighter");
                fighterTimer = 0;
            }
        }

        if (barbarianTimer < barbarianStats.GetSpawn() && barbarianStats.GetLevel() > 0 && tag != "adventurer")
        {
            barbarianTimer += Time.deltaTime;

            if (barbarianTimer >= barbarianStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("barbarian");
                barbarianTimer = 0;
            }
        }
    }

    //spawn an enemy at the given position
    public GameObject SpawnEmemy(Vector3 pos, RoomController floor, int lvl)
    {
        //determine if a chest will be spawned or not
        GameObject spawn = enemy;

        if(floor.GetFloor() % 5 != 0 && chestChance > Random.value)
        {
            spawn = enemyChest;
        }

        //Make the object and store its stats
        GameObject holder = Instantiate(spawn);
        NPCStats holdStats = holder.GetComponent<NPCStats>();

        //Calculate the scale of the room
        Vector3 scale = holder.transform.localScale;
        scale.x *= 1.5f * Screen.width / Screen.height;
        scale.y *= 1.5f * Screen.width / Screen.height;
        holder.transform.localScale = scale;

        //set the stats
        holder.transform.position = pos;
        holdStats.SetLevel(lvl);
        holdStats.SetMaxHealth(floor.GetEnemyHealth());
        holdStats.SetStrength(floor.GetEnemyStrength());
        holder.GetComponent<CombatController>().SetFloor(floor);

        if(spawn == enemyChest)
        {
            holdStats.SetGold(floor.GetEnemyGold() * 2.0f);
        }
        else
        {
            holdStats.SetGold(floor.GetEnemyGold());
        }

        return holder;
    }

    //spawn an adventurer at the given position
    public GameObject SpawnAdventurer(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(adventurer);
        if (floor % 2 == 0)
        {
            holder.GetComponent<NPCMovement>().MoveRight();
        }
        else
        {
            holder.GetComponent<NPCMovement>().MoveLeft();
        }

        //Set the position of the adventurer
        holder.transform.position = pos;

        //Calculate the scale of the adventurer
        Vector3 scale = holder.transform.localScale;
        scale.x *= 1.5f * Screen.width / Screen.height;
        scale.y *= 1.5f * Screen.width / Screen.height;
        holder.transform.localScale = scale;

        //get the adventurers stat block to be able to set its stats
        NPCStats holdStats = holder.GetComponent<NPCStats>();

        //set the adventurers stats
        holdStats.SetLevel(adventurerStats.GetLevel());
        holdStats.SetMaxHealth(adventurerStats.GetHealth());
        holdStats.SetStrength(adventurerStats.GetStrength());
        holdStats.SetSpeed(adventurerStats.GetSpeed());
        holdStats.SetGold(new BigNumber(0));

        general.SummonAdventurer();
        return holder;
    }

    public GameObject SpawnFighter(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(fighter);
        if (floor % 2 == 0)
        {
            holder.GetComponent<NPCMovement>().MoveRight();
        }
        else
        {
            holder.GetComponent<NPCMovement>().MoveLeft();
        }

        //Set the position of the fighter
        holder.transform.position = pos;

        //Calculate the scale of the fighter
        Vector3 scale = holder.transform.localScale;
        scale.x *= 1.5f * Screen.width / Screen.height;
        scale.y *= 1.5f * Screen.width / Screen.height;
        holder.transform.localScale = scale;

        //get the adventurers stat block to be able to set its stats
        NPCStats holdStats = holder.GetComponent<NPCStats>();

        //set the adventurers stats
        holdStats.SetLevel(fighterStats.GetLevel());
        holdStats.SetMaxHealth(fighterStats.GetHealth());
        holdStats.SetStrength(fighterStats.GetStrength());
        holdStats.SetSpeed(fighterStats.GetSpeed());
        holdStats.SetSpawn(fighterStats.GetSpawn());
        holdStats.SetGold(new BigNumber(0));

        return holder;
    }

    public GameObject SpawnBarbarian(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(barbarian);
        if (floor % 2 == 0)
        {
            holder.GetComponent<NPCMovement>().MoveRight();
        }
        else
        {
            holder.GetComponent<NPCMovement>().MoveLeft();
        }

        //Set the position of the barbarian
        holder.transform.position = pos;

        //Calculate the scale of the barbarian
        Vector3 scale = holder.transform.localScale;
        scale.x *= 1.5f * Screen.width / Screen.height;
        scale.y *= 1.5f * Screen.width / Screen.height;
        holder.transform.localScale = scale;

        //get the adventurers stat block to be able to set its stats
        NPCStats holdStats = holder.GetComponent<NPCStats>();

        //set the adventurers stats
        holdStats.SetLevel(barbarianStats.GetLevel());
        holdStats.SetMaxHealth(barbarianStats.GetHealth());
        holdStats.SetStrength(barbarianStats.GetStrength());
        holdStats.SetSpeed(barbarianStats.GetSpeed());
        holdStats.SetSpawn(barbarianStats.GetSpawn());
        holdStats.SetGold(new BigNumber(0));

        return holder;
    }
}
