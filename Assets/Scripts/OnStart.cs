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
    [SerializeField] LootTracker loot;

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
        loot.GetController("sword").OnStart();
        loot.GetController("longSword").OnStart();
        loot.GetController("spear").OnStart();
        loot.GetController("dagger").OnStart();
        loot.GetController("shield").OnStart();
        loot.GetController("helmet").OnStart();
        loot.GetController("breastplate").OnStart();
        loot.GetController("gauntlets").OnStart();
        loot.GetController("magnifyingGlass").OnStart();
        loot.GetController("tomeOfLuck").OnStart();
        loot.GetController("gemPouch").OnStart();
        loot.GetController("wallet").OnStart();
        loot.GetController("alchemyKit").OnStart();
        loot.GetController("largeVial").OnStart();
        loot.GetController("highQualityIngredients").OnStart();
        loot.GetController("ringOfWishes").OnStart();
        loot.GetController("amuletOfTime").OnStart();
        loot.GetController("glovesOfMidas").OnStart();
        loot.GetController("manaPotion").OnStart();
        loot.GetController("magicFocus").OnStart();
        loot.GetController("tomeOfIntelegence").OnStart();
        loot.GetController("summonersRobe").OnStart();
        loot.GetController("summonersRing").OnStart();
        loot.GetController("summonersStaff").OnStart();
        loot.GetController("tomeOfCharisma").OnStart();
        loot.GetController("loadedDice").OnStart();
        loot.GetController("tomeOfStrength").OnStart();
        loot.GetController("swiftBoots").OnStart();
        loot.GetController("tomeOfDexterity").OnStart();
        loot.GetController("poisonVial").OnStart();
        loot.GetController("tomeOfEndurance").OnStart();
        loot.GetController("sharpeningStone").OnStart();
        loot.GetController("investments").OnStart();
        loot.GetController("adventuringVoucher").OnStart();
        loot.GetController("dungeonMap").OnStart();
        loot.GetController("portalStone").OnStart();
        loot.GetController("pendantOfTheDawn").OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
