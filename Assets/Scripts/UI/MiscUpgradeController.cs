using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiscUpgradeController : MonoBehaviour
{
    [SerializeField] Text costText;
    [SerializeField] Text countText;
    [SerializeField] GeneralStats stats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(int newCost)
    {
        costText.text = newCost.ToString();
        countText.text = stats.GetMaxAdventurers().ToString();


    }
}
