﻿using CCMod.Common;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CCMod.Content.Items.Weapons.Magic
{
    internal class DrenchedTome : ModItem, IMadeBy
    {
        public string CodedBy => "LowQualityTrash-Xinim";

        public string SpritedBy => "Kyoru";

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The Pages Are Hard To Turn");
        }
        public override void SetDefaults()
        {
            Item.width = 39;
            Item.height = 44;

            Item.useTime = 10;
            Item.useAnimation = 10;

            Item.damage = 9;
            Item.knockBack = 1f;
            Item.crit = 2;
            Item.mana = 4;

            Item.DamageType = DamageClass.Magic;
            Item.value = Item.sellPrice(silver: 30);
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.rare = ItemRarityID.Green;
            Item.autoReuse = true;
            Item.noMelee = true;

            Item.shoot = ModContent.ProjectileType<SlimeSpike>();
            Item.shootSpeed = 9;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 randomSpread = velocity.RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(source, position, randomSpread, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
        }
    }
    class SlimeSpike : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.penetrate = 1;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            if (Projectile.velocity.Y <= 10)
            {
                Projectile.velocity.Y += .25f;
            }
        }
    }
}
