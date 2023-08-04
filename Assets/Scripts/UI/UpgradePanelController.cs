using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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

    public void UpdateText(BigInteger newCost)
    {
        costText.text = newCost.ToString("E3");
        levelText.text = stats.GetLevel().ToString();
        healthText.text = stats.GetHealth().ToString("E3");
        strengthText.text = stats.GetStrength().ToString("E3");
        speedText.text = stats.GetSpeed().ToString();

    }
}
