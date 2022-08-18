using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [SerializeField] ChestTracker tracker;

    private int floor;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.Find("ChestTracker").GetComponent<ChestTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFloor(int f)
    {
        floor = f;
    }

    //get the floor the chest spawned on
    public int GetFloor()
    {
        return floor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            tracker.AddChest(floor);
            gameObject.SetActive(false);
        }
    }
}
