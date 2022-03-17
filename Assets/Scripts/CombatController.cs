using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] NPCStats stats;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(stats.GetHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "enemy":
                collision.GetComponent<NPCStats>().SubtractHealth(stats.GetStrength());
                break;
            case "Player":
                collision.GetComponent<NPCStats>().SubtractHealth(stats.GetStrength());
                break;
            default:
                break;
        }
    }
}
