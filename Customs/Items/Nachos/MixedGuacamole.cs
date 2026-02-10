using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace SaltyFood.Customs.Items
{
    public class MixedGuacamole : CustomItem
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "MixedGuacamole";

        // Prefab - This is the GameObject used for this Item's visual. AssignMaterialsByNames() is a helper method that assigns materials to the GameObject based on the names of the materials.
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("MixingGuacamole").AssignMaterialsByNames();

        // SplitSubItem - What Item will this Item split into.
        public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<Guacamole>().GameDataObject;

        // SplitCount - How many times this Item can be split.
        public override int SplitCount => 6;

        // SplitDepletedItems - What Items this Item will leave behind after being completely split.


    }
}