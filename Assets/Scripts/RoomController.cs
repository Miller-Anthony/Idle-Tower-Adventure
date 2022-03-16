using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] int floor = 0;
    [SerializeField] float spawnX;
    [SerializeField] float spawnY;
    private Vector3 position;
    [SerializeField] GameObject warrior;

    // Start is called before the first frame update
    void Start()
    {
        //create the position the object should be spawned at
        position = new Vector3(spawnX, spawnY, -1);
    }

    // Update is called once per frame
    void Update()
    {
        //spawn a warrior
        if(Input.GetMouseButtonDown(0))
        {
            GameObject holder = Instantiate(warrior);
            if (floor % 2 == 0)
            {
                holder.GetComponent<NPCMovement>().SetMoveLeft(false);
            }
            else
            {
                holder.GetComponent<NPCMovement>().SetMoveLeft(true);
            }
            
            
            holder.transform.position = position;
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
