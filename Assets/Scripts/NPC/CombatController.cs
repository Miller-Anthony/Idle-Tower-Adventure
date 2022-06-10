using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] NPCStats stats;

    private GeneralStats general;
    private RoomController floor;
    private float enemyHealthTimer;

    // Start is called before the first frame update
    void Start()
    {
        general = GameObject.Find("Canvas").GetComponent<GeneralStats>();
        enemyHealthTimer = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.IsDead())
        {
            Destroy(gameObject);

            //if it was an enemy that died, start the timer to spawn another one
            if(gameObject.tag == "enemy")
            {
                floor.StartTimer(stats.GetLevel());
                general.AddGold(stats.GetGold());
            }
            //if it was an adventurer that dies, decrease the count
            else if (name == "Adventurer(Clone)" || name == "SkilledAdventurer(Clone)")
            {
                general.DestroyAdventurer();
            }
        }
        else if (tag == "enemy" && !stats.IsFullHealth())
        {
            enemyHealthTimer -= Time.deltaTime;
            if (enemyHealthTimer <= 0.0f)
            {
                stats.RegenHealth();
                enemyHealthTimer = 2.0f;
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
                collision.GetComponent<NPCStats>().Damage(stats.GetStrength());
                break;
            case "Player":
                collision.GetComponent<NPCStats>().Damage(stats.GetStrength());
                break;
            default:
                break;
        }
    }
}
