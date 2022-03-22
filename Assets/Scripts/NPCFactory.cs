using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFactory
{
    [SerializeField] static GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn an enemy at the given position
    public static GameObject SpawnEmemy(Vector3 pos, RoomController floor)
    {
        GameObject holder = GameObject.Instantiate(enemy);
        holder.transform.position = pos;
        holder.GetComponent<NPCStats>().SetLevel(3);
        holder.GetComponent<CombatController>().SetFloor(floor);
        return holder;
    }
}
