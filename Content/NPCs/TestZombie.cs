using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.Bestiary;

namespace TestMod.Content.NPCs
{ 
	public class TestZombie : ModNPC
    {
        // �]�w���J��Ѽ�
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Skeleton;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        // �]�w�Ѽ�
        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Zombie);
            NPC.damage = 10;
            NPC.defense = 12;
            NPC.lifeMax = 2000;
            NPC.value = 60f;
            NPC.knockBackResist = 0.9f;
            AIType = NPCID.Zombie;
            AnimationType = NPCID.Zombie;
            Banner = Item.NPCtoBanner(NPCID.Zombie);
            BannerItem = Item.BannerToItem(Banner);
        }

        // �ͦ����v
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance - 0.45f;
        }

        // �[�i�Ǫ���Ų
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                new FlavorTextBestiaryInfoElement("High Defense Zombie")
            });
        }

    }
}
