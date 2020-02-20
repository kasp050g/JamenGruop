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
	public class _GoldMine : GameObject
	{
		static Semaphore MyGoldMineRoom_Semaphore = new Semaphore(0, 2); // Initial count 0, max capacity of 1
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
			Sprite = SpriteContainer.sprite["GoldMine"];
			originPositionEnum = OriginPositionEnum.BottomLeft;
			base.Awake();
            transform.Origin += new Vector2(12, -25);
        }

		public override void Start()
		{
			base.Start();
			MyGoldMineRoom_Semaphore.Release(2);
		}

		public override void Update()
		{
			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public void GoInToGoldMine(object o_worker)
		{
			_Kasper_Worker worker = (_Kasper_Worker)o_worker;

			MyGoldMineRoom_Semaphore.WaitOne();
            if (worker.eMoveTo == eMoveToSpot.GoldMine && worker.isWorking == false)
            {
                worker.currentFood = 0;
                worker.currentWood = 0;
                worker.isWorking = true;
                while (worker.currentGold < worker.maxGold)
                {
                    Thread.Sleep(workSpeed);
                    worker.currentGold += 1;
                }
                worker.isWorking = false;
                MyGoldMineRoom_Semaphore.Release();

                worker.NewMovementCommand(allBuildings.barracks.Transform.Position, eMoveToSpot.Barracks);
            }
		}
	}
}
