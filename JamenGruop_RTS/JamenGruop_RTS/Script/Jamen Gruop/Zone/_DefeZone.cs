using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class _DefeZone : GameObject
	{
		public List<Unit> units = new List<Unit>();
		public _Zone myZone;

		public _DefeZone(_Zone zone)
		{
			this.myZone = zone;
		}

		public override void Awake()
		{
			Sprite = SpriteContainer.sprite["Test"];
			transform.Scale = new Vector2(400, 200);
			Color = Color.DarkBlue;
			layerDepth = 0.1f;
			transform.Position = myZone.Transform.Position + new Vector2(200, 10);
			base.Awake();
		}

		public override void Start()
		{
			base.Start();
			MoveDefeUnitToDefeSpot();
		}

		public override void Update()
		{
			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public void MoveDefeUnitToDefeSpot()
		{
			Vector2 newPositon = transform.Position + new Vector2(50,50);
			foreach (_Kasper_Worker item in units)
			{
				//item.NewMovementCommand(newPositon);
				newPositon += new Vector2(100, 0);
			}
		}
	}
}
