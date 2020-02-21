
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	class Barracks : GameObject
	{
		public List<Unit> createdUnits = new List<Unit>();
		public ETeam BarracksTeam = new ETeam();
		public int recruitBonus = 0;

		private Vector2 creationPoint = new Vector2();
		private float recruitTimer = 10f;
		private Player owner = new Player();
		private Unit tmp;

		private Mutex m = new Mutex();

		public Barracks(Vector2 pos)
		{
			sprite = SpriteContainer.sprite["Barracks"];

			Transform.Position = pos;
			Transform.Scale = new Vector2(2, 2);
		}

		public Barracks(int positionX, int positionY, ETeam team, Player owner)
		{
			Transform.Position = new Vector2(positionX, positionY);
			BarracksTeam = team;
			this.owner = owner;
			owner.PlayerMaxFood += 25;


		}

		public override void Update()
		{
			RecruitmentTimer();
		}

		private void RecruitmentTimer()
		{
			while(recruitTimer != 0f &&
				owner.PlayerMaxFood > owner.PlayerCurrentFood + tmp.FoodCost)
			{
				recruitTimer -= Time.deltaTime;
				switch(recruitTimer)
				{
					case 0f:
						RecruitUnit();
						recruitTimer = 10f - (1 * recruitBonus);
						break;
				}
			}
		}

		private void RecruitUnit()
		{
			tmp = new Unit(
                new Vector2((int)creationPoint.X, (int)creationPoint.Y),
				BarracksTeam
				);

			createdUnits.Add(tmp);

			SceneController.CurrentScene.Instantiate(tmp);
		}

		public void DeliverResource(Worker worker)
		{
			m.WaitOne();

			Thread.Sleep(750);

			worker.Owner.PlayerGold += worker.WorkerResourceValue;
			worker.WorkerResourceValue = 0;
			worker.WorkerHasDeliveredResource = true;
			worker.WorkerState = EWorkerStates.MovingToTarget;
			worker.Sprite = SpriteContainer.sprite["WIdle"];
			//worker.WorkerThread = new Thread(worker.Update);
			//worker.WorkerThread.IsBackground = true;
			//worker.WorkerThread.Start();
			m.ReleaseMutex();
		}
	}
}
