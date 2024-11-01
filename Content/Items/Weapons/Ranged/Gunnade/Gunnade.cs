﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CCMod.Utils;
using Terraria.DataStructures;
using CCMod.Common;
using Terraria.GameContent.Creative;
using CCMod.Common.Attributes;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;

namespace CCMod.Content.Items.Weapons.Ranged.Gunnade
{
	[CodedBy("Pexiltd")]
	[SpritedBy("Pexiltd")]
	[ConceptBy("Pexiltd")]
	public class Gunnade : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Gunnade");
			//Tooltip.SetDefault("[A piece from the mind of a demolitionist.]);
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Boomstick, 1);
			recipe.AddIngredient(ItemID.Grenade, 150);
			recipe.AddIngredient(ItemID.DemoniteBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 1; i < 4; i++)
			{
				Vector2 vec = velocity.NextVector2RotatedByRandom(18f, 36, i);
				var projectile = Projectile.NewProjectileDirect(source, position, vec, type, damage, knockback, player.whoAmI, ai0: 0);
				projectile.usesLocalNPCImmunity = true;
				projectile.localNPCHitCooldown = 1;
			}
			return base.Shoot(player, source, position, velocity, type, damage, knockback);
		}
		public override void SetDefaults()
		{
			Item.SetDefaultRanged(12, 18, 21, 5, 75, 75, ItemUseStyleID.Shoot, ProjectileID.Grenade, 13, true);
			Terraria.Audio.SoundStyle item36 = SoundID.Item36;
			Item.UseSound = item36;
		}
	}
}

