using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class JonasScene : Scene
	{

        public override void Initialize()
		{
            BackgroundImage backgroundtest = new BackgroundImage(SpriteContainer.sprite["BackgroundTest"]);
            backgroundtest.OriginPositionEnum = OriginPositionEnum.Mid;
            Instantiate(backgroundtest);
            base.Initialize();
            SceneController.eCurrentTest = eCurrentTestScene.Jonas;

            Console.WriteLine("got hereerererer");

            Footman footman = new Footman(new Vector2(0,0),ETeam.Team01);
            Instantiate(footman);
        }

		public override void OnSwitchToThisScene()
		{
			base.OnSwitchToThisScene();
		}

		public override void OnSwitchAwayFromThisScene()
		{
			base.OnSwitchAwayFromThisScene();
		}

		public override void Update()
		{
			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
        }
	}
}
