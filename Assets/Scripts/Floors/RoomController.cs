using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomController : MonoBehaviour
{
    [SerializeField] int floor = 1;
    [SerializeField] int spawnCount = 1;
    [SerializeField] float spawnTime = 2;
    [SerializeField] NPCFactory factory;
    [SerializeField] ChestFactory chestFactory;
    [SerializeField] GeneralStats stats;
    [SerializeField] GameObject enemySpawn1;
    [SerializeField] GameObject enemySpawn2;
    [SerializeField] GameObject enemySpawn3;
    [SerializeField] GameObject enemySpawn4;
    [SerializeField] GameObject playerSpawn;
    [SerializeField] GameObject chestSpawn;
    [SerializeField] Text text;

    //enemy stats for the floor
    [SerializeField] BigNumber strength;
    [SerializeField] BigNumber health;
    [SerializeField] BigNumber gold;

    private Vector2 boundry;
    private float timer1 = 0.1f;
    private float timer2 = 0.1f;
    private float timer3 = 0.1f;
    private float timer4 = 0.1f;
    private bool isTiming;
    private bool isActive = true;
    private bool isLoading = false;

    // Start is called before the first frame update
    void Start()
    {
        //set the NPCFactory and general stats to an enstantiated object with the script
        factory = GameObject.Find("Ground").GetComponent<NPCFactory>();
        stats = GameObject.Find("Canvas").GetComponent<GeneralStats>();
        chestFactory = GameObject.Find("ChestTracker").GetComponent<ChestFactory>();

        //set stats for first floor
        if (floor == 1)
        {
            health = new BigNumber(7);
            strength = new BigNumber(3);
            gold = new BigNumber(2);
        }

        //calculate the boundry for the mouse clicks
        boundry = new Vector2(transform.position.y + (transform.localScale.y / 2), transform.position.y - (transform.localScale.y / 2));

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

        //check to see if a chest should spawn
        if(floor % 10 == 0 && (chestFactory.SpawnCheck(floor) || floor % 50 == 0) && !isLoading)
        {
            chestFactory.SpawnChest(chestSpawn, floor);
        }

        //Set the floor UI
        text.text = floor.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        //spawn an adventurer
        if(Input.GetMouseButtonDown(0) && isActive && stats.GetMaxAdventurers() > stats.GetNumAdventurers())
        {
            Vector3 click = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //if the click is withis the boudry of the floor you spawn a warrior
            if (click.y < boundry.x && click.y > boundry.y)
            {
                factory.SpawnAdventurer(playerSpawn.transform.position, floor);
            }
            
        }
        
        //spawn new enemies
        if(isTiming && isActive)
        {
            if(timer1 > 0 && spawnCount > 0)
            {
                //decrement timer
                timer1 -= Time.deltaTime;
                //if timer is done, spawn a guy
                if(timer1 <= 0)
                {
                    factory.SpawnEmemy(enemySpawn1.transform.position, gameObject.GetComponent<RoomController>(), 1);
                }
            }
            if(timer2 > 0 && spawnCount > 1)
            {
                //decrement timer
                timer2 -= Time.deltaTime;
                //if timer is done, spawn a guy
                if (timer2 <= 0)
                {
                    factory.SpawnEmemy(enemySpawn2.transform.position, gameObject.GetComponent<RoomController>(), 2);
                }
            }
            if(timer3 > 0 && spawnCount > 2)
            {
                //decrement timer
                timer3 -= Time.deltaTime;
                //if timer is done, spawn a guy
                if (timer3 <= 0)
                {
                    factory.SpawnEmemy(enemySpawn3.transform.position, gameObject.GetComponent<RoomController>(), 3);
                }
            }
            if (timer4 > 0 && spawnCount > 3)
            {
                //decrement timer
                timer4 -= Time.deltaTime;
                //if timer is done, spawn a guy
                if (timer4 <= 0)
                {
                    factory.SpawnEmemy(enemySpawn4.transform.position, gameObject.GetComponent<RoomController>(), 4);
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

    // Set how many enemies spawn on the floor
    public void SetSpawnCount(int val)
    {
        if (val > 4)
        {
            val = 4;
        }    

        if(val < 1)
        {
            val = 1;
        }    
        spawnCount = val;
    }

    // returns the floor number
    public int GetSpawnCount()
    {
        return spawnCount;
    }

    public void SetEnemyStrength(BigNumber str)
    {
        strength = str;
    }

    public BigNumber GetEnemyStrength()
    {
        return strength;
    }

    public void SetEnemyHealth(BigNumber hp)
    {
        health = hp;
    }

    public BigNumber GetEnemyHealth()
    {
        return health;
    }

    public void SetEnemyGold(BigNumber gld)
    {
        gold = gld;
    }

    public BigNumber GetEnemyGold()
    {
        return gold;
    }

    public bool IsActive()
    {
        return isActive;
    }

    public void SetActive(bool active)
    {
        isActive = active;
    }

    public void SetLoading(bool status)
    {
        isLoading = status;
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

    public void SpawnMercinary(string mercinary)
    {
        switch(mercinary)
        {
            case "fighter":
                factory.SpawnFighter(playerSpawn.transform.position, floor);
                break;
            case "barbarian":
                factory.SpawnBarbarian(playerSpawn.transform.position, floor);
                break;
            default:
                break;
        }
    }
}
