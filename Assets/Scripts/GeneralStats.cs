using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStats : MonoBehaviour
{
    [SerializeField] int gold;

    // Start is called before the first frame update
    void Start()
    {
        gold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Add a given amount of gold
    public void AddGold(int value)
    {
        gold += value;
    }

    // Subtract a gien amount of gold
    public void SubtractGold(int value)
    {
        gold -= value;
    }

    public int CheckGold()
    {
        return gold;
    }
}
