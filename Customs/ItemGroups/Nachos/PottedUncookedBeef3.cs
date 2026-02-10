using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Interfaces;
using KitchenLib.References;
using KitchenLib.Utils;
using SaltyFood.Customs.Items;
using SaltysFood.Customs.ItemGroups;
using UnityEngine;

namespace SaltyFood.Customs.ItemGroups
{
    public class PottedUncookedBeef3 : CustomItemGroup<ItemGroupView>
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "PottedUncookedBeef3";

        // Prefab - This is the GameObject used for this Item's visual. AssignMaterialsByNames() is a helper method that assigns materials to the GameObject based on the names of the materials.
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Potted UncookedBeef3").AssignMaterialsByNames();
        
        // DisposesTo - What this Item turns into when interacted with a bin.
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot);
        
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
                    (Item)GDOUtils.GetCustomGameDataObject<PottedUncookedBeef2>().GameDataObject
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
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.BurgerPattyRaw)
                },
                Min = 1,
                Max = 1
            }
        };
        
        // Processes - These are the Processes which can be applied to this Item.

        public override void OnRegister(ItemGroup gameDataObject)
        {
            base.OnRegister(gameDataObject);            
            Prefab.ApplyMaterialToChild("Patty1/Steak_Cooked", "Raw Burger");
            Prefab.ApplyMaterialToChild("Patty2/Steak_Cooked", "Raw Burger");
            Prefab.ApplyMaterialToChild("Patty3/Steak_Cooked", "Raw Burger");
        }
    }
}