using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using SaltyFood.Customs.Appliances;
using UnityEngine;

namespace SaltyFood.Customs.Items
{
    public class SaltysSideCroutons : CustomItem
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "SaltysSideCroutons";

        // Prefab - This is the GameObject used for this Item's visual. AssignMaterialsByNames() is a helper method that assigns materials to the GameObject based on the names of the materials.
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Saltys Croutons").AssignMaterialsByNames(); //((Item)GDOUtils.GetExistingGDO(ItemReferences.Breadcrumbs)).Prefab;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideMedium;
        public override bool IsMergeableSide => true;

        public override void OnRegister(Item gameDataObject)
        {
            base.OnRegister(gameDataObject);
            var breadcrumbs = Prefab.transform.Find("Breadcrumbs");
            GameObject newCrumb = Object.Instantiate(((Item)GDOUtils.GetExistingGDO(ItemReferences.Breadcrumbs)).Prefab);
            //var oldcrumbs = ((Item)GDOUtils.GetExistingGDO(ItemReferences.Breadcrumbs)).Prefab;
            //oldcrumbs.transform.SetParent(breadcrumbs, false);
            newCrumb.transform.SetParent(breadcrumbs, false);
        }
    }
}