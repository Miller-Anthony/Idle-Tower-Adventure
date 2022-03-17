using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] NPCStats stats;
    [SerializeField] bool moveLeft;

    private bool climb = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (climb)
        {
            gameObject.transform.position += transform.up * stats.GetSpeed() * Time.deltaTime;
        }
        //move NPC left if odd floor
        else if(moveLeft)
        {
            gameObject.transform.position += -transform.right * stats.GetSpeed() * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position += transform.right * stats.GetSpeed() * Time.deltaTime;
        }
        //move NPC right if even floor
    }

    public void MoveLeft()
    {
        moveLeft = true;
    }

    public void MoveRight()
    {
        moveLeft = false;
    }

    public bool GetDirection()
    {
        return moveLeft;
    }

    public void StartClimbing()
    {
        climb = true;
    }

    public void StopClimbing()
    {
        climb = false;
    }
}
