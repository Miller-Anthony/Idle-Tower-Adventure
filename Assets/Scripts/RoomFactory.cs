using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFactory : MonoBehaviour
{
    //serilizable data
    [SerializeField] GameObject lRoom;
    [SerializeField] GameObject rRoom;

    //private data
    private GeneralStats stats;
    private FloorTracker tracker;
    private StatStorrage enemyStats;
    private bool floorNeeded = true;

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

    //when the first enemy touches the ladder, spawn a new floor
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && floorNeeded)
        {
            //object to hold the created room;
            GameObject holder;

            //set what room to spawn
            if (stats.GetTopFloor() % 2 == 0)
            {
                holder = lRoom;
            }
            else
            {
                holder = rRoom;
            }

            //make the next room
            holder = Instantiate(holder);
            RoomController holdRoom = holder.GetComponent<RoomController>();

            //update enemy held stats
            enemyStats.SetStrength((int)(enemyStats.GetStrength() * 1.15f) + 1);
            enemyStats.SetHealth((int)(enemyStats.GetHealth() * 1.15f) + 1);
            enemyStats.SetGold((int)(enemyStats.GetGold() * 1.05f) + 1);

            //Calculate the scale of the room
            Vector3 scale = holder.transform.localScale;
            scale.x *= 1.5f * Screen.width / Screen.height;
            scale.y *= 1.5f * Screen.width / Screen.height;
            holder.transform.localScale = scale;

            //set stats of the room
            stats.NextFloor();
            holdRoom.SetFloor(stats.GetTopFloor());
            holdRoom.SetEnemyStrength(enemyStats.GetStrength());
            holdRoom.SetEnemyHealth(enemyStats.GetHealth());
            holdRoom.SetEnemyGold(enemyStats.GetGold());
            Vector3 pos = holder.transform.position;
            pos.y = GetComponentInParent<Transform>().position.y + scale.y;
            holder.transform.position = pos;

            //disable script so it will not check to spawn more floors
            gameObject.GetComponent<RoomFactory>().enabled = false;
            floorNeeded = false;

            //add floor to the floor tracker
            tracker.AddFloor(holder);
        }
    }
}
