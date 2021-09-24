using Terraria.ID;
using Terraria.ModLoader;

namespace YoguContentMod
{
    public class SDFEDEFR : GlobalNPC
    {
        public override void NPCLoot()
        {
            if (npc.townNPC)
            {
                Item.NewItem(npc.GetRect(), ModContent.ItemType<Skin>(), Main.rand.Next(3, 7));
            }
        }
    }
}
