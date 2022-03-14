using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] NPCStats stats;
    [SerializeField] bool moveLeft;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move NPC left if odd floor
        if(moveLeft)
        {
            gameObject.transform.position += -transform.right * stats.GetSpeed() * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position += transform.right * stats.GetSpeed() * Time.deltaTime;
        }
        //move NPC right if even floor
    }

    public void SetMoveLeft(bool val)
    {
        moveLeft = val;
    }

    public bool GetMoveLeft()
    {
        return moveLeft;
    }
}
