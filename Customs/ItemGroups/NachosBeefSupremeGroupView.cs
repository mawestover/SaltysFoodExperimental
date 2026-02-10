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

namespace SaltysFood.Customs.ItemGroups
{
    internal class NachosBeefSupremeGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cheese Sauce"),
                    Item = (Item)GDOUtils.GetCustomGameDataObject<CheeseSauce>().GameDataObject
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Guacamole"),
                    Item = (Item)GDOUtils.GetCustomGameDataObject<Guacamole>().GameDataObject
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Sour Cream"),
                    Item = (Item)GDOUtils.GetCustomGameDataObject<IngredientLib.Ingredient.Items.WhippedCream>().GameDataObject
                }
            };
        }
    }
}
