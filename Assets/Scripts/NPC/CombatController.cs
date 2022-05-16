using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] NPCStats stats;

    private GeneralStats general;
    private RoomController floor;

    // Start is called before the first frame update
    void Start()
    {
        general = GameObject.Find("Canvas").GetComponent<GeneralStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.GetHealth() <= 0)
        {
            Destroy(gameObject);

            //if it was an enemy that died, start the timer to spawn another one
            if(gameObject.tag == "enemy")
            {
                floor.StartTimer(stats.GetLevel());
                general.AddGold(stats.GetGold());
            }
            //if it was an adventurer that dies, decrease the count
            else if (name == "Adventurer(Clone)")
            {
                general.DestroyAdventurer();
            }
        }
    }

    public void SetFloor(RoomController room)
    {
        floor = room;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "enemy":
                collision.GetComponent<NPCStats>().SubtractHealth(stats.GetStrength());
                break;
            case "Player":
                collision.GetComponent<NPCStats>().SubtractHealth(stats.GetStrength());
                break;
            default:
                break;
        }
    }
}