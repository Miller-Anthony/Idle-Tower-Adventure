using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTracker : MonoBehaviour
{
    //odjects that can be added to the list
    [SerializeField] LootDisplayController swordController;
    [SerializeField] LootDisplayController longSwordController;
    [SerializeField] LootDisplayController spearController;
    [SerializeField] LootDisplayController daggerController;
    [SerializeField] LootDisplayController shieldController;
    [SerializeField] LootDisplayController helmetController;
    [SerializeField] LootDisplayController breastplateController;
    [SerializeField] LootDisplayController gauntletsController;
    [SerializeField] LootDisplayController magnifyingGlassController;
    [SerializeField] LootDisplayController tomeOfLuckController;
    [SerializeField] LootDisplayController gemPouchController;
    [SerializeField] LootDisplayController walletController;
    [SerializeField] LootDisplayController alchemyKitController;
    [SerializeField] LootDisplayController largeVialController;
    [SerializeField] LootDisplayController highQualityIngredientsController;
    [SerializeField] LootDisplayController ringOfWishesController;
    [SerializeField] LootDisplayController amuletOfTimeController;
    [SerializeField] LootDisplayController glovesOfMidasController;
    [SerializeField] LootDisplayController manaPotionController;
    [SerializeField] LootDisplayController magicFocusController;
    [SerializeField] LootDisplayController tomeOfIntelegenceController;
    [SerializeField] LootDisplayController summonersRobeController;
    [SerializeField] LootDisplayController summonersRingController;
    [SerializeField] LootDisplayController summonersStaffController;
    [SerializeField] LootDisplayController tomeOfCharismaController;
    [SerializeField] LootDisplayController loadedDiceController;
    [SerializeField] LootDisplayController tomeOfStrengthController;
    [SerializeField] LootDisplayController swiftBootsController;
    [SerializeField] LootDisplayController tomeOfDexterityController;
    [SerializeField] LootDisplayController poisonVialController;
    [SerializeField] LootDisplayController tomeOfEnduranceController;
    [SerializeField] LootDisplayController sharpeningStoneController;
    [SerializeField] LootDisplayController investmentsController;
    [SerializeField] LootDisplayController adventuringVoucherController;
    [SerializeField] LootDisplayController dungeonMapController;
    [SerializeField] LootDisplayController portalStoneController;
    [SerializeField] LootDisplayController pendantOfTheDawnController;

    //internal variables
    private List<LootDisplayController> lootList;
    private List<LootDisplayController> tempList;

    // Start is called before the first frame update
    void Start()
    {
        lootList = new List<LootDisplayController>();
        lootList.Add(swordController);
        lootList.Add(longSwordController);
        lootList.Add(spearController);
        lootList.Add(daggerController);
        lootList.Add(shieldController);
        lootList.Add(helmetController);
        lootList.Add(breastplateController);
        lootList.Add(gauntletsController);
        lootList.Add(magnifyingGlassController);
        lootList.Add(tomeOfLuckController);
        lootList.Add(gemPouchController);
        lootList.Add(walletController);
        lootList.Add(alchemyKitController);
        lootList.Add(largeVialController);
        lootList.Add(highQualityIngredientsController);
        lootList.Add(ringOfWishesController);
        lootList.Add(amuletOfTimeController);
        lootList.Add(glovesOfMidasController);
        lootList.Add(manaPotionController);
        lootList.Add(magicFocusController);
        lootList.Add(tomeOfIntelegenceController);
        lootList.Add(summonersRobeController);
        lootList.Add(summonersRingController);
        lootList.Add(summonersStaffController);
        lootList.Add(tomeOfCharismaController);
        lootList.Add(loadedDiceController);
        lootList.Add(tomeOfStrengthController);
        lootList.Add(swiftBootsController);
        lootList.Add(tomeOfDexterityController);
        lootList.Add(poisonVialController);
        lootList.Add(tomeOfEnduranceController);
        lootList.Add(sharpeningStoneController);
        lootList.Add(investmentsController);
        lootList.Add(adventuringVoucherController);
        lootList.Add(dungeonMapController);
        lootList.Add(portalStoneController);
        lootList.Add(pendantOfTheDawnController);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLoot(int floor)
    {
        //get data needed for calculations
        float weight = TotalWeight(floor);
        float num = Random.Range(0.0f, weight);
        List<LootDisplayController>.Enumerator numerator = tempList.GetEnumerator();


        while (numerator.MoveNext())
        {
            num -= (float)numerator.Current.GetWeight(floor);
            if(num <= 0)
            {
                numerator.Current.AddLoot();
                numerator.Current.UpdateText();
                return;
            }
        }
    }

    public LootDisplayController GetController(string loot)
    {
        LootDisplayController holder = null;
        switch(loot)
        {
            case "sword":
                holder = swordController;
                break;
            case "longSword":
                holder = longSwordController;
                break;
            case "spear":
                holder = spearController;
                break;
            case "dagger":
                holder = daggerController;
                break;
            case "shield":
                holder = shieldController;
                break;
            case "helmet":
                holder = helmetController;
                break;
            case "breastplate":
                holder = breastplateController;
                break;
            case "gauntlets":
                holder = gauntletsController;
                break;
            case "magnifyingGlass":
                holder = magnifyingGlassController;
                break;
            case "tomeOfLuck":
                holder = tomeOfLuckController;
                break;
            case "gemPouch":
                holder = gemPouchController;
                break;
            case "wallet":
                holder = walletController;
                break;
            case "alchemyKit":
                holder = alchemyKitController;
                break;
            case "largeVial":
                holder = largeVialController;
                break;
            case "highQualityIngredients":
                holder = highQualityIngredientsController;
                break;
            case "ringOfWishes":
                holder = ringOfWishesController;
                break;
            case "amuletOfTime":
                holder = amuletOfTimeController;
                break;
            case "glovesOfMidas":
                holder = glovesOfMidasController;
                break;
            case "manaPotion":
                holder = manaPotionController;
                break;
            case "magicFocus":
                holder = magicFocusController;
                break;
            case "tomeOfIntelegence":
                holder = tomeOfIntelegenceController;
                break;
            case "summonersRobe":
                holder = summonersRobeController;
                break;
            case "summonersRing":
                holder = summonersRingController;
                break;
            case "summonersStaff":
                holder = summonersStaffController;
                break;
            case "tomeOfCharisma":
                holder = tomeOfCharismaController;
                break;
            case "loadedDice":
                holder = loadedDiceController;
                break;
            case "tomeOfStrength":
                holder = tomeOfStrengthController;
                break;
            case "swiftBoots":
                holder = swiftBootsController;
                break;
            case "tomeOfDexterity":
                holder = tomeOfDexterityController;
                break;
            case "poisonVial":
                holder = poisonVialController;
                break;
            case "tomeOfEndurance":
                holder = tomeOfEnduranceController;
                break;
            case "sharpeningStone":
                holder = sharpeningStoneController;
                break;
            case "investments":
                holder = investmentsController;
                break;
            case "adventuringVoucher":
                holder = adventuringVoucherController;
                break;
            case "dungeonMap":
                holder = dungeonMapController;
                break;
            case "portalStone":
                holder = portalStoneController;
                break;
            case "pendantOfTheDawn":
                holder = pendantOfTheDawnController;
                break;
            default:
                break;
        }
        return holder;
    }

    private float TotalWeight(int floor)
    {
        List<LootDisplayController>.Enumerator numerator = lootList.GetEnumerator();
        float total = 0;

        while(numerator.MoveNext())
        {
            float holder = numerator.Current.GetWeight(floor);

            if (holder > 0)
            {
                tempList.Add(numerator.Current);
            }
            total += holder;
        }

        return total;
    }
}
