using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] int floor = 0;
    [SerializeField] int spawnCount = 1;
    [SerializeField] float spawnTime = 2;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject adventurer;
    [SerializeField] NPCFactory factory;

    private Vector3 position;
    private Vector3 enemy1;
    private Vector3 enemy2;
    private Vector3 enemy3;
    private Vector3 enemy4;
    private Vector2 boundry;
    private float spawnX;
    private float timer1 = 0.1f;
    private float timer2 = 0.1f;
    private float timer3 = 0.1f;
    private float timer4 = 0.1f;
    private bool isTiming;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the X spawn position for players NPCs for the floor
        if (floor % 2 == 0)
        {
            spawnX = gameObject.transform.position.x - 2.4f;
        }
        else
        {
            spawnX = gameObject.transform.position.x + 2.4f;
        }

        //create the position the players NPCs should be spawned at
        position = new Vector3(spawnX, gameObject.transform.position.y - 0.5f, -1);

        //calculate the X spawn position for enemies for the floor 
        if (floor % 2 == 0)
        {
            spawnX = gameObject.transform.position.x + 1.5f;

            //create the position the enemies spawn for the floor
            enemy1 = new Vector3(spawnX, gameObject.transform.position.y - 0.5f, -1);
            enemy2 = new Vector3(spawnX - 0.6f, gameObject.transform.position.y - 0.5f, -1);
            enemy3 = new Vector3(spawnX - 1.2f, gameObject.transform.position.y - 0.5f, -1);
            enemy4 = new Vector3(spawnX - 1.8f, gameObject.transform.position.y - 0.5f, -1);
        }
        else
        {
            spawnX = gameObject.transform.position.x - 1.5f;

            //create the position the enemies spawn for the floor
            enemy1 = new Vector3(spawnX, gameObject.transform.position.y - 0.5f, -1);
            enemy2 = new Vector3(spawnX + 0.6f, gameObject.transform.position.y - 0.5f, -1);
            enemy3 = new Vector3(spawnX + 1.2f, gameObject.transform.position.y - 0.5f, -1);
            enemy4 = new Vector3(spawnX + 1.8f, gameObject.transform.position.y - 0.5f, -1);
        }

        //calculate the boundry for the mouse clicks
        boundry = new Vector2(gameObject.transform.position.y + 1, gameObject.transform.position.y - 1);

        //make the first enemies spawn
        isTiming = true;
        
        //turn off timers that do not spawn
        if(spawnCount < 1)
        {
            timer1 = 0;
            timer2 = 0;
            timer3 = 0;
            timer4 = 0;
        }
        else if (spawnCount < 2)
        {
            timer2 = 0;
            timer3 = 0;
            timer4 = 0;
        }
        else if (spawnCount < 2)
        {
            timer3 = 0;
            timer4 = 0;
        }
        else if (spawnCount < 3)
        {
            timer4 = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //spawn a warrior
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 click = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //if the click is withis the boudry of the floor you spawn a warrior
            if (click.y < boundry.x && click.y > boundry.y)
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

                holder.transform.position = position;
            }
            
        }
        
        //spawn new enemies
        if(isTiming)
        {
            if(timer1 > 0 && spawnCount > 0)
            {
                //decrement timer
                timer1 -= Time.deltaTime;
                //if timer is done, spawn a guy
                if(timer1 <= 0)
                {
                    GameObject holder = Instantiate(enemy);
                    holder.transform.position = enemy1;
                    holder.GetComponent<NPCStats>().SetLevel(1);
                    holder.GetComponent<CombatController>().SetFloor(gameObject.GetComponent<RoomController>());
                }
            }
            if(timer2 > 0 && spawnCount > 1)
            {
                //decrement timer
                timer2 -= Time.deltaTime;
                //if timer is done, spawn a guy
                if (timer2 <= 0)
                {
                    factory.SpawnEmemy(enemy2, gameObject.GetComponent<RoomController>());
                }
            }
            if(timer3 > 0 && spawnCount > 2)
            {
                //decrement timer
                timer3 -= Time.deltaTime;
                //if timer is done, spawn a guy
                if (timer3 <= 0)
                {
                    factory.SpawnEmemy(enemy3, gameObject.GetComponent<RoomController>());
                }
            }
            if (timer4 > 0 && spawnCount > 3)
            {
                //decrement timer
                timer4 -= Time.deltaTime;
                //if timer is done, spawn a guy
                if (timer4 <= 0)
                {
                    GameObject holder = Instantiate(enemy);
                    holder.transform.position = enemy4;
                    holder.GetComponent<NPCStats>().SetLevel(4);
                    holder.GetComponent<CombatController>().SetFloor(gameObject.GetComponent<RoomController>());
                }
            }

            //if all timers are done, turn off the timer
            if(timer1 <= 0 && timer2 <= 0 && timer3 <= 0 && timer4 <= 0)
            {
                isTiming = false;
            }
        }

    }

    // Set the floor number
    public void SetFloor(int val)
    {
        floor = val;
    }

    // returns the floor number
    public int GetFloor()
    {
        return floor;
    }

    public void StartTimer(int timer)
    {
        switch(timer)
        {
            case 1:
                timer1 = spawnTime;
                isTiming = true;
                break;
            case 2:
                timer2 = spawnTime;
                isTiming = true;
                break;
            case 3:
                timer3 = spawnTime;
                isTiming = true;
                break;
            case 4:
                timer4 = spawnTime;
                isTiming = true;
                break;
            default:
                break;
        }
    }
}
