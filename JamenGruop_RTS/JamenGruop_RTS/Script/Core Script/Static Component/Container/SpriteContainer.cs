using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public static class SpriteContainer
	{
		public static Dictionary<string, Texture2D> sprite = new Dictionary<string, Texture2D>();
		public static SpriteFont normalFont;

		public static void LoadContent(ContentManager content)
		{
			AddSprite(content.Load<Texture2D>("Texture/Pixel"), "Test");
			AddSprite(content.Load<Texture2D>("Texture/Background/Background2"), "BackgroundTest");
			AddSprite(content.Load<Texture2D>("Texture/Units/enemyRed1"), "UnitTest");
			AddSprite(content.Load<Texture2D>("Texture/Background/Grass"), "Grass");

			AddSprite(content.Load<Texture2D>("Texture/Units/PC Computer - Warcraft 2 - Footman 74 x 74"), "Footman");
			AddSprite(content.Load<Texture2D>("Texture/Units/PC Computer - Warcraft 2 - Peasant 45 x 45"), "Peasant");
			AddSprite(content.Load<Texture2D>("Texture/Units/white circle"), "WhiteCircle");

			// Builing
			AddSprite(content.Load<Texture2D>("Texture/Builing/Fram"), "Fram");
			AddSprite(content.Load<Texture2D>("Texture/Builing/GoldMine"), "GoldMine");
			AddSprite(content.Load<Texture2D>("Texture/Builing/HomeTown"), "Barracks");
			AddSprite(content.Load<Texture2D>("Texture/Builing/LumberMilk"), "LumberMilk");


            // UI Icon
			AddSprite(content.Load<Texture2D>("Texture/UI/Icon/foodIcon"), "foodIcon");
			AddSprite(content.Load<Texture2D>("Texture/UI/Icon/goldIcon"), "goldIcon");
			AddSprite(content.Load<Texture2D>("Texture/UI/Icon/woodIcon"), "woodIcon");


			//AddSprite(content.Load<Texture2D>(""), "");

			// font Text
			normalFont = content.Load<SpriteFont>("Font/NormalFont");
		}

		private static void AddSprite(Texture2D texture2D, string name)
		{
			sprite.Add(name, texture2D);
		}
	}
}
