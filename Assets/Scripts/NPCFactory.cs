using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFactory : MonoBehaviour
{
    [SerializeField] StatStorrage adventurerStats;
    [SerializeField] StatStorrage fighterStats;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject adventurer;
    [SerializeField] GameObject fighter;
    [SerializeField] FloorTracker tracker;

    private float fighterTimer = 0;

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
    }

    //spawn an enemy at the given position
    public GameObject SpawnEmemy(Vector3 pos, RoomController floor, int lvl)
    {
        //Make the object and store its stats
        GameObject holder = Instantiate(enemy);
        NPCStats holdStats = holder.GetComponent<NPCStats>();

        //Calculate the scale of the room
        Vector3 scale = holder.transform.localScale;
        scale.x *= 1.5f * Screen.width / Screen.height;
        scale.y *= 1.5f * Screen.width / Screen.height;
        holder.transform.localScale = scale;

        //set the stats
        holder.transform.position = pos;
        holdStats.SetLevel(lvl);
        holdStats.SetHealth(floor.GetEnemyHealth());
        holdStats.SetStrength(floor.GetEnemyStrength());
        holdStats.SetGold(floor.GetEnemyGold());
        holder.GetComponent<CombatController>().SetFloor(floor);

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

        //Calculate the scale of the room
        Vector3 scale = holder.transform.localScale;
        scale.x *= 1.5f * Screen.width / Screen.height;
        scale.y *= 1.5f * Screen.width / Screen.height;
        holder.transform.localScale = scale;

        //get the adventurers stat block to be able to set its stats
        NPCStats holdStats = holder.GetComponent<NPCStats>();

        //set the adventurers stats
        holdStats.SetLevel(adventurerStats.GetLevel());
        holdStats.SetHealth(adventurerStats.GetHealth());
        holdStats.SetStrength(adventurerStats.GetStrength());
        holdStats.SetSpeed(adventurerStats.GetSpeed());

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

        //Set the position of the adventurer
        holder.transform.position = pos;

        //Calculate the scale of the room
        Vector3 scale = holder.transform.localScale;
        scale.x *= 1.5f * Screen.width / Screen.height;
        scale.y *= 1.5f * Screen.width / Screen.height;
        holder.transform.localScale = scale;

        //get the adventurers stat block to be able to set its stats
        NPCStats holdStats = holder.GetComponent<NPCStats>();

        //set the adventurers stats
        holdStats.SetLevel(fighterStats.GetLevel());
        holdStats.SetHealth(fighterStats.GetHealth());
        holdStats.SetStrength(fighterStats.GetStrength());
        holdStats.SetSpeed(fighterStats.GetSpeed());
        holdStats.SetSpawn(fighterStats.GetSpawn());

        return holder;
    }
}
