using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Threading;

namespace JamenGruop_RTS
{
	class Barracks : GameObject
	{
		public List<Unit> createdUnits = new List<Unit>();
		public ETeam BarracksTeam = new ETeam();
		public int RecruitBonus = 0;

		private Vector2 creationPoint = new Vector2();
		private float recruitTimer = 10f;
		private Player owner = new Player();
		private Footman tmp = new Footman();

		public Barracks(int positionX, int positionY, Player owner)
		{
			this.owner = owner;
			owner.PlayerMaxFood += 25;
<<<<<<< Updated upstream
=======
			BarracksTeam = owner.PlayerTeam;

			Transform.Position = new Vector2(positionX, positionY);

			creationPoint = new Vector2(sprite.Width / 2, sprite.Height);
>>>>>>> Stashed changes
		}

		public override void Update()
		{
			RecruitmentTimer();
		}

		private void RecruitmentTimer()
		{
			if (owner.PlayerMaxFood >= owner.PlayerCurrentFood + tmp.FoodCost)
			{
				while (recruitTimer != 0f)
				{
					recruitTimer -= 1f;
					Thread.Sleep(500);
					switch (recruitTimer)
					{
						case 0f:
							RecruitUnit();
							break;
					}
				}

				if (RecruitBonus != 6)
					RecruitBonus++;

				recruitTimer = 10f - (1 * RecruitBonus);
			}
			else
			{
				Thread.Sleep(2500);
			}
		}

		private void RecruitUnit()
		{
			tmp = new Footman(
                creationPoint,
				BarracksTeam
				);

			owner.PlayerCurrentFood += tmp.FoodCost;

			createdUnits.Add(tmp);

			SceneController.CurrentScene.Instantiate(tmp);
		}
	}
}
