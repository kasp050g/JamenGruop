using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class AttackArrow : GameObject
	{
		public _Zone myZone;

		public _Zone EnemyZone;

		public Rectangle Collider
		{
			get
			{
				return new Rectangle(
					(int)transform.Position.X - (int)(transform.Origin.X * transform.Scale.X),
					(int)transform.Position.Y - (int)(transform.Origin.Y * transform.Scale.Y),
					(int)(sprite.Width * transform.Scale.X),
					(int)(sprite.Height * transform.Scale.Y)
					);
			}
		}
		public AttackArrow(_Zone zone)
		{
			this.myZone = zone;
		}
		public override void Awake()
		{
			transform.Scale = new Vector2(50, 50);
			Color = Color.Red;
			layerDepth = 0.95f;
			base.Awake();
			isActive = false;
		}

		public override void Start()
		{
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

		public void AttackZone()
		{
			Console.WriteLine("Atttack Zone call");

			EnemyZone.enemyUnits = new List<Unit>(myZone.units);
			EnemyZone.attackZone.units = new List<Unit>(myZone.units);
			myZone.units.Clear();
			EnemyZone.attackZone.MoveAttackunitsToAttackZone();

		}
	}
}
