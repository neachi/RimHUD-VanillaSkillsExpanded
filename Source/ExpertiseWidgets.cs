using System;
using RimHUD.Extensions;
using RimHUD.Interface.Screen;
using RimWorld;
using UnityEngine;
using Verse;
using VSE;
using VSE.Expertise;

namespace RimHUD_VSE
{
    public static class ExpertiseWidgetHelper
    {
        public static (string label, string value, float fill, float[] thresholds, Func<string> tooltip, Action onHover, Action onClick) GetBarParameters(Pawn pawn, int slotIndex)
        {
            var record = GetRecord(pawn, slotIndex);
            if (record == null)
            {
                return (null, null, 0f, null, null, null, null);
            }

            string label = record.def.LabelCap;
            string value = record.Level == 20 ? "20" : record.Level.ToString();
            float fill = record.Level == 20 ? 1f : record.XpProgressPercent;

            return (label, value, fill, null, () => record.FullDescription(), null, null);
        }

        public static (string label, string value, Func<string> tooltip, Action onHover, Action onClick) GetValueParameters(Pawn pawn, int slotIndex)
        {
            var record = GetRecord(pawn, slotIndex);
            if (record == null)
            {
                return (null, null, null, null, null);
            }

            string label = record.def.LabelCap;
            int remainder = Math.Max(0, Math.Min(99, record.XpProgressPercent.ToPercentageInt()));
            string value = record.Level.ToDecimalString(remainder);

            return (label, value, () => record.FullDescription(), null, InspectPaneTabs.ToggleBio);
        }

        private static ExpertiseRecord GetRecord(Pawn pawn, int slotIndex)
        {
            if (pawn?.skills == null) return null;

            var tracker = pawn.Expertise();
            if (tracker == null || tracker.AllExpertise == null || slotIndex < 0 || slotIndex >= tracker.AllExpertise.Count)
            {
                return null;
            }

            return tracker.AllExpertise[slotIndex];
        }
    }

    // Bar Slots 1-5
    public static class ExpertiseBarSlot1
    {
        public static (string label, string value, float fill, float[] thresholds, Func<string> tooltip, Action onHover, Action onClick) GetParameters(Pawn pawn)
            => ExpertiseWidgetHelper.GetBarParameters(pawn, 0);
    }

    public static class ExpertiseBarSlot2
    {
        public static (string label, string value, float fill, float[] thresholds, Func<string> tooltip, Action onHover, Action onClick) GetParameters(Pawn pawn)
            => ExpertiseWidgetHelper.GetBarParameters(pawn, 1);
    }

    public static class ExpertiseBarSlot3
    {
        public static (string label, string value, float fill, float[] thresholds, Func<string> tooltip, Action onHover, Action onClick) GetParameters(Pawn pawn)
            => ExpertiseWidgetHelper.GetBarParameters(pawn, 2);
    }

    public static class ExpertiseBarSlot4
    {
        public static (string label, string value, float fill, float[] thresholds, Func<string> tooltip, Action onHover, Action onClick) GetParameters(Pawn pawn)
            => ExpertiseWidgetHelper.GetBarParameters(pawn, 3);
    }

    public static class ExpertiseBarSlot5
    {
        public static (string label, string value, float fill, float[] thresholds, Func<string> tooltip, Action onHover, Action onClick) GetParameters(Pawn pawn)
            => ExpertiseWidgetHelper.GetBarParameters(pawn, 4);
    }

    // Value Slots 1-5
    public static class ExpertiseValueSlot1
    {
        public static (string label, string value, Func<string> tooltip, Action onHover, Action onClick) GetParameters(Pawn pawn)
            => ExpertiseWidgetHelper.GetValueParameters(pawn, 0);
    }

    public static class ExpertiseValueSlot2
    {
        public static (string label, string value, Func<string> tooltip, Action onHover, Action onClick) GetParameters(Pawn pawn)
            => ExpertiseWidgetHelper.GetValueParameters(pawn, 1);
    }

    public static class ExpertiseValueSlot3
    {
        public static (string label, string value, Func<string> tooltip, Action onHover, Action onClick) GetParameters(Pawn pawn)
            => ExpertiseWidgetHelper.GetValueParameters(pawn, 2);
    }

    public static class ExpertiseValueSlot4
    {
        public static (string label, string value, Func<string> tooltip, Action onHover, Action onClick) GetParameters(Pawn pawn)
            => ExpertiseWidgetHelper.GetValueParameters(pawn, 3);
    }

    public static class ExpertiseValueSlot5
    {
        public static (string label, string value, Func<string> tooltip, Action onHover, Action onClick) GetParameters(Pawn pawn)
            => ExpertiseWidgetHelper.GetValueParameters(pawn, 4);
    }
}