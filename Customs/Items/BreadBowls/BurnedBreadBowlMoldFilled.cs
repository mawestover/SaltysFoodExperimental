using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using SaltyFood.Customs.Appliances;
using System.Collections.Generic;
using UnityEngine;

namespace SaltyFood.Customs.Items
{
    public class BurnedBreadBowlMoldFilled : CustomItem
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "BurnedBreadBowlMoldFilled";
        
        // Prefab - This is the GameObject used for this Item's visual. AssignMaterialsByNames() is a helper method that assigns materials to the GameObject based on the names of the materials.
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Bread Bowl Burned").AssignMaterialsByNames();

        public override Item DisposesTo => (Item)GDOUtils.GetCustomGameDataObject<BreadBowlMold>().GameDataObject;

    }
}