using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : MonoBehaviour
{
    [SerializeField] StatStorrage adventurerStats;
    [SerializeField] StatStorrage fighterStats;
    [SerializeField] StatStorrage barbarianStats;
    [SerializeField] StatStorrage enemyStats;
    [SerializeField] UpgradeButtonController adventurer;
    [SerializeField] UpgradeButtonController fighter;
    [SerializeField] UpgradeButtonController barbarian;
    [SerializeField] MiscUpgradeButtonController adventureCount;
    [SerializeField] MiscUpgradeButtonController clearFloor;
    [SerializeField] MiscUpgradeButtonController rebirth;
    [SerializeField] LootDisplayController sword;
    [SerializeField] LootDisplayController shield;
    [SerializeField] LootDisplayController wallet;

    // Start is called before the first frame update
    void Start()
    {
        adventurerStats.OnStart();
        fighterStats.OnStart();
        barbarianStats.OnStart();
        enemyStats.OnStart();
        adventurer.OnStart();
        fighter.OnStart();
        barbarian.OnStart();
        adventureCount.OnStart();
        clearFloor.OnStart();
        rebirth.OnStart();
        sword.OnStart();
        shield.OnStart();
        wallet.OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
