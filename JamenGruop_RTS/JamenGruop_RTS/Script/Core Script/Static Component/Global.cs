using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public static class Global
	{
		public static void LoadContent(ContentManager content)
		{
			SpriteContainer.LoadContent(content);
			AudioContainer.LoadContent(content);
		}

		public static void Initialize()
		{
			SceneController.Initialize();
		}

		public static void Update(GameTime gameTime)
		{
			Time.Update(gameTime);
			SceneController.UpdateScenes();
			Input.Update();
		}

		public static void Draw(SpriteBatch spriteBatch)
		{
			SceneController.DrawScenes(spriteBatch);
		}
	}
}
