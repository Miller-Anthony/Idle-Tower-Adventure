using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GeneralStats stats;
    private Vector3 MouseStart;

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Canvas").GetComponent<GeneralStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseStart = new Vector3(0, Input.mousePosition.y, 0);
            MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);

        }
        else if (Input.GetMouseButton(0))
        {
            var MouseMove = new Vector3(0, Input.mousePosition.y, 0);
            MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
            transform.position = transform.position - (MouseMove - MouseStart);

            //if out of bounds above the tower
            if (transform.position.y > stats.GetTopFloor() * 2 - 5)
            {
                var holder = transform.position;
                holder.y = stats.GetTopFloor() * 2 - 5;
                transform.position = holder;
            }

            //if out of bounds below the tower
            if (transform.position.y < 0)
            {
                var holder = transform.position;
                holder.y = 0;
                transform.position = holder;
            }
        }
    }
}
