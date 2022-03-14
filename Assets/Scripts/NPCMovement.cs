using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] NPCStats stats;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move NPC
        gameObject.transform.position += -transform.right * stats.GetSpeed() * Time.deltaTime;
    }
}
