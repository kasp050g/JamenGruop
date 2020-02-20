using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class ShowResource : GUI
	{
		private SpriteFont font;
		private Color fontColor = Color.White;
		public string Text { get; set; }
		public Vector2 FontScale { get; set; }
		public Resource resource { get; set; }
		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle(
					(int)Transform.Position.X - (int)(Transform.Origin.X * Transform.Scale.X),
					(int)Transform.Position.Y - (int)(Transform.Origin.Y * Transform.Scale.Y),
					(int)(sprite.Width * Transform.Scale.X),
					(int)(sprite.Height * Transform.Scale.Y));
			}
		}

		public ShowResource(Resource resource)
		{
			this.resource = resource;
		}

		public override void Awake()
		{
			if (Sprite == null)
			{
				Sprite = SpriteContainer.sprite["Test"];
			}
			if(font == null)
			{
				font = SpriteContainer.normalFont;
			}
			transform.Scale = new Vector2(200, 50);
			FontScale = new Vector2(0.5f, 0.5f);
            layerDepth = 0.9f;
            Color = Color.Black ;
			base.Awake();
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
			base.Update();
			Text = resource.ResourceNumber.ToString();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			var x = (Rectangle.X + (Rectangle.Width / 2)) - (font.MeasureString(Text).X / 2) * FontScale.X +50;
			var y = (Rectangle.Y + (Rectangle.Height / 2)) - (font.MeasureString(Text).Y / 2) * FontScale.Y;
			spriteBatch.DrawString(font, Text, new Vector2(x, y), fontColor, 0f, Vector2.Zero, FontScale, SpriteEffects.None, layerDepth + 0.05f);
		}
	}
}
