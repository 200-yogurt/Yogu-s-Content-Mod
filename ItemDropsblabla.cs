using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YoguContentMod.Items.Materials;

namespace YoguContentMod
{
    public class DropsGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.townNPC)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Skin>(), Main.rand.Next(3, 7));
            }
        }
    }
}
