using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using SaltyFood.Customs.Items;
using SaltysFood.Customs.ItemGroups;
using UnityEngine;

namespace SaltyFood.Customs.ItemGroups
{
    internal class MixingGuac : CustomItemGroup<MixingGuacItemGroupView>
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "MixingGuacamole";
        
        // Prefab - This is the GameObject used for this Item's visual. AssignMaterialsByNames() is a helper method that assigns materials to the GameObject based on the names of the materials.
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("MixingGuacamole").AssignMaterialsByNames();
        

        // Sets - Sets are the Items which make up an ItemGroup.
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            // An ItemSets are collections of Items which are required to make this ItemGroup.
            new ItemGroup.ItemSet
            {
                // Items - The Items required to make complete this ItemSet.
                Items = new List<Item>
                {
                    // GDOUtils.GetExistingGDO(ItemReferences.Plate) - This is a helper method that gets a reference to a vanilla Item.
                     (Item)GDOUtils.GetCustomGameDataObject<IngredientLib.Ingredient.Items.MashedAvocado>().GameDataObject,
                },
                // Min - The minimum number of Items required to complete this ItemSet.
                // Max - The maximum number of Items required to complete this ItemSet.
                Min = 1,
                Max = 1,
                
                // IsMandatory - When TRUE this ItemSet is required to complete the ItemGroup.
                IsMandatory = true
            },
            new ItemGroup.ItemSet
            {
                Items = new List<Item>
                {
                    // GDOUtils.GetExistingGDO(ItemReferences.Lobster) - This is a helper method that gets a reference to a modded Item.
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.OnionChopped),
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.TomatoChopped),
                    (Item)GDOUtils.GetCustomGameDataObject<IngredientLib.Ingredient.Items.ChoppedJalapeno>().GameDataObject
                },
                Min = 3,
                Max = 3
            }
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
                Duration = 3,
                Result = (Item)GDOUtils.GetCustomGameDataObject<MixedGuacamole>().GameDataObject
            }
        };

        // SplitDepletedItems - What Items this Item will leave behind after being completely split.

        public override void OnRegister(ItemGroup gameDataObject)
        {
            base.OnRegister(gameDataObject);
            Prefab.GetComponent<MixingGuacItemGroupView>()?.Setup(Prefab);
            Prefab.ApplyMaterialToChild("Guacamole", "Avocado Inside");
            Prefab.ApplyMaterialToChildren("jalapeno", "Jalapeno");
        }
    }
}