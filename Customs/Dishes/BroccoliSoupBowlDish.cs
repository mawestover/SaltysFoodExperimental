using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using SaltyFood.Customs.ItemGroups;
using SaltyFood.Customs.Items;
using UnityEngine;

namespace SaltyFood.Customs.Dishes
{
    public class BroccoliSoupBowlDish : CustomDish
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "BroccoliSoupBowlDish";

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
        public override DishType Type => DishType.Base;

        // Difficulty - This is displayed in the lobby. (0 - 5)
        public override int Difficulty => 3;

        // StartingNameSet - The list of names used to decide the default Restaurant name.
        public override List<string> StartingNameSet => new List<string>
        {
            "The Simmering Spoon",
            "The Broth House",
            "Steep & Simmer",
            "Wholesome Bowl",
            "What the Pho?",
            "The Soup-er Bowl",
            "Stew-Pendousod"
        };

        // MinimumIngredients - The ingredients required to make this Dish.
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
        {
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Water),
            (Item)GDOUtils.GetCustomGameDataObject<BreadBowlMold>().GameDataObject,
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Flour),            
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Cheese),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.BroccoliRaw),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Onion),
#if DEBUG
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Pumpkin),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Meat),
#endif
        };

        // RequiredProcesses - The processes required to make this Dish.
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop)
        };

        // IconPrefab - This is the Icon displayed in the lobby.
        public override GameObject IconPrefab => Mod.Bundle.LoadAsset<GameObject>("BreadBowlIcon").AssignMaterialsByNames();

        // ResultingMenuItems - What menu Items are available to customers after unlocking this Dish.
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = (Item)GDOUtils.GetCustomGameDataObject<PlatedBroccoliCheeseSoupBowl>().GameDataObject,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };

        // IsAvailableAsLobbyOption - When TRUE this Dish will appear in the lobby.
        public override bool IsAvailableAsLobbyOption => true;

        // Recipe - This is the recipe displayed when unlocking this Dish.
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Knead flour to make dough. Place dough in bread mold and bake. Cut out bread crumbs and add a portion of broccoli cheese soup. Plate and serve." }
        };

        // InfoList - This is used to assign localisation to this Dish.
        public override List<(Locale, UnlockInfo)> InfoList => new List<(Locale, UnlockInfo)>
        {
            (Locale.English, new UnlockInfo
            {
                Name = "Broccoli Cheese Bowls",
                Description = "Adds broccoli cheese soup as mains (with bread bowls)",
                FlavourText = ""
            })
        };
    }
}