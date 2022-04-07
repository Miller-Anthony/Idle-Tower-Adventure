using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButtonController : MonoBehaviour
{
    [SerializeField] GeneralStats stats;
    [SerializeField] float cost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress()
    {
        if(stats.CheckGold() >= cost)
        {
            //subtract the amount of money used to but the upgrade and increase the cost of the next one
            stats.SubtractGold((int)cost);
            cost *= 1.1f;

            //get the int stats of the adventurer to modefy
            int dmg = stats.GetAdventurerDamage();
            int hp = stats.GetAdventurerHealth();

            //calculate and set the damage stat increase
            if (Mathf.FloorToInt((float)dmg * 1.1f) < dmg + 1)
            {
                dmg++;
                stats.SetAdventurerDamage(dmg);
            }
            else
            {
                stats.SetAdventurerDamage(Mathf.FloorToInt((float)dmg * 1.1f));
            }

            //calculate and set the health stat increase
            if(Mathf.FloorToInt((float)hp * 1.1f) < hp + 1)
            {
                hp++;
                stats.SetAdventurerHealth(hp);
            }
            else
            {
                stats.SetAdventurerHealth(Mathf.FloorToInt((float)hp * 1.1f));
            }

            //set the new speed stat (needs to be updated later to not increase every level)
            stats.SetAdventurerSpeed(stats.GetAdventurerSpeed() * 1.1f);
            
        }
    }
}
