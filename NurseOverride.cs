using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NoNurseDuringBosses
{
	public class NurseOverride : GlobalNPC
	{
        public override bool PreChatButtonClicked(NPC npc, bool firstButton)
        {
            if (npc.type == NPCID.Nurse && firstButton && IsBossAlive())
            {
                Main.LocalPlayer.KillMe(PlayerDeathReason.ByCustomReason(Main.LocalPlayer.name + " didn't listen to her dialog."), 50.0, 0);
                return false;
            }
            else return true;
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            if (npc.type == NPCID.Nurse && IsBossAlive())
            {
                switch (WorldGen.genRand.Next(5))
                {
                    case 0: 
                        chat = "Bit too preoccupied being scared of that boss to heal you right now. Sorry.";
                        break;
                    case 1:
                        chat = "Can you kill that boss first? My hands are too shakey to open my medkit.";
                        break;
                    case 2:
                        chat = "Protect us like you promised and I'll consider it.";
                        break;
                    case 3:
                        chat = "Just use a healing potion!!";
                        break;
                    case 4:
                        chat = "Press the button. Dare you.";
                        break;
                }
            }
        }

        public static bool IsBossAlive()
        {
            foreach (NPC npc in Main.npc)
                if (npc.boss && npc.active) return true;
            return false;
        }
    }
}
