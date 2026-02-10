using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Interfaces;
using KitchenLib.References;
using KitchenLib.Utils;
using SaltyFood.Customs.Appliances;
using SaltyFood.Customs.ItemGroups;
using SaltyFood.Customs.Items;
using UnityEngine;

namespace SaltyFood.Customs.Dishes
{
    public class NachosNGuacDish : CustomDish
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "NachosNGuacDish";

        // ExpReward - Determines how much XP this Unlock provides.
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        // IsUnlockable - When TRUE this Unlock can appear in the card selector.
        public override bool IsUnlockable => true;

        // UnlockGroup - Determines what type of Unlock this is.
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;

        // CardType - Determines when this Unlock can be selected.
        public override CardType CardType => CardType.Default;

        // CustomerMultiplier - Determines the customer difference this Unlock provides.
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;

        // Type - This is used to decide what phase this Dish should be ordered.
        public override DishType Type => DishType.Extra;

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Tortilla),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Oil),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Tomato),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Onion),
            (Item)GDOUtils.GetCustomGameDataObject<IngredientLib.Ingredient.Items.Avocado>().GameDataObject,
            (Item)GDOUtils.GetCustomGameDataObject<IngredientLib.Ingredient.Items.Jalapeno>().GameDataObject
        };
#if DEBUG
        public override bool IsAvailableAsLobbyOption => true;
#endif
        // Difficulty - This is displayed in the lobby. (0 - 5)
        public override int Difficulty => 3;

        public override List<Unlock> HardcodedRequirements { get => new List<Unlock>() { (Dish)GDOUtils.GetCustomGameDataObject<NachosDish>().GameDataObject }; }


        // RequiredProcesses - The processes required to make this Dish.
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop)
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = (Item)GDOUtils.GetCustomGameDataObject<PlatedNachosNGuac>().GameDataObject,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };

        // Recipe - This is the recipe displayed when unlocking this Dish.
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Chop then mash avacado. Add chopped onion, chopped tomato, and chopped jalapeno. Mix. Makes 6 portions" }
        };

        // InfoList - This is used to assign localisation to this Dish.
        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>
        {
            (Locale.English, new UnlockInfo
            {
                Name = "Nachos and Guacamole",
                Description = "Adds Guacamole to Nachos",
                FlavourText = "Nothing goes better on top!"
            })
        };

    }
}