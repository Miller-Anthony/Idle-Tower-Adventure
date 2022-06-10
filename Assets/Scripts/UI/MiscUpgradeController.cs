using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiscUpgradeController : MonoBehaviour
{
    [SerializeField] Text costText;
    [SerializeField] Text countText;
    [SerializeField] GeneralStats stats;
    [SerializeField] FloorTracker floors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(BigNumber newCost)
    {
        costText.text = newCost.ToString();

        if (tag == "adventurerCount")
        {
            countText.text = stats.GetMaxAdventurers().ToString();
        }
        else if (tag == "clearFloor")
        {
            countText.text = (stats.GetBottomFloor() - 1).ToString();
        }
        else if(tag == "clearFloorAuto")
        {
            countText.text = floors.GetMinQueueSize().ToString() + " - " + floors.GetMaxQueueSize().ToString();
        }
        else if (tag == "skilledAdventurer")
        {
            countText.text = (stats.GetSkilledChance() * 100).ToString() + "%";
        }
        else if(tag == "hireRate")
        {
            countText.text = stats.GetMaxAdventurers().ToString();
        }
        else if (tag == "improveGear")
        {
            countText.text = (stats.GetBottomFloor() - 1).ToString();
        }
        else if(tag == "adventustrengthInNumbersrerCount")
        {
            countText.text = stats.GetMaxAdventurers().ToString();
        }
        else if (tag == "hastePotion")
        {
            countText.text = (stats.GetBottomFloor() - 1).ToString();
        }
        else if(tag == "increasedBounty")
        {
            countText.text = stats.GetMaxAdventurers().ToString();
        }
        else if (tag == "teleport")
        {
            countText.text = (stats.GetBottomFloor() - 1).ToString();
        }
        else if (tag == "autoSpawner")
        {
            countText.text = (stats.GetBottomFloor() - 1).ToString();
        }

    }
}
