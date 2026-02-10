using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace SaltyFood.Customs.Items
{
    public class PottedCookedTaco : CustomItem
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "PottedCookedTaco";
        
        // Prefab - This is the GameObject used for this Item's visual. AssignMaterialsByNames() is a helper method that assigns materials to the GameObject based on the names of the materials.
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Potted CookedUnchoppedBeef").AssignMaterialsByNames();
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot);
        // SplitSubItem - What Item will this Item split into.

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 2,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
                Result = (Item)GDOUtils.GetCustomGameDataObject<PottedCookedChoppedTaco>().GameDataObject
            }
        };

        public override void OnRegister(Item gameDataObject)
        {
            base.OnRegister(gameDataObject);
            Prefab.ApplyMaterialToChild("Patty1/Steak_Cooked", "Meat Piece Cooked");
            Prefab.ApplyMaterialToChild("Patty2/Steak_Cooked", "Meat Piece Cooked");
            Prefab.ApplyMaterialToChild("Patty3/Steak_Cooked", "Meat Piece Cooked");
            Prefab.ApplyMaterialToChild("Patty4/Steak_Cooked", "Meat Piece Cooked");
        }
    }
}