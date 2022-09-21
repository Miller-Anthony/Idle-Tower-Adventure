using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTracker : MonoBehaviour
{
    [SerializeField] GeneralStats stats;
    [SerializeField] CameraController cam;
    
    private Queue<GameObject> floorQueue;
    private GameObject topFloor;
    private int queueSize = 0;
    private int maxQueueSize = 0;
    private int minQueueSize = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject room = GameObject.Find("LRoom");
        floorQueue = new Queue<GameObject>();
        topFloor = room;
        floorQueue.Enqueue(room);


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

    public int GetQueueSize()
    {
        return queueSize;
    }

    public void SetQueueSize(int size)
    {
        if(size > maxQueueSize)
        {
            size = maxQueueSize;
        }
        else if (size < minQueueSize)
        {
            size = minQueueSize;
        }
        queueSize = size;
    }

    public int GetCurrentQueueSize()
    {
        return floorQueue.Count;
    }

    public void SetMaxQueueSize(int size)
    {
        maxQueueSize = size;
    }

    public int GetMaxQueueSize()
    {
        return maxQueueSize;
    }

    public void SetMinQueueSize(int size)
    {
        minQueueSize = size;
    }

    public int GetMinQueueSize()
    {
        return minQueueSize;
    }

    public void SetBottomFloor(int floor)
    {
        RoomController holderController = floorQueue.Peek().GetComponent<RoomController>();
        while (holderController.GetFloor() < floor)
        {
            GameObject holder = floorQueue.Dequeue();
            
            holderController.SetActive(false);

            holderController = floorQueue.Peek().GetComponent<RoomController>();

            stats.SetBottomFloor(holderController.GetFloor());
        }
    }

    public void ClearFloors(int count = 10)
    {
        SetBottomFloor(GetBottomFloor().GetComponent<RoomController>().GetFloor() + count);
    }

    public void AddFloor(GameObject floor)
    {
        topFloor = floor;
        floorQueue.Enqueue(floor);
        cam.SetLimit(floor.transform.position.y);
    }

    public GameObject GetBottomFloor()
    {
        return floorQueue.Peek();
    }

    public GameObject GetTopFloor()
    {
        return topFloor;
    }
}
