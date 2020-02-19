using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		protected Unit myTarget;


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
		}


		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
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

        public virtual void Move()
        {
            // Calculates deltaTime based on the gameTime.
            float deltatime = Time.deltaTime;

            // Move the GameObject based on the result from HandleInput, speed and deltaTime.
            Transform.Position += ((velocity * moveSpeed) * deltatime);
        }
        public void NewMovementCommand(Vector2 newPosition)
        {
            myNewPosition = newPosition;
            if (isMoving == false)
            {
                Thread myThread01 = new Thread(MoveToPosition);

                myThread01.Start();
                isMoving = true;
            }
        }


        public void MoveToPosition()
        {
            if (transform.Position != myNewPosition)
            {
                Vector2 newVelocity = new Vector2();
                if (transform.Position.Y > myNewPosition.Y)
                {

                    newVelocity += new Vector2(0, -1);
                }

                    reachDestination = true;
                    isMoving = false;
                }

                if (transform.Position != myNewPosition)
                {
                    Vector2 newVelocity = new Vector2();
                    if (transform.Position.Y > myNewPosition.Y)
                    {
                        newVelocity += new Vector2(0, -1);
                    }
                    if (transform.Position.Y < myNewPosition.Y)
                    {
                        newVelocity += new Vector2(0, +1);
                    }
                    if (transform.Position.X > myNewPosition.X)
                    {
                        newVelocity += new Vector2(-1, 0);
                    }
                    if (transform.Position.X < myNewPosition.X)
                    {
                        newVelocity += new Vector2(+1, 0);
                    }
                    newVelocity.Normalize();

                    velocity = newVelocity;

                    if (Vector2.Distance(new Vector2(0, transform.Position.Y), new Vector2(0, myNewPosition.Y)) < 2f)
                    {
                        transform.Position = new Vector2(transform.Position.X, myNewPosition.Y);
                    }

                    if (Vector2.Distance(new Vector2(transform.Position.X, 0), new Vector2(myNewPosition.X, 0)) < 2f)
                    {
                        transform.Position = new Vector2(myNewPosition.X, transform.Position.Y);
                    }
                }
            }

            velocity = new Vector2(0, 0);
        }

        public void ClickToMove()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                var mousex = Mouse.GetState().Position.X;
                var mousey = Mouse.GetState().Position.Y;
                Vector2 newPosition = new Vector2(mousex, mousey);

                Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));

                NewMovementCommand(worldPosition);

            }
        }
	}
}
