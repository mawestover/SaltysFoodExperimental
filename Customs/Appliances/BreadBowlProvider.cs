using System.Collections.Generic;
using ApplianceLib.Api.Prefab;
using ApplianceLib.Api.References;
using Kitchen;
using Kitchen.Components;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using SaltyFood.Customs.Items;
using UnityEngine;

namespace SaltyFood.Customs.Appliances
{
    public class BreadBowlProvider : CustomAppliance
    {
        // UniqueNameID - This is used internally to generate the ID of this GDO. Once you've set it, don't change it.
        public override string UniqueNameID => "BreadBowlProvider";
        
        // Prefab - This is the GameObject used for this Appliance's visual. AssignMaterialsByNames() is a helper method that assigns materials to the GameObject based on the names of the materials.
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Bowls Provider").AssignMaterialsByNames();
        
        // Properties - The Properties attached to the Appliance.
        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            KitchenPropertiesUtils.GetLimitedCItemProvider(GDOUtils.GetCustomGameDataObject<BreadBowlMold>().ID,3,3)
        };

        // PriceTier - This determines the default price of the Appliance in the shop.
        public override PriceTier PriceTier => PriceTier.Medium;
        
        // RarityTier - This determines the color of the Blueprint outline.
        public override RarityTier RarityTier => RarityTier.Uncommon;
        
        // IsPurchasable - When TRUE this Appliance can appear in the shop.
        public override bool IsPurchasable => true;
        
        // SellOnlyAsDuplicate - When TRUE this Appliance will only appear in the shop if already owned. 
        public override bool SellOnlyAsDuplicate => true;

        // InfoList - This is used to assign localisation to this Appliance.
        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (Locale.English, new ApplianceInfo
            {
                Name = "Bread Bowl Molds",
                Description = "Provides Bread Bowl Molds"
            })
        };

        // OnRegister - This is called when a GameDataObject is registered.
        public override void OnRegister(Appliance gameDataObject)
        {
            base.OnRegister(gameDataObject);            
        }

        public override void SetupPrefab(GameObject prefab)
        {
            var sourceView = prefab.AddComponent<LimitedItemSourceView>();
            ReflectionUtils.GetField<LimitedItemSourceView>("Items").SetValue(sourceView, new List<GameObject>()
            {
                GameObjectUtils.GetChildObject(prefab, "bowl1"),
                GameObjectUtils.GetChildObject(prefab, "bowl2"),
                GameObjectUtils.GetChildObject(prefab, "bowl3")
            });
        }
    }
}