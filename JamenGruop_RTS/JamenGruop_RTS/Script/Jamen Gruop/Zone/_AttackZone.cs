using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class _AttackZone : GameObject
	{
		public List<Unit> units = new List<Unit>();
		public _Zone myZone;

		public _AttackZone(_Zone zone)
		{
			this.myZone = zone;
		}

		public override void Awake()
		{
			Sprite = SpriteContainer.sprite["Test"];
			transform.Scale = new Vector2(400, 200);
			Color = Color.PaleVioletRed;
			layerDepth = 0.1f;
			transform.Position = myZone.Transform.Position + new Vector2(200, 240);
			base.Awake();
		}

		public override void Start()
		{
			base.Start();
			MoveAttackunitsToAttackZone();
		}

		public override void Update()
		{
			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public void MoveAttackunitsToAttackZone()
		{
			Console.WriteLine("Move To attack Zone");
			Console.WriteLine(units.Count);

			Vector2 newPositon = transform.Position + new Vector2(50, 50);
			foreach (Unit item in units)
			{
				item.NewMovementCommand(newPositon);
				newPositon += new Vector2(100, 0);
			}
		}
	}
}
