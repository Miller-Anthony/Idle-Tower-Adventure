using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Text goldText;
    [SerializeField] Text topFloorText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGold(int newGold)
    {
        goldText.text = newGold.ToString();
    }

    public void UpdateTopFloor(int floor)
    {
        topFloorText.text = floor.ToString();
    }
}
