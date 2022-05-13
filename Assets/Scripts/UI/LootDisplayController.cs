using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootDisplayController : MonoBehaviour
{
    [SerializeField] Text lootedText;
    [SerializeField] Text bonusText;

    [SerializeField] int looted;
    [SerializeField] float bonus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
    public void SetBonus(int bns)
    {
        bonus = bns;
    }

    // Get the bonus amount each item gives
    public float GetBonus()
    {
        return bonus;
    }

    // Get the total bonus granted from the item
    public float GetTotalBonus()
    {
        return 1.0f + (bonus * looted);
    }

    //updates the text to 
    public void UpdateText()
    {
        lootedText.text = looted.ToString();
        bonusText.text = (100 * bonus * looted) + "%";
    }
}
