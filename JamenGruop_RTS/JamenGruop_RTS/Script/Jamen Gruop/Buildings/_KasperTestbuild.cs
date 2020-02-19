using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class _KasperTestbuild : GameObject
	{
		public _Zone zone;
		public Rectangle BuildCollider
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

		public _KasperTestbuild(_Zone zone)
		{
			this.zone = zone;
		}
		public override void Awake()
		{
			transform.Scale = new Vector2(100, 100);
			Color = Color.Yellow;
			layerDepth = 0.8f;
			transform.Position = zone.Transform.Position - new Vector2(-50, -100);
			base.Awake();
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

		public void IsSelect(bool showAttacArrow)
		{
			Console.WriteLine(showAttacArrow);
			zone.attackArrow.IsActive = showAttacArrow;
		}
	}
}
