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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch(collision.tag)
        {
            case "ladder":
                StartClimbing();
                break;
            case "right":
                MoveRight();
                break;
            case "left":
                MoveLeft();
                break;
            case "enemy":
                if(moveLeft)
                {
                    gameObject.transform.position += transform.right;
                }
                else
                {
                    gameObject.transform.position -= transform.right;
                }
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "ladder":
                StopClimbing();
                break;
            case "right":
                
                break;
            case "left":
                
                break;
            default:
                break;
        }
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
