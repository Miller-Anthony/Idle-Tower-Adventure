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
    private bool floorNeeded = true;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Canvas").GetComponent<GeneralStats>();
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

            //set stats of the room
            stats.NextFloor();
            holder.GetComponent<RoomController>().SetFloor(stats.GetTopFloor());
            Vector3 pos = holder.transform.position;
            pos.y = (stats.GetTopFloor() * 2) - 3;
            holder.transform.position = pos;

            //disable script so it will not check to spawn more floors
            gameObject.GetComponent<RoomFactory>().enabled = false;
            floorNeeded = false;
        }
    }
}
