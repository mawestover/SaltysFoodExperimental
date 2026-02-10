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
    internal class MixingGuacItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Onions"),
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.OnionChopped)
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Tomatoes"),
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.TomatoChopped)
                }
                ,new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Jalapenos"),
                    Item = (Item)GDOUtils.GetCustomGameDataObject<IngredientLib.Ingredient.Items.ChoppedJalapeno>().GameDataObject
                }
            };
        }
    }
}

                    
                    