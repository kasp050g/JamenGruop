using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class Component
	{
		protected OriginPositionEnum originPositionEnum = OriginPositionEnum.TopLeft;
		protected SpriteEffects spriteEffects = SpriteEffects.None;
		protected Transform transform = new Transform();
		protected Color color = Color.White;
		protected float layerDepth = 0;
        protected bool isActive = true;
		protected Texture2D sprite;
		protected bool isFirstUpdate = true;

		public OriginPositionEnum OriginPositionEnum { get => originPositionEnum; set => originPositionEnum = value; }
		public SpriteEffects SpriteEffects { get => spriteEffects; set => spriteEffects = value; }
		public Transform Transform { get => transform; set => transform = value; }
		public Color Color { get => color; set => color = value; }
		public float LayerDepth { get => layerDepth; set => layerDepth = value; }
		public bool IsActive { get => isActive; set => isActive = value; }
		public Texture2D Sprite { get => sprite; set => sprite = value; }
		public bool IsFirstUpdate { get => isFirstUpdate; set => isFirstUpdate = value; }

		public virtual Rectangle BoundingBox
		{
			get
			{
				return new Rectangle(
					(int)Transform.Position.X,
					(int)Transform.Position.Y,
					sprite.Width,
					sprite.Height);
			}
		}

		public Component() { }

		public Component(Vector2 position)
		{
			Transform.Position = position;
		}

		public virtual void Awake()
		{
			UpdateOrigin();			
		}
		public virtual void Start()
		{			
			
		}
		public virtual void Update()
		{
			
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
            spriteBatch.Draw(
                // Texture2D
                this.sprite,
                // Postion
                this.transform.Position,
                // Source Rectangle
                null,
                // Color
                this.color,
                // Rotation
                MathHelper.ToRadians(this.transform.Rotation),
                // Origin
                this.transform.Origin,
                // Scale
                this.transform.Scale,
                // SpriteEffects
                this.spriteEffects,
                // LayerDepth
                this.layerDepth             
            );
		}

		public void UpdateOrigin()
		{
			// --- Top ---

			// top left
			if (OriginPositionEnum.TopLeft == originPositionEnum)
			{
				Transform.Origin = new Vector2(0, 0);
			}
			// top mid
			if (OriginPositionEnum.TopMid == originPositionEnum)
			{
				Transform.Origin = new Vector2((float)sprite.Width / 2f, 0);
			}
			// top rigth
			if (OriginPositionEnum.TopRight == originPositionEnum)
			{
				Transform.Origin = new Vector2((float)sprite.Width, 0);
			}

			// --- Mid ---

			// mid left
			if (OriginPositionEnum.MidLeft == originPositionEnum)
			{
				Transform.Origin = new Vector2(0, (float)sprite.Height / 2f);
			}
			// mid 
			if (OriginPositionEnum.Mid == originPositionEnum)
			{
				Transform.Origin = new Vector2((float)sprite.Width / 2f, (float)sprite.Height / 2f);
			}
			// mid rigth
			if (OriginPositionEnum.MidRight == originPositionEnum)
			{
				Transform.Origin = new Vector2((float)sprite.Width, (float)sprite.Height / 2f);
			}

			// --- Bottom ---

			// bottom left
			if (OriginPositionEnum.BottomLeft == originPositionEnum)
			{
				Transform.Origin = new Vector2(0, (float)sprite.Height);
			}
			// bottom mid
			if (OriginPositionEnum.BottomMid == originPositionEnum)
			{
				Transform.Origin = new Vector2((float)sprite.Width / 2f, (float)sprite.Height);
			}
			// bottom rigth
			if (OriginPositionEnum.BottomRight == originPositionEnum)
			{
				Transform.Origin = new Vector2((float)sprite.Width, (float)sprite.Height);
			}
		}

		public virtual void OnCollision(Component component)
		{
		}

		public virtual void IsColliding(Component component)
		{
			if (BoundingBox.Intersects(component.BoundingBox))
			{
				OnCollision(component);
			}
		}
	}
}
