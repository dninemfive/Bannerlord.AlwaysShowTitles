﻿using HarmonyLib;
using SandBox.CampaignBehaviors;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.Conversation;

namespace Bannerlord.AlwaysShowTitles.Patches
{
    [HarmonyPatch]
    internal class ConversationPatches
    {
        [HarmonyPatch(typeof(MissionConversationVM))]
        [HarmonyPatch(nameof(MissionConversationVM.Refresh))]
        class Patch01
        {
            internal static void Prefix()
            {
                HeroPatches.NamePatchExcludedHero = Campaign.Current.ConversationManager.OneToOneConversationHero;
            }

            internal static void Postfix()
            {
                HeroPatches.NamePatchExcludedHero = null;
            }
        }

        [HarmonyPatch(typeof(LordConversationsCampaignBehavior))]
        [HarmonyPatch(nameof(LordConversationsCampaignBehavior.conversation_player_want_to_join_faction_as_mercenary_or_vassal_on_condition))]
        class Patch02
        {
            internal static void Prefix()
            {
                HeroPatches.EnableNamePatch = false;
            }

            internal static void Postfix()
            {
                HeroPatches.EnableNamePatch = true;
            }
        }
    }
}
