using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFactory : MonoBehaviour
{
    //serilizable data
    [SerializeField] GameObject lRoom;
    [SerializeField] GameObject rRoom;
    [SerializeField] GameObject lBossRoom;
    [SerializeField] GameObject rBossRoom;

    //private data
    private GeneralStats stats;
    private FloorTracker tracker;
    private StatStorrage enemyStats;
    private bool floorNeeded = true;
    private bool bossFloor = false;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Canvas").GetComponent<GeneralStats>();
        tracker = GameObject.Find("Ground").GetComponent<FloorTracker>();
        enemyStats = GameObject.Find("EnemyStatHolder").GetComponent<StatStorrage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        stats = GameObject.Find("Canvas").GetComponent<GeneralStats>();
        tracker = GameObject.Find("Ground").GetComponent<FloorTracker>();
        enemyStats = GameObject.Find("EnemyStatHolder").GetComponent<StatStorrage>();
    }

    //when the first enemy touches the ladder, spawn a new floor
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && floorNeeded)
        {
            BuildNextFloor();
        }
    }

    public GameObject BuildNextFloor(bool loading = false)
    {
        //object to hold the created room;
        GameObject holder;

        //set what room to spawn
        if (stats.GetTopFloor() % 2 == 0)
        {
            if ((stats.GetTopFloor() + 1) % 5 == 0)
            {
                holder = lBossRoom;
                bossFloor = true;
            }
            else
            {
                holder = lRoom;
            }

        }
        else
        {
            if ((stats.GetTopFloor() + 1) % 5 == 0)
            {
                holder = rBossRoom;
                bossFloor = true;
            }
            else
            {
                holder = rRoom;
            }
        }

        //make the next room
        holder = Instantiate(holder);
        RoomController holdRoom = holder.GetComponent<RoomController>();

        //update enemy held stats
        enemyStats.SetStrength((enemyStats.GetStrength() * 1.2f) + 1);
        enemyStats.SetHealth((enemyStats.GetHealth() * 1.2f) + 1);
        enemyStats.SetGold((enemyStats.GetGold() * 1.1f) + 1);

        //Calculate the scale of the room
        Vector3 scale = holder.transform.localScale;
        scale.x *= 1.5f * Screen.width / Screen.height;
        scale.y *= 1.5f * Screen.width / Screen.height;
        holder.transform.localScale = scale;

        //set stats of the room
        stats.NextFloor();
        holdRoom.SetFloor(stats.GetTopFloor());
        holdRoom.SetSpawnCount(CalculateSpawnCount(stats.GetTopFloor() % 50));
        holdRoom.SetLoading(loading);
        if (bossFloor)
        {
            holdRoom.SetEnemyStrength((enemyStats.GetStrength() * 1.2f) + 1);
            holdRoom.SetEnemyHealth((enemyStats.GetHealth() * 1.2f) + 1);
            holdRoom.SetEnemyGold((enemyStats.GetGold() * 1.05f) + 1);
        }
        else
        {
            holdRoom.SetEnemyStrength(enemyStats.GetStrength());
            holdRoom.SetEnemyHealth(enemyStats.GetHealth());
            holdRoom.SetEnemyGold(enemyStats.GetGold());
        }

        Vector3 pos = holder.transform.position;
        pos.y = GetComponentInParent<Transform>().position.y + scale.y;
        holder.transform.position = pos;

        //disable script so it will not check to spawn more floors
        gameObject.GetComponent<RoomFactory>().enabled = false;
        floorNeeded = false;

        //add floor to the floor tracker
        tracker.AddFloor(holder);

        return holder;
    }

    private int CalculateSpawnCount(int floor)
    {
        switch (floor)
        {
            case 1:
                return 1;
            case 2:
                return 1;
            case 3:
                return 1;
            case 4:
                return 2;
            case 5:
                return 2;
            case 6:
                return 1;
            case 7:
                return 1;
            case 8:
                return 2;
            case 9:
                return 2;
            case 10:
                return 2;
            case 11:
                return 1;
            case 12:
                return 1;
            case 13:
                return 2;
            case 14:
                return 3;
            case 15:
                return 2;
            case 16:
                return 1;
            case 17:
                return 1;
            case 18:
                return 2;
            case 19:
                return 3;
            case 20:
                return 3;
            case 21:
                return 1;
            case 22:
                return 1;
            case 23:
                return 2;
            case 24:
                return 2;
            case 25:
                return 3;
            case 26:
                return 1;
            case 27:
                return 1;
            case 28:
                return 2;
            case 29:
                return 3;
            case 30:
                return 3;
            case 31:
                return 1;
            case 32:
                return 2;
            case 33:
                return 2;
            case 34:
                return 2;
            case 35:
                return 3;
            case 36:
                return 1;
            case 37:
                return 2;
            case 38:
                return 2;
            case 39:
                return 3;
            case 40:
                return 3;
            case 41:
                return 1;
            case 42:
                return 2;
            case 43:
                return 3;
            case 44:
                return 3;
            case 45:
                return 3;
            case 46:
                return 1;
            case 47:
                return 2;
            case 48:
                return 3;
            case 49:
                return 3;
            case 0:
                return 4;
            default:
                return 1;
        }
    }
}
