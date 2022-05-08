using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestStats : MonoBehaviour
{
    private int floor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFloor(int f)
    {
        floor = f;
    }

    public int GetFloor()
    {
        return floor;
    }
}
