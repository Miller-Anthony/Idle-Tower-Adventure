using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTracker : MonoBehaviour
{
    [SerializeField] GeneralStats stats;

    private Queue<GameObject> floorQueue;
    private int queueSize = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        floorQueue = new Queue<GameObject>();
        floorQueue.Enqueue(GameObject.Find("LRoom"));
    }

    // Update is called once per frame
    void Update()
    {
        while(queueSize != 0 && floorQueue.Count > queueSize)
        {
            RoomController holderController = floorQueue.Dequeue().GetComponent<RoomController>();
            holderController.SetActive(false);
        }
    }

    public int GetMaxQueueSize()
    {
        return queueSize;
    }

    public void SetMaxQueueSize(int size)
    {
        queueSize = size;
    }

    public int GetQueueSize()
    {
        return floorQueue.Count;
    }

    public void SetBottomFloor(int floor)
    {
        RoomController holderController = floorQueue.Peek().GetComponent<RoomController>();
        while (holderController.GetFloor() < floor)
        {
            GameObject holder = floorQueue.Dequeue();
            
            holderController.SetActive(false);

            holderController = floorQueue.Peek().GetComponent<RoomController>();
        }
    }

    public void AddFloor(GameObject floor)
    {
        floorQueue.Enqueue(floor);
    }

    public GameObject GetBottomFloor()
    {
        return floorQueue.Peek();
    }
}
