using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using SaltyFood.Customs.Appliances;
using System.Collections.Generic;
using UnityEngine;

namespace SaltyFood.Customs.Items
{
    public class BreadBowlRoll : CustomItem
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "BreadBowlRoll";
        
        // Prefab - This is the GameObject used for this Item's visual. AssignMaterialsByNames() is a helper method that assigns materials to the GameObject based on the names of the materials.
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Bread Bowl Roll").AssignMaterialsByNames();

        public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<SaltysSideCroutons>().GameDataObject;

        // SplitCount - How many times this Item can be split.
        public override int SplitCount => 1;

        public override List<Item> SplitDepletedItems => new() { (Item)GDOUtils.GetCustomGameDataObject<SaltysBreadBowl>().GameDataObject };
    }
}