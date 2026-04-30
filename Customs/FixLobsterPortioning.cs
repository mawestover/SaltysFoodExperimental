//this code was made by Copilot to fix the lobster portioning issue. This has not been tested.

using Kitchen;
using KitchenData;
using KitchenLib.Utils;
using SaltyFood.Customs.Items;
using Unity.Collections;
using Unity.Entities;

namespace SaltyFood.Customs.Systems
{
    // This system runs after cooking finishes and clears stale hob state
    public class FixLobsterPortioning : GameSystemBase
    {
        private EntityQuery HobQuery;

        protected override void Initialise()
        {
            // Hobs have: CAppliance + CTakesDuration + CItemHolder
            HobQuery = GetEntityQuery(
                ComponentType.ReadOnly<CAppliance>(),
                ComponentType.ReadOnly<CTakesDuration>(),
                ComponentType.ReadWrite<CItemHolder>()
            );
        }

        protected override void OnUpdate()
        {
            using NativeArray<Entity> hobs = HobQuery.ToEntityArray(Allocator.Temp);

            foreach (Entity hob in hobs)
            {
                // Check if hob finished cooking this frame
                if (!Require(hob, out CTakesDuration takes) || takes.Remaining > 0f)
                    continue;

                // Hob must be holding something
                if (!Require(hob, out CItemHolder holder) || holder.HeldItem == default)
                    continue;

                // Check if the held item is cooked lobster or cooked potted lobster
                if (!Require(holder.HeldItem, out CItem item))
                    continue;

                int cookedLobsterID = GDOUtils.GetCustomGameDataObject<CookedLobster>().ID;
                int cookedPottedLobsterID = GDOUtils.GetCustomGameDataObject<CookedPottedLobster>().ID;

                if (item.ID != cookedLobsterID && item.ID != cookedPottedLobsterID)
                    continue;

                // --- FIX: Clear stale hob ownership so portioners don't snap pieces back onto the hob ---

                // Remove the held item reference
                holder.HeldItem = default;
                Set(hob, holder);

                // Remove stale group/interaction components
                Remove<CGroupItem>(hob);
                Remove<CLastInteractionData>(hob);
                Remove<CPreventPickup>(hob);
            }
        }
    }
}
