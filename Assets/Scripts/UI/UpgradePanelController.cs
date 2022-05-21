using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelController : MonoBehaviour
{
    [SerializeField] Text costText;
    [SerializeField] Text levelText;
    [SerializeField] Text healthText;
    [SerializeField] Text strengthText;
    [SerializeField] Text speedText;
    [SerializeField] StatStorrage stats;

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
        levelText.text = stats.GetLevel().ToString();
        healthText.text = stats.GetHealth().ToString();
        strengthText.text = stats.GetStrength().ToString();
        speedText.text = stats.GetSpeed().ToString();

    }
}
