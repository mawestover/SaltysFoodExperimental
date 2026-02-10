using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace SaltyFood.Customs.Items
{
    public class BurntPottedLobster : CustomItem
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "BurntPottedLobster";
        
        // Prefab - This is the GameObject used for this Item's visual. AssignMaterialsByNames() is a helper method that assigns materials to the GameObject based on the names of the materials.
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Burned Lobster").AssignMaterialsByNames();

        // DisposesTo - What this Item turns into when interacted with a bin.
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot);


        public override void OnRegister(Item gameDataObject)
        {
            base.OnRegister(gameDataObject);
            Prefab.ApplyMaterialToChild("Cooked Lobster/lobster", "Burned - Light");
        }
    }
}