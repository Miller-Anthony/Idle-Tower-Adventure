using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class MiscUpgradeController : MonoBehaviour
{
    [SerializeField] Text costText;
    [SerializeField] Text countText;
    [SerializeField] GeneralStats stats;
    [SerializeField] FloorTracker floors;
    [SerializeField] MercenaryManager mManager;
    [SerializeField] PowerManager pManager;
    [SerializeField] StatStorrage adventurerStats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(BigInteger newCost)
    {
        costText.text = newCost.ToString("E3");

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
            float holder = mManager.GetSpawnPercent();
            holder -= 1.0f;
            holder *= 100;
            holder = Mathf.Round(holder);
            countText.text = holder.ToString() + "%";
        }
        else if (tag == "improveGear")
        {
            float holder = mManager.GetGearPercent();
            holder -= 1;
            holder *= 100;
            holder = Mathf.Round(holder);
            countText.text = holder.ToString() + "%";
        }
        else if(tag == "strengthInNumbers")
        {
            float holder = adventurerStats.GetStrengthPercent();
            holder *= 100;
            countText.text = holder.ToString() + "%";
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
