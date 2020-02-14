using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace JamenGruop_RTS
{
	public class GameObject : Component
	{
		public override void Awake()
		{
			if (Sprite == null)
			{
				Sprite = SpriteContainer.sprite["Test"];
			}
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
	}
}
