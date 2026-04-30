//this code was made by Copilot to fix the lobster portioning issue. This has not been tested.
using Kitchen;
using KitchenData;
using KitchenLib.Utils;
using Unity.Collections;
using Unity.Entities;

namespace SaltyFood.Customs.Systems
{
    // Fixes the "portion stuck on hob" bug for ALL multi-portion foods
    public class FixMultiPortionHobState : GameSystemBase
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
                // Hob must have just finished cooking
                if (!Require(hob, out CTakesDuration takes) || takes.Remaining > 0f)
                    continue;

                // Hob must be holding something
                if (!Require(hob, out CItemHolder holder) || holder.HeldItem == default)
                    continue;

                // The held item must be a valid item
                if (!Require(holder.HeldItem, out CItem item))
                    continue;

                // Detect ANY multi-portion item:
                // SplitCount > 0 AND SplitSubItem != null
                if (item.SplitCount <= 0 || item.SplitSubItem == null)
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
