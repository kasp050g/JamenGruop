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
    public class _Kasper_Worker : Unit
    {
        float timer = 0f;
        float interval = 200f;
        int currentColumn;
        int currentRow;
        int totalColumns = 5;
        int totalRows = 22;
        //public Texture2D Texture;
        public Rectangle SourceRect;
        public SpriteEffects _spriteEffects = SpriteEffects.None;
        public _Kasper_eMove_LeftAndRigth eMove_LeftAndRigth;
        public _Kasper_eMove_UpAndDown eMove_UpAndDown;
		public eMoveToSpot eMoveTo;

		//protected Vector2 velocity = new Vector2();
		protected Vector2 velocityPrevious = new Vector2();
        protected Vector2 currentPrevious = new Vector2();

        bool carryGold = false;
        bool carryWood = false;

		public int currentGold = 0;
		public int currentFood = 0;
		public int currentWood = 0;

		public int maxGold = 10;
		public int maxFood = 10;
		public int maxWood = 10;

		public bool isWorking = false;

		public AllBuildings allBuildings;

		public override Rectangle UnitCollider
		{
			get
			{
				return new Rectangle(
					(int)transform.Position.X - (int)(transform.Origin.X * transform.Scale.X),
					(int)transform.Position.Y - (int)(transform.Origin.Y * transform.Scale.Y),
					(int)((float)sprite.Width / (float)totalColumns * (float)transform.Scale.X),
					(int)((float)sprite.Height / (float)totalRows * (float)transform.Scale.Y)
					);
			}
		}

		public _Kasper_Worker(Vector2 position, ETeam team) : base(position, team)
        {

        }

        public override void Awake()
        {
            sprite = SpriteContainer.sprite["Peasant"];
            transform.Scale = new Vector2(2, 2);
			
            layerDepth = 0.8f;
            base.Awake();

        }

        public override void Start()
        {
            base.Start();
			transform.Origin = new Vector2(15, 15);
        }

        public override void Update()
        {
            base.Update();

            Animate();
            TestMove();
			if(currentGold > 0 || currentFood > 0)
			{
				carryGold = true;
			}
			else
			{
				carryGold = false;
			}

			if (currentWood > 0)
			{
				carryWood = true;
			}
			else
			{
				carryWood = false;
			}
		}

        public override void Draw(SpriteBatch spriteBatch)
        {
			if(isWorking == false)
			{
				spriteBatch.Draw(
					// Texture2D
					this.sprite,
					// Postion
					this.transform.Position,
					// Source Rectangle
					SourceRect,
					// Color
					this.color,
					// Rotation
					MathHelper.ToRadians(this.transform.Rotation),
					// Origin
					this.transform.Origin,
					// Scale
					this.transform.Scale,
					// SpriteEffects
					_spriteEffects,
					// LayerDepth
					this.layerDepth
				);
			}
        }

		public void NewMovementCommand(Vector2 newPosition, eMoveToSpot eMoveTo)
		{
			if(isWorking == false)
			{
				this.eMoveTo = eMoveTo;
				myNewPosition = newPosition;
				if (isMoving == false)
				{
					Thread myMoveToPosition_Thread = new Thread(MoveToPosition);
					myMoveToPosition_Thread.Start();
					isMoving = true;
				}
			}
		}

		public void MoveToPosition()
		{		
			Console.WriteLine("start" + eMoveTo.ToString());
			bool reachDestination = false;
			float moveOffset = 2;
			while (reachDestination == false)
			{
				if (Vector2.Distance(transform.Position, myNewPosition) < 4f)
				{
					reachDestination = true;
					isMoving = false;
					switch (eMoveTo)
					{
						case eMoveToSpot.None:
							break;
						case eMoveToSpot.Barracks:
							allBuildings.barracks.GiveResource(this);
							break;
						case eMoveToSpot.LumberMilk:
							Thread wookWork_Thread = new Thread(allBuildings.lumberMilk.GoInToLumberMilk);
							wookWork_Thread.Start(this);
							break;
						case eMoveToSpot.Fram:
							Thread foodWork_Thread = new Thread(allBuildings.fram.GoInToFram);
							foodWork_Thread.Start(this);
							break;
						case eMoveToSpot.GoldMine:
							Thread goldWork_Thread = new Thread(allBuildings.goldMine.GoInToGoldMine);
							goldWork_Thread.Start(this);							
							break;
						default:
							break;
					}
				}

				if (transform.Position != myNewPosition)
				{
					Vector2 newVelocity = new Vector2();
					if (Math.Abs(transform.Position.Y - myNewPosition.Y) < moveOffset)
					{
						newVelocity += new Vector2(0, 0);
					}
					else if (transform.Position.Y > myNewPosition.Y)
					{
						newVelocity += new Vector2(0, -1);
					}
					else if (transform.Position.Y < myNewPosition.Y)
					{
						newVelocity += new Vector2(0, +1);
					}

					if (Math.Abs(transform.Position.X - myNewPosition.X) < moveOffset)
					{
						newVelocity += new Vector2(0, 0);
					}
					else if (transform.Position.X > myNewPosition.X)
					{
						newVelocity += new Vector2(-1, 0);
					}
					else if (transform.Position.X < myNewPosition.X)
					{
						newVelocity += new Vector2(+1, 0);
					}
					newVelocity.Normalize();

					velocity = newVelocity;
				}
			}

			velocity = new Vector2(0, 0);
		}

		public void TestMove()
        {
            if(velocity.Y > 0)
            {
                eMove_UpAndDown = _Kasper_eMove_UpAndDown.Down;
            }
            else if(velocity.Y < 0)
            {
                eMove_UpAndDown = _Kasper_eMove_UpAndDown.Up;
            }
            else
            {
                eMove_UpAndDown = _Kasper_eMove_UpAndDown.None;
            }

            if (velocity.X > 0)
            {
                eMove_LeftAndRigth = _Kasper_eMove_LeftAndRigth.Rigth;
            }
            else if (velocity.X < 0)
            {
                eMove_LeftAndRigth = _Kasper_eMove_LeftAndRigth.Left;                
            }
            else
            {
                eMove_LeftAndRigth = _Kasper_eMove_LeftAndRigth.None;                
            }
        }

        public void Animate()
        {
            velocityPrevious = currentPrevious;
            currentPrevious = velocity;
            //Player animation del
            float width = sprite.Width / totalColumns;
            float height = sprite.Height / totalRows;
            SourceRect = new Rectangle((int)((float)currentColumn * width), (int)((float)currentRow * height), (int)width, (int)height);


            if (velocity == new Vector2(0,0))
            {
                if (carryGold == false && carryWood == false)
                {
                    currentRow = 0;
                }
                if (carryGold == true && carryWood == false)
                {
                    currentRow = 10;
                }
                if (carryGold == false && carryWood == true)
                {
                    currentRow = 15;
                }
            }

            if (velocity != new Vector2(0, 0))
            {
                if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth.Left)
                {
                    _spriteEffects = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    _spriteEffects = SpriteEffects.None;
                }

                //Right
                if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/Rigth/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/None/**/)
                {
                    currentColumn = 2;
                }
                //Left
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/Rigth/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/None/**/)
                {
                    currentColumn = 2;                    
                }
                //Down
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/None/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/Down/**/)
                {
                    currentColumn = 4;
                }
                //Up
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/None/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/Up/**/)
                {
                    currentColumn = 0;
                }
                //Up + Right
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/Rigth/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/Up/**/)
                {
                    currentColumn = 1;
                }
                //Down + Right
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/Rigth/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/Down/**/)
                {
                    currentColumn = 3;
                }
                //Up + Left
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/Left/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/Up/**/)
                {
                    currentColumn = 1;
                }
                //Down + Left
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/Left/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/Down/**/)
                {
                    currentColumn = 3;
                }

                AnimateWalk();
            }
        }

        public void AnimateWalk()
        {
            if (carryGold == false && carryWood == false)
            {
                if (currentPrevious != velocityPrevious)
                {
                    currentRow = 1;
                }
                timer += Time.totalMilliseconds;
                if (timer > interval)
                {
                    currentRow++;
                    if (currentRow > 4)
                    {
                        currentRow = 1;
                    }
                    timer = 0f;
                }
            }
            if (carryGold == true && carryWood == false)
            {
                if (currentPrevious != velocityPrevious)
                {
                    currentRow = 10;
                }
                timer += Time.totalMilliseconds;
                if (timer > interval)
                {
                    currentRow++;
                    if (currentRow > 14)
                    {
                        currentRow = 10;
                    }
                    timer = 0f;
                }
            }
            if (carryGold == false && carryWood == true)
            {
                if (currentPrevious != velocityPrevious)
                {
                    currentRow = 15;
                }
                timer += Time.totalMilliseconds;
                if (timer > interval)
                {
                    currentRow++;
                    if (currentRow > 19)
                    {
                        currentRow = 15;
                    }
                    timer = 0f;
                }
            }
        }
    }
}
