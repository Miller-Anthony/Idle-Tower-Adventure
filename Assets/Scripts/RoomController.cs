using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] int floor = 0;
    [SerializeField] int spawnCount = 1;
    [SerializeField] float spawnTime = 2;
    
    [SerializeField] GameObject warrior;

    private Vector3 position;
    private Vector3 enemy1;
    private Vector3 enemy2;
    private Vector3 enemy3;
    private Vector3 enemy4;
    private Vector2 boundry;
    private float spawnX;
    private float timer1 = 0;
    private float timer2 = 0;
    private float timer3 = 0;
    private float timer4 = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the X spawn position for players NPCs for the floor
        if (floor % 2 == 0)
        {
            spawnX = gameObject.transform.position.x - 2.5f;
        }
        else
        {
            spawnX = gameObject.transform.position.x + 2.5f;
        }

        //create the position the players NPCs should be spawned at
        position = new Vector3(spawnX, gameObject.transform.position.y - 0.5f, -1);

        //calculate the X spawn position for enemies for the floor 
        if (floor % 2 == 0)
        {
            spawnX = gameObject.transform.position.x + 1.5f;

            //create the position the enemies spawn for the floor
            enemy1 = new Vector3(spawnX, gameObject.transform.position.y - 0.5f, -1);
            enemy2 = new Vector3(spawnX - 0.5f, gameObject.transform.position.y - 0.5f, -1);
            enemy3 = new Vector3(spawnX - 1, gameObject.transform.position.y - 0.5f, -1);
            enemy4 = new Vector3(spawnX - 1.5f, gameObject.transform.position.y - 0.5f, -1);
        }
        else
        {
            spawnX = gameObject.transform.position.x - 1.5f;

            //create the position the enemies spawn for the floor
            enemy1 = new Vector3(spawnX, gameObject.transform.position.y - 0.5f, -1);
            enemy2 = new Vector3(spawnX + 0.5f, gameObject.transform.position.y - 0.5f, -1);
            enemy3 = new Vector3(spawnX + 1, gameObject.transform.position.y - 0.5f, -1);
            enemy4 = new Vector3(spawnX + 1.5f, gameObject.transform.position.y - 0.5f, -1);
        }

        //create the position the enemies spawn for the floor
        enemy1 = new Vector3(spawnX, gameObject.transform.position.y - 0.5f, -1);
        enemy2 = new Vector3(spawnX - 0.5f, gameObject.transform.position.y - 0.5f, -1);
        enemy3 = new Vector3(spawnX - 1, gameObject.transform.position.y - 0.5f, -1);
        enemy4 = new Vector3(spawnX - 1.5f, gameObject.transform.position.y - 0.5f, -1);

        //calculate the boundry for the mouse clicks
        boundry = new Vector2(gameObject.transform.position.y + 1, gameObject.transform.position.y - 1);

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
                GameObject holder = Instantiate(warrior);
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
}
