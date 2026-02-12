using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using SaltyFood.Customs.Items;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace SaltysFood.Customs.ItemGroups.BreadBowls
{
    internal class BreadBowlMoldView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "dough"),
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.Dough)
                }
            };
        }
    }
}
