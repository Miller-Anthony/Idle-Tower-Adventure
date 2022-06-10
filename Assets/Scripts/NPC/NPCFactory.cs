using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFactory : MonoBehaviour
{
    [SerializeField] GeneralStats general;
    [SerializeField] StatStorrage adventurerStats;
    [SerializeField] StatStorrage fighterStats;
    [SerializeField] StatStorrage barbarianStats;
    [SerializeField] StatStorrage rogueStats;
    [SerializeField] StatStorrage rangerStats;
    [SerializeField] StatStorrage monkStats;
    [SerializeField] StatStorrage clericStats;
    [SerializeField] StatStorrage bardStats;
    [SerializeField] StatStorrage wizzardStats;
    [SerializeField] StatStorrage warlockStats;
    [SerializeField] StatStorrage sorcererStats;
    [SerializeField] StatStorrage paladinStats;
    [SerializeField] StatStorrage druidStats;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemyChest;
    [SerializeField] GameObject adventurer;
    [SerializeField] GameObject skilledAdventurer;
    [SerializeField] GameObject fighter;
    [SerializeField] GameObject barbarian;
    [SerializeField] GameObject rogue;
    [SerializeField] GameObject ranger;
    [SerializeField] GameObject monk;
    [SerializeField] GameObject cleric;
    [SerializeField] GameObject bard;
    [SerializeField] GameObject wizzard;
    [SerializeField] GameObject warlock;
    [SerializeField] GameObject sorcerer;
    [SerializeField] GameObject paladin;
    [SerializeField] GameObject druid;
    [SerializeField] FloorTracker tracker;

    [SerializeField] float chestChance;

    private float fighterTimer = 0;
    private float barbarianTimer = 0;
    private float rogueTimer = 0;
    private float rangerTimer = 0;
    private float monkTimer = 0;
    private float clericTimer = 0;
    private float bardTimer = 0;
    private float wizzardTimer = 0;
    private float warlockTimer = 0;
    private float sorcererTimer = 0;
    private float paladinTimer = 0;
    private float druidTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fighterStats.GetLevel() > 0 && fighterTimer < fighterStats.GetSpawn())
        {
            fighterTimer += Time.deltaTime;

            if (fighterTimer >= fighterStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("fighter");
                fighterTimer = 0;
            }
        }

        if (barbarianStats.GetLevel() > 0 && barbarianTimer < barbarianStats.GetSpawn())
        {
            barbarianTimer += Time.deltaTime;

            if (barbarianTimer >= barbarianStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("barbarian");
                barbarianTimer = 0;
            }
        }

        if (rogueStats.GetLevel() > 0 && rogueTimer < rogueStats.GetSpawn())
        {
            rogueTimer += Time.deltaTime;

            if (rogueTimer >= rogueStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("rogue");
                rogueTimer = 0;
            }
        }

        if (rangerStats.GetLevel() > 0 && rangerTimer < rangerStats.GetSpawn())
        {
            rangerTimer += Time.deltaTime;

            if (rangerTimer >= rangerStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("ranger");
                rangerTimer = 0;
            }
        }

        if(monkStats.GetLevel() > 0 && monkTimer < monkStats.GetSpawn())
        {
            monkTimer += Time.deltaTime;

            if (monkTimer >= monkStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("monk");
                monkTimer = 0;
            }
        }

        if (clericStats.GetLevel() > 0 && clericTimer < clericStats.GetSpawn())
        {
            clericTimer += Time.deltaTime;

            if (clericTimer >= clericStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("cleric");
                clericTimer = 0;
            }
        }

        if (bardStats.GetLevel() > 0 && bardTimer < bardStats.GetSpawn())
        {
            bardTimer += Time.deltaTime;

            if (bardTimer >= bardStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("bard");
                bardTimer = 0;
            }
        }

        if (wizzardStats.GetLevel() > 0 && wizzardTimer < wizzardStats.GetSpawn())
        {
            wizzardTimer += Time.deltaTime;

            if (wizzardTimer >= wizzardStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("wizzard");
                wizzardTimer = 0;
            }
        }

        if (warlockStats.GetLevel() > 0 && warlockTimer < warlockStats.GetSpawn())
        {
            warlockTimer += Time.deltaTime;

            if (warlockTimer >= warlockStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("warlock");
                warlockTimer = 0;
            }
        }

        if (sorcererStats.GetLevel() > 0 && sorcererTimer < sorcererStats.GetSpawn())
        {
            sorcererTimer += Time.deltaTime;

            if (sorcererTimer >= sorcererStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("sorcerer");
                sorcererTimer = 0;
            }
        }

        if (paladinStats.GetLevel() > 0 && paladinTimer < paladinStats.GetSpawn())
        {
            paladinTimer += Time.deltaTime;

            if (paladinTimer >= paladinStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("paladin");
                paladinTimer = 0;
            }
        }

        if (druidStats.GetLevel() > 0 && druidTimer < druidStats.GetSpawn())
        {
            druidTimer += Time.deltaTime;

            if (druidTimer >= druidStats.GetSpawn())
            {
                tracker.GetBottomFloor().GetComponent<RoomController>().SpawnMercinary("druid");
                druidTimer = 0;
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
        GameObject toSpawn = adventurer;
        if (general.GetSkilledChance() >= Random.Range(0.01f, 1))
        {
            toSpawn = skilledAdventurer;
        }
        GameObject holder = Instantiate(toSpawn);
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

        if(holder == skilledAdventurer)
        {
            //set the skilledAdventurers stats
            holdStats.SetLevel(adventurerStats.GetLevel());
            holdStats.SetMaxHealth(adventurerStats.GetHealth() * 0.05f);
            holdStats.SetStrength(adventurerStats.GetStrength()* 0.05f);
            holdStats.SetSpeed(adventurerStats.GetSpeed() * 0.02f);
            holdStats.SetGold(new BigNumber(0));
        }
        else
        {
            //set the adventurers stats
            holdStats.SetLevel(adventurerStats.GetLevel());
            holdStats.SetMaxHealth(adventurerStats.GetHealth());
            holdStats.SetStrength(adventurerStats.GetStrength());
            holdStats.SetSpeed(adventurerStats.GetSpeed());
            holdStats.SetGold(new BigNumber(0));
        }

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

    public GameObject SpawnRogue(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(rogue);
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
        holdStats.SetLevel(rogueStats.GetLevel());
        holdStats.SetMaxHealth(rogueStats.GetHealth());
        holdStats.SetStrength(rogueStats.GetStrength());
        holdStats.SetSpeed(rogueStats.GetSpeed());
        holdStats.SetSpawn(rogueStats.GetSpawn());
        holdStats.SetGold(new BigNumber(0));

        return holder;
    }

    public GameObject SpawnRanger(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(ranger);
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
        holdStats.SetLevel(rangerStats.GetLevel());
        holdStats.SetMaxHealth(rangerStats.GetHealth());
        holdStats.SetStrength(rangerStats.GetStrength());
        holdStats.SetSpeed(rangerStats.GetSpeed());
        holdStats.SetSpawn(rangerStats.GetSpawn());
        holdStats.SetGold(new BigNumber(0));

        return holder;
    }

    public GameObject SpawnMonk(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(monk);
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
        holdStats.SetLevel(monkStats.GetLevel());
        holdStats.SetMaxHealth(monkStats.GetHealth());
        holdStats.SetStrength(monkStats.GetStrength());
        holdStats.SetSpeed(monkStats.GetSpeed());
        holdStats.SetSpawn(monkStats.GetSpawn());
        holdStats.SetGold(new BigNumber(0));

        return holder;
    }

    public GameObject SpawnCleric(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(cleric);
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
        holdStats.SetLevel(clericStats.GetLevel());
        holdStats.SetMaxHealth(clericStats.GetHealth());
        holdStats.SetStrength(clericStats.GetStrength());
        holdStats.SetSpeed(clericStats.GetSpeed());
        holdStats.SetSpawn(clericStats.GetSpawn());
        holdStats.SetGold(new BigNumber(0));

        return holder;
    }

    public GameObject SpawnBard(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(bard);
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
        holdStats.SetLevel(bardStats.GetLevel());
        holdStats.SetMaxHealth(bardStats.GetHealth());
        holdStats.SetStrength(bardStats.GetStrength());
        holdStats.SetSpeed(bardStats.GetSpeed());
        holdStats.SetSpawn(bardStats.GetSpawn());
        holdStats.SetGold(new BigNumber(0));

        return holder;
    }

    public GameObject SpawnWizzard(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(wizzard);
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
        holdStats.SetLevel(wizzardStats.GetLevel());
        holdStats.SetMaxHealth(wizzardStats.GetHealth());
        holdStats.SetStrength(wizzardStats.GetStrength());
        holdStats.SetSpeed(wizzardStats.GetSpeed());
        holdStats.SetSpawn(wizzardStats.GetSpawn());
        holdStats.SetGold(new BigNumber(0));

        return holder;
    }

    public GameObject SpawnWarlock(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(warlock);
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
        holdStats.SetLevel(warlockStats.GetLevel());
        holdStats.SetMaxHealth(warlockStats.GetHealth());
        holdStats.SetStrength(warlockStats.GetStrength());
        holdStats.SetSpeed(warlockStats.GetSpeed());
        holdStats.SetSpawn(warlockStats.GetSpawn());
        holdStats.SetGold(new BigNumber(0));

        return holder;
    }

    public GameObject SpawnSorcerer(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(sorcerer);
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
        holdStats.SetLevel(sorcererStats.GetLevel());
        holdStats.SetMaxHealth(sorcererStats.GetHealth());
        holdStats.SetStrength(sorcererStats.GetStrength());
        holdStats.SetSpeed(sorcererStats.GetSpeed());
        holdStats.SetSpawn(sorcererStats.GetSpawn());
        holdStats.SetGold(new BigNumber(0));

        return holder;
    }

    public GameObject SpawnPaladin(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(paladin);
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
        holdStats.SetLevel(paladinStats.GetLevel());
        holdStats.SetMaxHealth(paladinStats.GetHealth());
        holdStats.SetStrength(paladinStats.GetStrength());
        holdStats.SetSpeed(paladinStats.GetSpeed());
        holdStats.SetSpawn(paladinStats.GetSpawn());
        holdStats.SetGold(new BigNumber(0));

        return holder;
    }

    public GameObject SpawnDruid(Vector3 pos, int floor)
    {
        GameObject holder = Instantiate(druid);
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
        holdStats.SetLevel(druidStats.GetLevel());
        holdStats.SetMaxHealth(druidStats.GetHealth());
        holdStats.SetStrength(druidStats.GetStrength());
        holdStats.SetSpeed(druidStats.GetSpeed());
        holdStats.SetSpawn(druidStats.GetSpawn());
        holdStats.SetGold(new BigNumber(0));

        return holder;
    }
}
