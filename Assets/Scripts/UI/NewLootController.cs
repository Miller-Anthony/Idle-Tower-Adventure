using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewLootController : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text looted;
    [SerializeField] Text bonus;
    [SerializeField] Text description;
    [SerializeField] Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loot(LootDisplayController loot)
    {
        title.text = loot.GetTitle();
        looted.text = loot.GetLooted().ToString();
        bonus.text = loot.GetTotalBonus() + "%";
        description.text = loot.GetDescription();
        image.sprite = loot.GetImage().sprite;
    }
}
