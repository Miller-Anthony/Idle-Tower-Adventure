using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : MonoBehaviour
{
    [SerializeField] StatStorrage adventurerStats;
    [SerializeField] StatStorrage fighterStats;
    [SerializeField] StatStorrage barbarianStats;
    [SerializeField] StatStorrage rogueStats;
    [SerializeField] StatStorrage rangerStats;
    [SerializeField] StatStorrage monkStats;
    [SerializeField] StatStorrage clericStats;
    [SerializeField] StatStorrage bardStats;
    [SerializeField] StatStorrage wizzardStats;
    [SerializeField] StatStorrage warlockStats;
    [SerializeField] StatStorrage sorcererStats;
    [SerializeField] StatStorrage paladinStats;
    [SerializeField] StatStorrage druidStats;
    [SerializeField] StatStorrage enemyStats;
    [SerializeField] UpgradeButtonController adventurer;
    [SerializeField] UpgradeButtonController fighter;
    [SerializeField] UpgradeButtonController barbarian;
    [SerializeField] UpgradeButtonController rogue;
    [SerializeField] UpgradeButtonController ranger;
    [SerializeField] UpgradeButtonController monk;
    [SerializeField] UpgradeButtonController cleric;
    [SerializeField] UpgradeButtonController bard;
    [SerializeField] UpgradeButtonController wizzard;
    [SerializeField] UpgradeButtonController warlock;
    [SerializeField] UpgradeButtonController sorcerer;
    [SerializeField] UpgradeButtonController paladin;
    [SerializeField] UpgradeButtonController druid;
    [SerializeField] MiscUpgradeButtonController adventureCount;
    [SerializeField] MiscUpgradeButtonController clearFloor;
    [SerializeField] MiscUpgradeButtonController clearFloorAuto;
    [SerializeField] MiscUpgradeButtonController skilledAdventurer;
    [SerializeField] MiscUpgradeButtonController hireRate;
    [SerializeField] MiscUpgradeButtonController improvedGear;
    [SerializeField] MiscUpgradeButtonController strengthInNumbers;
    [SerializeField] MiscUpgradeButtonController hastePotion;
    [SerializeField] MiscUpgradeButtonController increasedBounty;
    [SerializeField] MiscUpgradeButtonController teleport;
    [SerializeField] MiscUpgradeButtonController autoSpawner;
    [SerializeField] MiscUpgradeButtonController rebirth;
    [SerializeField] LootDisplayController sword;
    [SerializeField] LootDisplayController longSword;
    [SerializeField] LootDisplayController shield;
    [SerializeField] LootDisplayController helmet;
    [SerializeField] LootDisplayController magnifyingGlass;
    [SerializeField] LootDisplayController wallet;

    // Start is called before the first frame update
    void Start()
    {
        adventurerStats.OnStart();
        fighterStats.OnStart();
        barbarianStats.OnStart();
        rogueStats.OnStart();
        rangerStats.OnStart();
        monkStats.OnStart();
        clericStats.OnStart();
        bardStats.OnStart();
        wizzardStats.OnStart();
        warlockStats.OnStart();
        sorcererStats.OnStart();
        paladinStats.OnStart();
        druidStats.OnStart();
        enemyStats.OnStart();
        adventurer.OnStart();
        fighter.OnStart();
        barbarian.OnStart();
        rogue.OnStart();
        ranger.OnStart();
        monk.OnStart();
        cleric.OnStart();
        bard.OnStart();
        wizzard.OnStart();
        warlock.OnStart();
        sorcerer.OnStart();
        paladin.OnStart();
        druid.OnStart();
        adventureCount.OnStart();
        clearFloor.OnStart();
        clearFloorAuto.OnStart();
        skilledAdventurer.OnStart();
        hireRate.OnStart();
        improvedGear.OnStart();
        strengthInNumbers.OnStart();
        hastePotion.OnStart();
        increasedBounty.OnStart();
        teleport.OnStart();
        autoSpawner.OnStart();
        rebirth.OnStart();
        sword.OnStart();
        longSword.OnStart();
        shield.OnStart();
        helmet.OnStart();
        magnifyingGlass.OnStart();
        wallet.OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
