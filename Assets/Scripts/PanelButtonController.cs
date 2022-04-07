using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButtonController : MonoBehaviour
{
    [SerializeField] GameObject adventurerPanel;
    [SerializeField] GameObject mercenaryPanel;
    [SerializeField] GameObject lootPanel;
    [SerializeField] GameObject shopPanel;

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //On panel button click, checks to see if the coresponding panel is active, then disables all panels, that activates the needed panel if needed
    public void OnButtonClick()
    {
        GameObject holder; //to hold the coresponding panel so we know what was pressed

        //store the coresponding panel in memory
        switch (gameObject.tag)
        {
            case "adventurer":
                holder = adventurerPanel;
                break;
            case "mercenary":
                holder = mercenaryPanel;
                break;
            case "loot":
                holder = lootPanel;
                break;
            case "shop":
                holder = shopPanel;
                break;
            default:
                holder = null;
                break;
        }

        //store if the corresponding panel is active or not
        isActive = holder.activeSelf;

        //disable all panels
        adventurerPanel.SetActive(false);
        mercenaryPanel.SetActive(false);
        lootPanel.SetActive(false);
        shopPanel.SetActive(false);

        //activate the corresponding panel if needed
        if (!isActive)
        {
            holder.SetActive(true);
        }
    }
}
