using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootDisplayController : MonoBehaviour
{
    [SerializeField] Text lootedText;
    [SerializeField] Text bonusText;

    [SerializeField] int looted;
    [SerializeField] BigNumber bonus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStart()
    {
        switch (tag)
        {
            case "sword":
                bonus = new BigNumber(30);
                break;
            case "shield":
                bonus = new BigNumber(30);
                break;
            case "wallet":
                bonus = new BigNumber(15);
                break;
            default:
                break;
        }
    }

    //Set the amount looted
    public void Setlooted(int amount)
    {
        looted = amount;
        UpdateText();
    }

    // Get the amount looted
    public int GetLooted()
    {
        return looted;
    }

    public void AddLoot()
    {
        looted++;
    }

    //Set the bonus amount each item gives
    public void SetBonus(BigNumber bns)
    {
        bonus = bns;
    }

    // Get the bonus amount each item gives
    public BigNumber GetBonus()
    {
        return bonus;
    }

    // Get the total bonus granted from the item
    public BigNumber GetTotalBonus()
    {
        return bonus * looted;
    }

    //updates the text to 
    public void UpdateText()
    {
        lootedText.text = looted.ToString();
        bonusText.text = (bonus * looted) + "%";
    }
}
