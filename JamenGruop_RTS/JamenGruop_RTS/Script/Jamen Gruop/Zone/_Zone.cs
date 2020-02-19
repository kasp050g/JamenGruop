using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class _Zone : GameObject
	{
		public List<Unit> units = new List<Unit>();

		public _DefeZone defeZone;

		public _KasperTestbuild kasperTestbuild;

		public override void Awake()
		{
			defeZone = new _DefeZone(this);
			kasperTestbuild = new _KasperTestbuild(this);

			Sprite = SpriteContainer.sprite["Test"];
			transform.Scale = new Vector2(700, 450);
			Color = Color.Green;
			layerDepth = 0;
			

			

			base.Awake();
		}

		public override void Start()
		{
			SceneController.CurrentScene.Instantiate(defeZone);
			SceneController.CurrentScene.Instantiate(kasperTestbuild);
			defeZone.units = units;
			base.Start();
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
