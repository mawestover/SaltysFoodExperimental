using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using SaltyFood.Customs.ItemGroups;
using SaltyFood.Customs.Items;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace SaltysFood.Customs.ItemGroups.BreadBowls
{
    internal class PlatedBreadBowlCheeseView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Plate"),
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate)
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Broccoli Cheese Bowl"),
                    Item = (Item)GDOUtils.GetCustomGameDataObject<BroccoliCheeseSoupBowl>().GameDataObject                    
                }
            };
            
        }
    }
}
