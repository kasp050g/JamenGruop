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


		public static void LoadContent(ContentManager content)
		{
			AddSprite(content.Load<Texture2D>("Texture/Pixel"), "Test");
			AddSprite(content.Load<Texture2D>("Texture/Background/Background2"), "BackgroundTest");
			AddSprite(content.Load<Texture2D>("Texture/Units/enemyRed1"), "UnitTest");

			AddSprite(content.Load<Texture2D>("Texture/Units/PC_Computer_-_Warcraft_2_-_Footman_74_x_74"), "Footman");
			AddSprite(content.Load<Texture2D>("Texture/Units/PC_Computer_-_Warcraft_2_-_Peasant_45_x_45"), "Peasant");

		}

		private static void AddSprite(Texture2D texture2D, string name)
		{
			sprite.Add(name, texture2D);
		}
	}
}
