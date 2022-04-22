using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscUpgradeButtonController : MonoBehaviour
{
    [SerializeField] GeneralStats genStats;
    [SerializeField] int cost;
    [SerializeField] MiscUpgradeController panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeAdventurerCount()
    {
        genStats.SetMaxAdventurers(genStats.GetMaxAdventurers() + 1);
    }

    public void OnButtonPress()
    {
        if (genStats.CheckGold() >= cost)
        {
            //subtract the amount of money used to but the upgrade and increase the cost of the next one
            genStats.SubtractGold(cost);
            cost = (int)(cost * 10.0f);

            switch (tag)
            {
                case "adventurerCount":
                    UpgradeAdventurerCount();
                    break;
                default:
                    break;
            }

            //update the Adventurer UI text
            panel.UpdateText((int)cost);
        }
    }
}
