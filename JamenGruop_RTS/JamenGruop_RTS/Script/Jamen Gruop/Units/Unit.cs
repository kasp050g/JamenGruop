using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class Unit : Character
	{
		protected bool isRange = false;
		protected float attackRange = 69;
		protected int damage = 0;
		protected float attackSpeed = 1;
		protected Vector2 myNewPosition;
		protected Vector2 myNewPosition01;
		protected Vector2 myNewPosition02;
		protected bool isMoving = false;
		protected bool isSelected = false;

		protected Unit myTarget;
		protected ETeam myTeam;

        protected float moveSpeed = 250;

        protected Vector2 velocity = new Vector2();

        public virtual Rectangle UnitCollider
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

		private int foodCost;

		public int FoodCost { get => foodCost; set => foodCost = value; }

		public Unit(Vector2 position, ETeam team)
		{
			this.transform.Position = position;
			this.myTeam = team;
		}

		protected virtual void AttackTarget()
		{
			if (myTarget != null)
			{
				myTarget.TakeDamage(damage + (unitZone == eUnitZone.attakcer ? 1 : 0));
			}
		}

		public override void Awake()
		{
			base.Awake();
		}

		public override void Start()
		{
			base.Start();

		}

		public override void Update()
		{
			base.Update();
			Move();
		}

		public override void Draw(SpriteBatch spriteBatch)
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
		/// <summary>
		/// Defines how the object moves.
		/// </summary>
		/// <param name="gameTime"></param>
		public virtual void Move()
		{
			// Calculates deltaTime based on the gameTime.
			float deltatime = Time.deltaTime;

			// Move the GameObject based on the result from HandleInput, speed and deltaTime.
			Transform.Position += ((velocity * moveSpeed) * deltatime);
		}
		


	}
}
