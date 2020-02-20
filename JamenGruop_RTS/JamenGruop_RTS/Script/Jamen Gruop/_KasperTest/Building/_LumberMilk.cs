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
	public class _LumberMilk : GameObject
	{
		static Semaphore MyLumberMilkRoom_Semaphore = new Semaphore(0, 2); // Initial count 0, max capacity of 1
		public AllBuildings allBuildings;
        public int workSpeed = 200;
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
		public override void Awake()
		{
			Sprite = SpriteContainer.sprite["LumberMilk"];
			originPositionEnum = OriginPositionEnum.BottomMid;
			base.Awake();
            transform.Origin += new Vector2(15, -25);
        }

		public override void Start()
		{
			base.Start();
			MyLumberMilkRoom_Semaphore.Release(2);
		}

		public override void Update()
		{
			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public void GoInToLumberMilk(object o_worker)
		{
			_Kasper_Worker worker = (_Kasper_Worker)o_worker;

			MyLumberMilkRoom_Semaphore.WaitOne();

            if(worker.eMoveTo == eMoveToSpot.LumberMilk && worker.isWorking == false)
            {
                worker.currentFood = 0;
                worker.currentGold = 0;
                worker.isWorking = true;
                while (worker.currentWood < worker.maxWood)
                {
                    Thread.Sleep(workSpeed);
                    worker.currentWood += 1;
                }
                worker.isWorking = false;

                worker.NewMovementCommand(allBuildings.barracks.Transform.Position, eMoveToSpot.Barracks);
            }
                MyLumberMilkRoom_Semaphore.Release();

		}
	}
}
