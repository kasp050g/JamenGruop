using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public static class SceneController
	{
		private static SceneContainer sceneContainer = new SceneContainer();
		private static Camera camera = new Camera();
		private static Scene currentScene;
        public static eCurrentTestScene eCurrentTest;

		public static Camera Camera { get => camera; set => camera = value; }
		public static SceneContainer SceneContainer { get => sceneContainer; set => sceneContainer = value; }
		public static Scene CurrentScene
		{
			get
			{
				return currentScene;
			}
			set
			{
				if (currentScene != value)
				{
					if (currentScene != null)
					{
						// Tells the previous scene that we're switching to a different scene
						currentScene.OnSwitchAwayFromThisScene();
					}

					// Changes the scene
					currentScene = value;
					currentScene.OnSwitchToThisScene();

					// Tells the camera that the scene has changed
					Camera.OnSwitchScene();
				}
			}
		}

		public static void Initialize()
		{
			SceneContainer.Initialize();
			CurrentScene = SceneContainer.Scenes[0];

            switch (eCurrentTest)
            {
                case eCurrentTestScene.None:
                    break;
                case eCurrentTestScene.Jonas:
                    CurrentScene = SceneContainer.Scenes[1];
                    break;
                case eCurrentTestScene.Nikolaj:
                    CurrentScene = SceneContainer.Scenes[2];
                    break;
                case eCurrentTestScene.Kasper:
                    CurrentScene = SceneContainer.Scenes[3];
                    break;
                case eCurrentTestScene.Lucas:
                    CurrentScene = SceneContainer.Scenes[4];
                    break;
                default:
                    break;
            }
        }

		public static void UpdateScenes()
		{
			CurrentScene.Update();

			// Update all Scenes with UpdateEnabled is true, if it is the current Scene dont update it 2 times.
			foreach (Scene scene in SceneContainer.Scenes)
			{
				if (scene.UpdateEnabled == true)
				{
					if (CurrentScene != scene)
					{
						scene.Update();
					}
				}
			}

			if (Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.D1))
			{
				CurrentScene = SceneContainer.Scenes[1];
			}
			if (Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.D2))
			{
				CurrentScene = SceneContainer.Scenes[2];
			}
			if (Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.D3))
			{
				CurrentScene = SceneContainer.Scenes[3];
			}
			if (Input.GetKeyDown(Microsoft.Xna.Framework.Input.Keys.D4))
			{
				CurrentScene = SceneContainer.Scenes[4];
			}
		}

		public static void DrawScenes(SpriteBatch spriteBatch)
		{
			CurrentScene.Draw(spriteBatch);

			// Draw all Scenes with DrawEnabled is true, if it is the current Scene dont Draw it 2 times.
			foreach (Scene scene in SceneContainer.Scenes)
			{
				if (scene.DrawEnabled == true)
				{
					if (CurrentScene != scene)
					{
						scene.Draw(spriteBatch);
					}
				}
			}
		}


	}
}
